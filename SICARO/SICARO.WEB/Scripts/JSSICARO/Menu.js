$(document).ready(function () {


    var Menu = new Vue({
        el: '#Menu',
        data: {
            ListaOpciones: [],
            ListaPadres: [],
            Id: 0,

        },
        methods: {
            ListarMenu: function () {
                var idOpcion =  0;
                axios.post('/Menu/ListarMenu', { idOpcion: idOpcion }).then(response => {
                    if (response.data.Error == "0") {
                        this.ListaOpciones = response.data.Data;
                        var datos = response.data.Data.filter(x=> x.PadreId == $('#ddlTipoBusqueda').val());
                        $('#tbTabla').DataTable().destroy();
                        $('#tbTabla').DataTable({
                            "data": datos,
                            "columns": [
                                { "data": "Nombre" },
                                { "data": "Nivel" },
                                { "data": "Controlador" },
                                { "data": "Accion" },
                                { "data": "Orden" },
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
                    }

                    this.ListarPadres();
                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });
            },
            ListarPadres: function () {
                this.ListaPadres = this.ListaOpciones.filter(x=> x.PadreId == 0);
            },
            Nuevo: function () {
                LimpiarFormularioModal($('#btnGuardarModal').attr('id'));
                this.Id = 0;
                $('#ModalMantenimiento').modal('show');
            },
            Editar: function (data) {
                LimpiarFormularioModal($('#btnGuardarModal').attr('id'));

                $('#txtNombre').val(data["Nombre"]);
                $('#ddlTipo').val(data["PadreId"]);
                $('#txtOrden').val(data["Orden"]);
                $('#txtControlador').val(data["Controlador"]);
                $('#txtAccion').val(data["Accion"]);

                Menu.Id = data["Id"];
                $('#ModalMantenimiento').modal('show');

            },
            Eliminar: function (data) {
                this.Id = data["Id"];
                $('#eliminarModal').modal('show');
            },
            SiModal: function () {
                var DTO = {};
                let strUrl = "";
                let strMsj = "";

                DTO.idOpcion = this.Id;
                strUrl = "/Menu/Del_MENU";
                strMsj = "Se eliminó.";

                axios.post(strUrl, DTO).then(response => {
                    if (response.data.codigo > 0) {
                        this.Id = '';
                        MensajeModal('Se elimino correctamente.', 0);
                        this.ListarMenu();
                    } else {
                        MensajeModal(response.data, 2);
                    }
                }).catch(error => {
                    console.log(error)
                    this.errored = true
                });
            },
            Guardar: function () {
                var url = '/Menu/InsertMenu';
                var strMsj = 'Se grabó correctamente';
                var Datos = {
                    Nombre: $('#txtNombre').val(),
                    PadreId: $('#ddlTipo').val(),
                    Controlador: $('#txtControlador').val(),
                    Accion: $('#txtAccion').val(),
                    Orden: $('#txtOrden').val(),
                };
                if (this.Id != 0) {
                    Datos.Id = this.Id;
                }

                axios.post(url, Datos).then(response => {
                    if (response.data.Error == "0") {
                        MensajeModal(strMsj, 0);
                        this.ListarMenu();
                        this.Id = 0;
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
            this.ListarMenu();
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
        Menu.Editar(data);
    });

    $("#tbTabla").on("click", "button.eliminar", function () {
        var table = $('#tbTabla').DataTable();
        if (table.row(this).child.isShown()) {
            var data = table.row(this).data();
        } else {
            var data = table.row($(this).parents("tr")).data();
        }
        Menu.Eliminar(data);

    });

});

