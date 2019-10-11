$(document).ready(function () {


    var MateriaPrima = new Vue({
        el: '#MateriaPrima',
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
            iIdMateriaPrima: 0,

        },
        methods: {            
            ListarMateriaPrima: function () {
                var data = {
                };
                axios.post('/MateriaPrima/ListarMateriaPrima', data).then(response => {
                    var datos = response.data;

                    $('#tbTabla').DataTable().destroy();

                    $('#tbTabla').DataTable({
                        "data": datos,
                        "columns": [
                            { "data": "vNombreMateriaPrima" },
                            { "data": "iOlorCS" },
                            { "data": "iColorCS" },
                            { "data": "iSaborCS" },
                            { "data": "iTexturaCS" },
                            { "data": "iBrixRF" },
                            { "data": "iPHRF" },
                            { "data": "iAcidesRF" },
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
                LimpiarFormularioModal('btnGuardarModal');
                $('#ModalMantenimiento').modal('show');
            },
            Editar: function (data) {
                LimpiarFormularioModal('btnGuardarModal');

                this.iIdMateriaPrima = data["iIdMateriaPrima"];
                $('#txtNombre').val(data["vNombreMateriaPrima"]),
                $('#txtDescripcion').val(data["vDescripcionMateriaPrima"]),
                $('#txtOlorCS').val(data["iOlorCS"]),
                $('#txtColorCS').val(data["iColorCS"]),
                $('#txtSaborCS').val(data["iSaborCS"]),
                $('#txtTexturaCS').val(data["iTexturaCS"]),
                $('#txtBrixRF').val(data["iBrixRF"]),
                $('#txtPHRF').val(data["iPHRF"]),
                $('#txtAcidesRF').val(data["iAcidesRF"]),
                $('#txtRequisitosMicrobiolicos').val(data["vRequisitosMicrobiolicos"]),
                $('#txtRequisitoRotulado').val(data["vRequisitoRotulado"]),
                $('#txtRequisitosEmpaquetado').val(data["vRequisitosEmpaquetado"]),
                $('#txtRequisitosPresentacion').val(data["vRequisitosPresentacion"]),
                $('#txtCondicionFisicaEntrega').val(data["vCondicionFisicaEntrega"]),
                $('#txtCondicionFisicaAlmacenamiento').val(data["vCondicionFisicaAlmacenamiento"]),

                $('#ModalMantenimiento').modal('show');
                //$("#txtNombre").first().focus();
            },
            Eliminar: function (data) {
                this.iIdMateriaPrima = data["iIdMateriaPrima"];
                $('#eliminarModal').modal('show');
            },
            SiModal: function () {
                var DTO = {};
                let strUrl = "";
                let strMsj = "";

                DTO.iIdMateriaPrima = this.iIdMateriaPrima;
                strUrl = "/MateriaPrima/Del_MATERIA_PRIMA";
                strMsj = "Se eliminó.";

                axios.post(strUrl, DTO).then(response => {
                    if (response.data > 0) {
                        this.iIdMateriaPrima = '';
                        MensajeModal('Se elimino correctamente.', 0);
                        this.ListarMateriaPrima();
                    } else {
                        MensajeModal(response.data, 2);
                    }
                }).catch(error => {
                    console.log(error)
                    this.errored = true
                });
            },
            Guardar: function () {
                var url = '/MateriaPrima/Ins_MATERIA_PRIMA';
                var strMsj = 'Se grabó correctamente';
                var Datos = {
                    vNombreMateriaPrima: $('#txtNombre').val(),
                    vDescripcionMateriaPrima: $('#txtDescripcion').val(),
                    iOlorCS: $('#txtOlorCS').val(),
                    iColorCS: $('#txtColorCS').val(),
                    iSaborCS: $('#txtSaborCS').val(),
                    iTexturaCS: $('#txtTexturaCS').val(),
                    iBrixRF: $('#txtBrixRF').val(),
                    iPHRF: $('#txtPHRF').val(),
                    iAcidesRF: $('#txtAcidesRF').val(),
                    vRequisitosMicrobiolicos: $('#txtRequisitosMicrobiolicos').val(),
                    vRequisitoRotulado: $('#txtRequisitoRotulado').val(),
                    vRequisitosEmpaquetado: $('#txtRequisitosEmpaquetado').val(),
                    vRequisitosPresentacion: $('#txtRequisitosPresentacion').val(),
                    vCondicionFisicaEntrega: $('#txtCondicionFisicaEntrega').val(),
                    vCondicionFisicaAlmacenamiento: $('#txtCondicionFisicaAlmacenamiento').val(),
                };
                if (this.iIdMateriaPrima != 0) {
                    url = '/MateriaPrima/Upd_MATERIA_PRIMA';
                    Datos.iIdMateriaPrima = this.iIdMateriaPrima;
                    strMsj = 'Se actualizo correctamente';
                }
                axios.post(url, Datos).then(response => {
                    if (response.data > 0) {
                        MensajeModal(strMsj, 0);
                        this.ListarMateriaPrima();
                        this.iIdMateriaPrima = 0;
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
            this.ListarMateriaPrima();
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
        MateriaPrima.Editar(data);
    });

    $("#tbTabla").on("click", "button.eliminar", function () {
        var table = $('#tbTabla').DataTable();
        if (table.row(this).child.isShown()) {
            var data = table.row(this).data();
        } else {
            var data = table.row($(this).parents("tr")).data();
        }
        MateriaPrima.Eliminar(data);

    });


});

