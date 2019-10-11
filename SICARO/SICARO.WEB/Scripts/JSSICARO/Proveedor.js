$(document).ready(function () {


    var Proveedor = new Vue({
        el: '#Proveedor',
        data: {
            dDepartamento: [],
            dProvincia: [],
            dDistrito: [],
            dTipoDocumento: [],
            dEstadoEmpresa: [],
            dTipoEmpresa: [],
            selectedDocumento: 0,
            selectedDepartamento: '',
            selectedProvincia: '',
            selectedDistrito: '',
            iIdProveedor: 0,

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
            ListaEstadoEmpresa: function () {
                var data = {
                    co_tabla: 2
                };
                axios.post('/TGeneral/CargaTGeneral', data).then(response => {
                    this.dEstadoEmpresa = response.data;
                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });
            },
            ListaTipoEmpresa: function () {
                var data = {
                    co_tabla: 3
                };
                axios.post('/TGeneral/CargaTGeneral', data).then(response => {
                    this.dTipoEmpresa = response.data;
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
            ListarProveedor: function () {
                var data = {
                };
                axios.post('/Proveedor/ListarProveedor', data).then(response => {
                    var datos = response.data;

                    $('#tbTabla').DataTable().destroy();

                    $('#tbTabla').DataTable({
                        "data": datos,
                        "columns": [
                            { "data": "vNombreProveedor" },
                            { "data": "vDocumento" },
                            { "data": "vTelefono" },
                            { "data": "vNroLicenciaMunicipal" },
                            { "data": "vNroInspeccionSanitaria" },
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

                        ],
                    });                   

                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });
            },
            Nuevo: function () {
                LimpiarFormularioModal($('#btnGuardarModal').attr('id'));
                $('#ModalMantenimiento').modal('show');
            },
            Editar: function (data) {
                LimpiarFormularioModal($('#btnGuardarModal').attr('id'));

                $('#txtNombre').val(data["vNombreProveedor"]);
                $('#txtApellidoPaterno').val(data["vApellidoPaterno"]);
                $('#txtApellidoMaterno').val(data["vApellidoMaterno"]);
                $('#cboTipoDocumentoModal').val(data["iTipoDocumento"]);
                $('#txtNroDocumentoModal').val(data["vDocumento"]);
                $('#cboEstadoEmpresa').val(data["iEstadoEmpresa"]);
                $('#cboTipoEmpresa').val(data["iTipoEmpresa"]);
                $('#txttelefono').val(data["vTelefono"]);
                $('#txtLicenciaMunicipal').val(data["vNroLicenciaMunicipal"]);
                $('#txtInspeccionSanitaria').val(data["vNroInspeccionSanitaria"]);
                Proveedor.iIdProveedor = data["iIdProveedor"];

                this.selectedDepartamento = data["iUbigeo"].substr(0, 2).padEnd(6, '0');
                this.selectedProvincia = data["iUbigeo"].substr(0, 4).padEnd(6, '0');
                this.selectedDistrito = data["iUbigeo"];
                this.ListarProvincia();

                $('#ModalMantenimiento').modal('show');

                
                //$("#txtNombre").first().focus();
            },
            Eliminar: function (data) {
                this.iIdProveedor = data["iIdProveedor"];
                $('#eliminarModal').modal('show');
            },
            SiModal: function () {
                var DTO = {};
                let strUrl = "";
                let strMsj = "";

                DTO.iIdProveedor = this.iIdProveedor;
                strUrl = "/Proveedor/Del_PROVEEDOR";
                strMsj = "Se eliminó.";

                axios.post(strUrl, DTO).then(response => {
                    if (response.data > 0) {
                        this.iIdProveedor = '';
                        MensajeModal('Se elimino correctamente.', 0);
                        this.ListarProveedor();
                    } else {
                        MensajeModal(response.data, 2);
                    }
                }).catch(error => {
                    console.log(error)
                    this.errored = true
                });
            },
            Guardar: function () {
                var url = '/Proveedor/Ins_PROVEEDOR';
                var strMsj = 'Se grabó correctamente';
                var Datos = {
                    vNombreProveedor: $('#txtNombre').val(),
                    vApellidoPaterno: $('#txtApellidoPaterno').val(),
                    vApellidoMaterno: $('#txtApellidoMaterno').val(),
                    iTipoDocumento: $('#cboTipoDocumentoModal').val(),
                    vDocumento: $('#txtNroDocumentoModal').val(),
                    iUbigeo: $('#cboDistrito').val(),
                    iEstadoEmpresa: $('#cboEstadoEmpresa').val(),
                    iTipoEmpresa: $('#cboTipoEmpresa').val(),
                    vTelefono: $('#txttelefono').val(),
                    vNroLicenciaMunicipal: $('#txtLicenciaMunicipal').val(),
                    vNroInspeccionSanitaria: $('#txtInspeccionSanitaria').val(),

                    vDireccion: $('#txtNombre').val(),
                };
                if (this.iIdProveedor != 0) {
                    url = '/Proveedor/Upd_PROVEEDOR';
                    Datos.iIdProveedor = this.iIdProveedor;
                    strMsj = 'Se actualizo correctamente';
                }

                axios.post(url, Datos).then(response => {
                    if (response.data > 0) {
                        MensajeModal(strMsj, 0);
                        this.ListarProveedor();
                        this.iIdProveedor = 0;
                    } else {
                        MensajeModal(data, 2);
                    }
                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });
            },
        },
        created: function () {
            this.ListarDepartamento();
            this.ListarProveedor();
            this.ListaTipoDocumento();
            this.ListaEstadoEmpresa();
            this.ListaTipoEmpresa();
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
        Proveedor.Editar(data);
    });

    $("#tbTabla").on("click", "button.eliminar", function () {
        var table = $('#tbTabla').DataTable();
        if (table.row(this).child.isShown()) {
            var data = table.row(this).data();
        } else {
            var data = table.row($(this).parents("tr")).data();
        }
        Proveedor.Eliminar(data);

    });


});

