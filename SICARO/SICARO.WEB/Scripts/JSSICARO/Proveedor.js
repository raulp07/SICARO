$(document).ready(function () {


    var Proveedor = new Vue({
        el: '#Proveedor',
        data: {
            dDepartamentos: [],
            dProvincia: [],
            dDistrito: [],
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
            ListarDepartamento: function () {
                var data = {
                    flag: 1,
                };
                axios.post('/Ubigeo/CargaComboUbigeo', data).then(response => {

                    this.dDepartamentos = response.data;
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
                            { "data": "vRUC" },
                            { "data": "vTelefono" },
                            { "data": "vNroLicenciaMunicipal" },
                            { "data": "vNroInspeccionSanitaria" },
                            {
                                render: function () {
                                    return '<button type="button" id="ButtonGestionar" class="Gestionar edit-modal btn btn-succes botonGestionar"><span class="glyphicon glyphicon-wrench"></span></button>';
                                }
                            },
                            {
                                render: function () {
                                    return '<button type="button" id="ButtonEditar" class="Editar edit-modal btn btn-warning botonEditar"><span class="glyphicon glyphicon-pencil"></span></button>';
                                }
                            },

                        ],
                    });

                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });
            },
            Nuevo: function(){
                $('#ModalMantenimiento').modal('show');
            },
        },
        created: function () {
            this.ListarProveedor();
        },
    });



});

