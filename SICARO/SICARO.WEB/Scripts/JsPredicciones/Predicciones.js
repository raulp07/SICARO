$(document).ready(function () {
    google.charts.load('current', { 'packages': ['scatter'] });
    new Vue({
        el: "#app",
        data: {
            Lista_Materia_Prima: [],
            Lista_Producto: [],
            Lista_Proveedor: [],
            Lista_Opciones: [],
            dTipoPronostico: [],
            dUnidadMedida: [],
            dIntervaloVecesProduccion: [],
            dActividad: [],
            Lista_Recopilada:[],
            vCodCapacitacion: "",
            vTemaCapacitacion: "",
            centesimas: 0,
            segundos: 60,
            minutos: 30,
            horas: 0,
        },
        methods: {
            ListaTipoPronostico: function () {
                var data = {
                    co_tabla: 6
                };
                axios.post('/TGeneral/CargaTGeneral', data).then(response => {
                    this.dTipoPronostico = response.data;
                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });
            },
            ListaUnidadMedida: function () {
                var data = {
                    co_tabla: 7
                };
                axios.post('/TGeneral/CargaTGeneral', data).then(response => {
                    this.dUnidadMedida = response.data;
                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });
            },
            ListaIntervaloVecesProduccion: function () {
                var data = {
                    co_tabla: 8
                };
                axios.post('/TGeneral/CargaTGeneral', data).then(response => {
                    this.dIntervaloVecesProduccion = response.data;
                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });
            },
            ListaActividad: function () {
                var data = {
                    co_tabla: 9
                };
                axios.post('/TGeneral/CargaTGeneral', data).then(response => {
                    this.dActividad = response.data;
                }).catch(error => {
                    console.log(error);
                    this.errored = true;
                });
            },
            ListarProducto: function () {
                var data = { iIdproducto: 0 }
                axios.post("/Producto/ListarProducto/", data).then(function (response) {
                    this.Lista_Producto = response.data;
                }.bind(this)).catch(function (error) {
                });
            },
            EmpezarEvaluacion: function () {

                axios.post("/Predicciones/ListaMateriaPrima/", "").then(function (response) {
                    if (response.dataListaProducto > 0) {
                        alert(response.data);
                    }
                    this.Lista_Materia_Prima = response.data.ListaMATERIA_PRIMA;
                }.bind(this)).catch(function (error) {
                });
            },
            ModificarConulta: function () {

                var opcion = $('#ddlPronostico').val();
                $('.GestionarIndicador').attr('disabled', false);
                switch (opcion) {
                    case "0":
                        $('.GestionarIndicador').attr('disabled', true);
                        break;
                    case "1":
                        $('.divProveedor').show();
                        $('.divUnidadMedida').show();
                        $('.divIntervaloProduccion').show();
                        $('.divActividad').hide();
                        break;

                    case "2":
                        $('.divProveedor').show();
                        $('.divUnidadMedida').show();
                        $('.divIntervaloProduccion').hide();
                        $('.divActividad').hide();
                        break;
                    case "3":
                        $('.divProveedor').hide();
                        $('.divUnidadMedida').hide();
                        $('.divIntervaloProduccion').hide();
                        $('.divActividad').show();
                        break;
                    case "4":
                        $('.divProveedor').show();
                        $('.divUnidadMedida').show();
                        $('.divIntervaloProduccion').hide();
                        $('.divActividad').hide();
                        break;
                }


            },
            ConsultarProveedor: function () {

                var iIdproducto = $('#slProducto').val();
                var jsonData = { iIdproducto: iIdproducto };
                axios.post("/Producto/ListarProductoProveedor/", jsonData).then(function (response) {
                    this.Lista_Proveedor = response.data;
                }.bind(this)).catch(function (error) {
                });
            },
            GuardarPrediccion: function () {

                var param = {};

                var _ddlPronostico = $('#ddlPronostico').val();
                switch (_ddlPronostico) {
                    case "1":
                        param = {
                            tipoPronostico: _ddlPronostico,
                            idProducto: $('#slProducto').val(),
                            idProveedor: $('#slProveedor').val(),
                            idUnidadMedida: $('#slUnidadMedida').val(),
                            idIntervaloProduccion: $('#slIntervaloUtilizadoProduccion').val(),
                            Peso: $('#unidadpeso').val(),
                            idActividad: '0',

                            PRECISION: $('#PorcentajePrecision').val(),
                            ErrorMedioCuadratico: $('#ErrorMedioCuadratico').val(),
                            predicion: $('#NroPrediccion').text(),
                        };
                        $('#txttipoprediccion').text('Días');
                        break;
                    case "2":
                        param = {
                            tipoPronostico: _ddlPronostico,
                            idProducto: $('#slProducto').val(),
                            idProveedor: $('#slProveedor').val(),
                            idUnidadMedida: $('#slUnidadMedida').val(),
                            idIntervaloProduccion: '0',
                            Peso: $('#unidadpeso').val(),
                            idActividad: '0',

                            PRECISION: $('#PorcentajePrecision').val(),
                            ErrorMedioCuadratico: $('#ErrorMedioCuadratico').val(),
                            predicion: $('#NroPrediccion').text(),
                        };
                        $('#txttipoprediccion').text('Días');
                        break;
                    case "3":
                        param = {
                            tipoPronostico: _ddlPronostico,
                            idProducto: $('#slProducto').val(),
                            idProveedor: '0',
                            idIntervaloProduccion: '0',
                            idActividad: $('#slActividad').val(),
                            cantidadProducida: $('#cantidadproducida').val(),

                            PRECISION: $('#PorcentajePrecision').val(),
                            ErrorMedioCuadratico: $('#ErrorMedioCuadratico').val(),
                            predicion: $('#NroPrediccion').text(),
                        };
                        $('#txttipoprediccion').text('Minutos');
                        break;
                    case "4":
                        param = {
                            tipoPronostico: _ddlPronostico,
                            idProducto: $('#slProducto').val(),
                            idProveedor: $('#slProveedor').val(),
                            idUnidadMedida: $('#slUnidadMedida').val(),
                            idIntervaloProduccion: '0',
                            Peso: $('#unidadpeso').val(),
                            idActividad: '0',

                            PRECISION: $('#PorcentajePrecision').val(),
                            ErrorMedioCuadratico: $('#ErrorMedioCuadratico').val(),
                            predicion: $('#NroPrediccion').text(),
                        };
                        $('#txttipoprediccion').text('Minutos');
                        break;
                    default:

                }

                //var param = {
                //    Producto: $('#slProducto').val(),
                //    Proveedor: $('#slProveedor').val(),
                //    UnidadMedida: $('#slUnidadMedida').val(),
                //};

                var MP = $('#slProducto').val();
                if (MP == 0) {
                    return;
                }
                axios.post("/Predicciones/GuardarPronosticos/", param).then(function (response) {

                    var Resultado = response.data.resultado;
                    this.Lista_Recopilada = param;
                    $('#PorcentajePrecision').val(Math.round(parseFloat(Resultado["exactitud"]) * 100) +" %");
                    $('#ErrorMedioCuadratico').val(Resultado["mse"]);
                    $('#NroPrediccion').text(Math.round(Resultado["prediccion"]));

                    var ListaPrediccionGrafica = response.data.ListaPrediccionGrafica;

                    $('.GestionarIndicador').attr('disabled', false);

                    var Grafica = []
                    $.each(ListaPrediccionGrafica, function (k, v) {
                        var Columnas = [
                            v.Peso,
                            v.Tiempo
                        ];
                        Grafica.push(Columnas);
                    });

                    var data = new google.visualization.DataTable();
                    //data.addColumn('number', 'Producto');
                    data.addColumn('number', 'Peso');
                    data.addColumn('number', 'Tiempo');
                    //data.addColumn('number', 'Final1');
                    //data.addColumn('number', 'Final2');

                    data.addRows(Grafica);

                    var options = {
                        width: 350,
                        height: 250,
                        chart: {
                            title: 'Diagrama de Dispersión',
                            //subtitle: 'based on hours studied'
                        },
                        axes: {
                            x: {
                                0: { side: 'top' }
                            }
                        }
                    };

                    var chart = new google.charts.Scatter(document.getElementById('DiagramaDispercion'));
                    chart.draw(data, google.charts.Scatter.convertOptions(options));

                }.bind(this)).catch(function (error) {
                });
            },
            AbrirGestionPronostico: function () {
                window.location.href = "/Pronostico?" + "tipopronostico=" + this.Lista_Recopilada.tipoPronostico + "&producto= " + this.Lista_Recopilada.idProducto + "&proveedor=" + this.Lista_Recopilada.idProveedor + "&intervalo=" + this.Lista_Recopilada.idIntervaloProduccion + "&actividad=" + this.Lista_Recopilada.idActividad + "&Prediccion=" + $('#NroPrediccion').text();
            },
            Salir: function () {
                window.location.href = "/Home";
            },
        },
        computed: {},
        created: function () {
            this.ListarProducto();
            this.ListaTipoPronostico();
            this.ListaUnidadMedida();
            this.ListaIntervaloVecesProduccion();
            this.ListaActividad();
            $('.divActividad').hide();
        },
        mounted: function () {
        }
    });
});