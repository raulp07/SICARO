$(document).ready(function () {


    var Personal = new Vue({
        el: '#Personal',
        data: {
            dDepartamento: [],
            dProvincia: [],
            dDistrito: [],
            dTipoDocumento: [],
            dEstadoEmpresa: [],
            dRol: [],
            dArea: [],
            dGestionarUsuario: [],
            selectedDocumento: 0,
            selectedDepartamento: '',
            selectedProvincia: '',
            selectedDistrito: '',
            iIdPersonal: 0,

        },
        methods: {
            ListaTipoDocumento: function () {
                var data = {
                    co_tabla: 1
                };
                axios.post('/TGeneral/CargaTGeneral', data).then(response => {
                    this.dTipoDocumento = response.data;
                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });
            },
            ListaArea: function () {
                var data = {
                    co_tabla: 4
                };
                axios.post('/TGeneral/CargaTGeneral', data).then(response => {
                    this.dArea = response.data;
                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });
            },
            ListaRol: function () {
                var data = {
                    iIdRol: 0
                };
                axios.post('/Rol/ListarRol', data).then(response => {
                    this.dRol = response.data;
                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });
            },
            ListarDepartamento: function () {
                var data = {
                    flag: 1,
                };
                axios.post('/Ubigeo/CargaComboUbigeo', data).then(response => {
                    this.dDepartamento = response.data;
                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });
            },
            ListarProvincia: function () {
                var data = {
                    flag: 2,
                    co_ubigeo: this.selectedDepartamento
                };
                axios.post('/Ubigeo/CargaComboUbigeo', data).then(response => {
                    this.dProvincia = response.data;
                    this.ListarDistrito();
                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });
            },
            ListarDistrito: function () {
                var data = {
                    flag: 3,
                    co_ubigeo: this.selectedProvincia
                };
                axios.post('/Ubigeo/CargaComboUbigeo', data).then(response => {
                    this.dDistrito = response.data;
                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });
            },
            ListarPersonal: function () {
                var data = {
                };
                axios.post('/Personal/ListarPersonal', data).then(response => {
                    var datos = response.data.Data;

                    $('#tbTabla').DataTable().destroy();

                    $('#tbTabla').DataTable({
                        "data": datos,
                        "columns": [
                            {
                                "render": function (j, k, r) {
                                    return '<label>' + r["vApellidoMaternoPersonal"] + ' ' + r["vApellidoPaternoPersonal"] + ', ' + r["vNombrePersonal"] + '</label>';
                                }
                            },
                            {
                                render: function (j, k, r) {
                                    return '<label>' + r["de_TipoDocumento"] + ' - ' + r["NroDocumento"] + '</label>';
                                }
                            },
                            { "data": "Telefono" },
                            { "data": "de_Area" },
                            {
                                "render": function () {
                                    return '<button type="button" id="ButtonEditar" class="editar edit-modal btn btn-warning botonEditar"><span class="glyphicon glyphicon-pencil"></span></button>';
                                }
                            },
                            {
                                "render": function () {
                                    return '<button type="button" id="ButtonEliminar" class="eliminar edit-modal btn btn-danger botonEliminar"><span class="glyphicon glyphicon-trash"></span></button>';
                                }
                            },
                            {
                                "render": function () {
                                    return '<button type="button" id="ButtonGestionarCuenta" class="GestionarCuenta edit-modal btn btn-info botonGestionarCuenta"><span class="glyphicon glyphicon-user"></span></button>';
                                }
                            },
                        ],
                    });

                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });
            },
            Nuevo: function () {
                LimpiarFormularioModal($('#btnGuardarModal').attr('id'));
                this.iIdPersonal = 0;
                $('#ModalMantenimiento').modal('show');
            },
            Editar: function (data) {
                LimpiarFormularioModal($('#btnGuardarModal').attr('id'));

                $('#txtNombre').val(data["vNombrePersonal"]);
                $('#txtApellidoPaterno').val(data["vApellidoPaternoPersonal"]);
                $('#txtApellidoMaterno').val(data["vApellidoMaternoPersonal"]);
                this.selectedDocumento = data["TipoDocumento"];
                $('#txtNroDocumentoModal').val(data["NroDocumento"]);
                $('#txtDireccion').val(data["vDomicilio"]);
                $('#cboRol').val(data["iTipoPersonal"]);
                $('#txttelefono').val(data["Telefono"]);
                $('#dfecha').datetimepicker('setDate', new Date(parseInt(data['dFechaNacimiento'].substr(6))));
                $('#cboArea').val(data["iIdArea"]);
                $('#txtEmail').val(data["Email"]);

                Personal.iIdPersonal = data["iIdPersonal"];

                this.selectedDepartamento = data["iUbigeo"].substr(0, 2).padEnd(6, '0');
                this.selectedProvincia = data["iUbigeo"].substr(0, 4).padEnd(6, '0');
                this.selectedDistrito = data["iUbigeo"];
                this.ListarProvincia();

                $('#ModalMantenimiento').modal('show');

            },
            Eliminar: function (data) {
                this.iIdPersonal = data["iIdPersonal"];
                $('#eliminarModal').modal('show');
            },
            GestionarCuenta: function (data) {
                LimpiarFormularioModal($('#btnGuardarGestionarCuenta').attr('id'));
                this.dGestionarUsuario = data;
                $('#txtUsuarioGC').val(data["CtaUsuario"]);
                $('#GestionarCuentaModal').modal('show');
            },
            SiModal: function () {
                var DTO = {};
                let strUrl = "";
                let strMsj = "";

                DTO.iIdPersonal = this.iIdPersonal;
                strUrl = "/Personal/Del_PERSONAL";
                strMsj = "Se eliminó.";

                axios.post(strUrl, DTO).then(response => {
                    if (response.data > 0) {
                        this.iIdPersonal = '';
                        MensajeModal('Se elimino correctamente.', 0);
                        this.ListarPersonal();
                    } else {
                        MensajeModal(response.data, 2);
                    }
                }).catch(error => {
                    console.log(error)
                    this.errored = true
                });
            },
            Guardar: function () {
                var url = '/Personal/Ins_PERSONAL';
                var strMsj = 'Se grabó correctamente';
                var Datos = {
                    vNombrePersonal: $('#txtNombre').val(),
                    vApellidoPaternoPersonal: $('#txtApellidoPaterno').val(),
                    vApellidoMaternoPersonal: $('#txtApellidoMaterno').val(),
                    TipoDocumento: $('#cboTipoDocumentoModal').val(),
                    NroDocumento: $('#txtNroDocumentoModal').val(),
                    iUbigeo: $('#cboDistrito').val(),
                    vDomicilio: $('#txtDireccion').val(),
                    iIdArea: $('#cboArea').val(),
                    Email: $('#txtEmail').val(),
                    dFechaNacimiento: $('#dfecha').data('date'),
                    Telefono: $('#txttelefono').val(),
                    iTipoPersonal: $('#cboRol').val(),
                };
                if (this.iIdPersonal != 0) {
                    url = '/Personal/Upd_PERSONAL';
                    Datos.iIdPersonal = this.iIdPersonal;
                    strMsj = 'Se actualizo correctamente';
                }

                axios.post(url, Datos).then(response => {
                    if (response.data.Error == "0") {
                        MensajeModal(strMsj, 0);
                        this.ListarPersonal();
                        this.iIdPersonal = 0;
                    } else {
                        MensajeModal(response.data.Mensaje, 2);
                    }
                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });
            },
            GurdarGestionUsusario: function () {
                if ($('#txtPasswordGC').val() != $('#txtConfirmPasswordGC').val()) {
                    MensajeModal("La contraseña no coinciden", 0);
                    return;
                }

                var Datos = {
                    IdRol: this.dGestionarUsuario["iTipoPersonal"],
                    CtaUsuario: $('#txtUsuarioGC').val(),
                    Contrasenia: $('#txtPasswordGC').val(),
                    Nombres: this.dGestionarUsuario["vNombrePersonal"],
                    Apellidos: this.dGestionarUsuario["vApellidoPaternoPersonal"] + ' ' + this.dGestionarUsuario["vApellidoMaternoPersonal"],
                    Cargo: this.dGestionarUsuario["iIdPersonal"],
                };
                axios.post("/Personal/GestionarUsusario", Datos).then(response => {
                    if (response.data.Error == "0") {
                        MensajeModal("Se Guardo correctamente el Ususario", 0);
                        this.ListarPersonal();
                        this.iIdPersonal = 0;
                    } else {
                        MensajeModal(response.data.Mensaje, 2);
                    }
                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });

            },
        },
        created: function () {
            this.ListarDepartamento();
            this.ListarPersonal();
            this.ListaTipoDocumento();
            this.ListaArea();
            this.ListaRol();
        },
    });

    $("#tbTabla").on("click", "button.editar", function () {

        var table = $('#tbTabla').DataTable();
        var data = null;
        if (table.row(this).child.isShown()) {
            data = table.row(this).data();
        } else {
            data = table.row($(this).parents("tr")).data();
        }
        Personal.Editar(data);
    });

    $("#tbTabla").on("click", "button.eliminar", function () {
        var table = $('#tbTabla').DataTable();
        if (table.row(this).child.isShown()) {
            var data = table.row(this).data();
        } else {
            var data = table.row($(this).parents("tr")).data();
        }
        Personal.Eliminar(data);

    });

    $("#tbTabla").on("click", "button.GestionarCuenta", function () {
        var table = $('#tbTabla').DataTable();
        if (table.row(this).child.isShown()) {
            var data = table.row(this).data();
        } else {
            var data = table.row($(this).parents("tr")).data();
        }
        Personal.GestionarCuenta(data);

    });



    $('#dfecha').datetimepicker({
        language: 'es',
        weekStart: 1,
        todayBtn: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 2,
        minView: 2,
        forceParse: 0

    });

});

