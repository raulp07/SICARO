$(document).ready(function () {


    var Rol = new Vue({
        el: '#Rol',
        data: {
            Id: 0,

        },
        methods: {
            ListarRol: function () {
                var Id = 0;
                axios.post('/Rol/ListarRol', { Id: Id }).then(response => {
                    var datos = response.data;
                    $('#tbTabla').DataTable().destroy();
                    $('#tbTabla').DataTable({
                        "data": datos,
                        "columns": [
                            { "data": "Nombre" },
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
                                    return '<button type="button" id="Buttonvincular" class="vincular edit-modal btn btn-success botonvincular"><span class="glyphicon glyphicon-random"></span></button>';
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
                this.Id = 0;
                $('#ModalMantenimiento').modal('show');
            },
            Editar: function (data) {
                LimpiarFormularioModal($('#btnGuardarModal').attr('id'));

                $('#txtNombre').val(data["Nombre"]);
                Rol.Id = data["Id"];
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

                DTO.Id = this.Id;
                strUrl = "/Rol/Del_MENU";
                strMsj = "Se eliminó.";

                axios.post(strUrl, DTO).then(response => {
                    if (response.data > 0) {
                        this.Id = '';
                        MensajeModal('Se elimino correctamente.', 0);
                        this.ListarRol();
                    } else {
                        MensajeModal(response.data, 2);
                    }
                }).catch(error => {
                    console.log(error)
                    this.errored = true
                });
            },
            Guardar: function () {
                var url = '/Rol/InsertRol';
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
                        this.ListarRol();
                        this.Id = 0;
                    } else {
                        MensajeModal(response.data.Mensaje, 2);
                    }
                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });
            },
            vincular: function (data) {
                $('#RolxOpcionModal').modal('show');
                var idOpcion = 0;
                this.Id = data;
                var rol = data;
                var html = '';
                axios.post('/Menu/OpcionXPerfil', { idOpcion: idOpcion, rol: rol }).then(response => {
                    var datos = response.data.DataOpcion;
                    var DataOpcionPerfil = response.data.DataOpcionPerfil;

                    $.each(datos, function (k1, v1) {
                        if (v1.Nivel == 1) {
                            var d = DataOpcionPerfil.find(x => x.Opcion.Id == v1.Id);
                            var _seleccion = 'checked';
                            if (d == undefined) {
                                _seleccion = ''
                            }
                            html += '<li><input type="checkbox" ' + _seleccion + ' class="OpcionesMenu" data-OpcionesMenu="' + v1.Id + '" /><b><a name="' + v1.Id + '"  >' + v1.Nombre + '</a></b>';
                            html += '<ul>';
                            $.each(datos, function (k2, v2) {
                                if (v2.Nivel == 2) {
                                    var d2 = DataOpcionPerfil.find(x => x.Opcion.Id == v2.Id);
                                    var _seleccion2 = 'checked';
                                    if (d2 == undefined) {
                                        _seleccion2 = ''
                                    }
                                    if (v1.Id == v2.PadreId) {
                                        html += '<li><input type="checkbox" ' + _seleccion2 + ' class="OpcionesMenu" data-OpcionesMenu="' + v2.Id + '" /><b><a name="' + v2.Id + '" >' + v2.Nombre + '</a></b>';
                                        html += '</li>';
                                    }
                                }
                            });
                            html += '</ul>';
                            html += '</li>';
                        }
                    });
                    var topNodes = function (chkbx) {
                        return $(chkbx).closest('ul').closest('li');
                    };

                    var markTopNodes = function (nodes) {
                        if (!nodes.length) return;
                        var chkbx = nodes.children('input').eq(0); //parent checkbox
                        //get the immediate li's of the node
                        var lis = nodes.children('ul').children('li');
                        //get count of un-checked checkboxes
                        var count = lis.children('input[type=checkbox]:checked').length;
                        //mark if count is 0
                        if (count > 0) {
                            chkbx.prop('checked', true);
                        } else {
                            chkbx.prop('checked', false);
                        }
                        
                        //recursive call for other top nodes
                        markTopNodes(topNodes(chkbx));
                    };

                    var onChange = function (e) {
                        //for child nodes, checked state = current checkbox checked state
                        $(this).closest('li').find('input[type=checkbox]').prop('checked', this.checked);

                        //for parent nodes, checked if immediate childs are checked, but recursively
                        markTopNodes(topNodes(this));
                    };

                    $('#list').html(html);
                    $('#regionContent').on('change', 'input[type=checkbox]', onChange);

                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });
            },
            GuardarOpcionRol: function () {
                var OpcionRol = [];
                $.each($('.OpcionesMenu'), function () {
                    if (this.checked) {
                        var Opcion = {
                            Id: $(this).attr('data-OpcionesMenu'),
                        }
                        OpcionRol.push(Opcion);
                    }
                });

                axios.post("/Rol/InsertOpcionRol", { op: OpcionRol, idRol: this.Id }).then(response => {
                    if (response.data.Error == "0") {
                        MensajeModal("Se registro corretamente el Rol con los perfiles", 0);
                        this.ListarRol();
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
            this.ListarRol();
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
        Rol.Editar(data);
    });

    $("#tbTabla").on("click", "button.eliminar", function () {
        var table = $('#tbTabla').DataTable();
        if (table.row(this).child.isShown()) {
            var data = table.row(this).data();
        } else {
            var data = table.row($(this).parents("tr")).data();
        }
        Rol.Eliminar(data);

    });
    $("#tbTabla").on("click", "button.vincular", function () {
        var table = $('#tbTabla').DataTable();
        if (table.row(this).child.isShown()) {
            var data = table.row(this).data();
        } else {
            var data = table.row($(this).parents("tr")).data();
        }
        Rol.vincular(data["Id"]);

    });

});

