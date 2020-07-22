$(document).ready(function () {
    google.charts.load('current', { 'packages': ['scatter'] });
    google.charts.load('current', { 'packages': ['corechart'] });
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
            Lista_Recopilada: [],
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
                            idPeso: $('#unidadpeso').val(),
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
                            idPeso: $('#unidadpeso').val(),
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
                    $('#PorcentajePrecision').val(Math.round(parseFloat(Resultado["exactitud"]) * 100) + " %");
                    $('#ErrorMedioCuadratico').val(Resultado["mse"]);
                    $('#NroPrediccion').text(Math.round(Resultado["prediccion"]));

                    var ListaPrediccionGrafica = response.data.ListaPrediccionGrafica;

                    $('.GestionarIndicador').attr('disabled', false);
                    var _ddlPronostico = $('#ddlPronostico').val();
                    var Columna1 = '';
                    var Columna2 = '';

                    var Columna1cuadro1 = '';
                    var Columna2cuadro1 = '';

                    var Columna1cuadro2 = '';
                    var Columna2cuadro2 = '';

                    var Columna1cuadro3 = '';
                    var Columna2cuadro3 = '';

                    var Columna1cuadro4 = '';
                    var Columna2cuadro4 = '';

                    var Grafica = [];

                    var Grafica1 = [];
                    var Grafica2 = [];
                    var Grafica3 = [];
                    var Grafica4 = [];

                    var options1 = {};
                    var options2 = {};
                    var options3 = {};
                    var options4 = {};

                    $('#cuadro1').removeClass('hide');
                    $('#cuadro2').removeClass('hide');
                    $('#cuadro3').removeClass('hide');
                    $('#cuadro4').removeClass('hide');

                    switch (_ddlPronostico) {
                        case "1":
                            //options1 = {
                            //    title: 'Comparacion Producto vs. Tiempo',
                            //    hAxis: { title: 'Producto', minValue: 0, maxValue: 26 },
                            //    vAxis: { title: 'Tiempo', minValue: 0, maxValue: 26 },
                            //    legend: 'none'
                            //};
                            options2 = {
                                title: 'Comparacion Proveedor vs. Tiempo',
                                hAxis: { title: 'Proveedor', minValue: 0, maxValue: 8 },
                                vAxis: { title: 'Tiempo', minValue: 0, maxValue: 26 },
                                legend: 'none'
                            };
                            //options3 = {
                            //    title: 'Comparacion Unidad Medida vs. Tiempo',
                            //    hAxis: { title: 'Unidad M.', minValue: 0, maxValue: 26 },
                            //    vAxis: { title: 'Tiempo', minValue: 0, maxValue: 26 },
                            //    legend: 'none'
                            //};
                            options4 = {
                                title: 'Comparacion Peso vs. Tiempo',
                                hAxis: { title: 'Peso', minValue: 0, maxValue: 26 },
                                vAxis: { title: 'Tiempo', minValue: 0, maxValue: 26 },
                                legend: 'none'
                            };

                            break;
                        case "2":
                            //options1 = {
                            //    title: 'Comparacion Producto vs. Tiempo',
                            //    hAxis: { title: 'Producto', minValue: 0, maxValue: 26 },
                            //    vAxis: { title: 'Tiempo', minValue: 0, maxValue: 26 },
                            //    legend: 'none'
                            //};
                            options2 = {
                                title: 'Comparacion Proveedor vs. Tiempo',
                                hAxis: { title: 'Proveedor', minValue: 0, maxValue: 8 },
                                vAxis: { title: 'Tiempo', minValue: 0, maxValue: 26 },
                                legend: 'none'
                            };
                            //options3 = {
                            //    title: 'Comparacion Unidad Medida vs. Tiempo',
                            //    hAxis: { title: 'Unidad M.', minValue: 0, maxValue: 26 },
                            //    vAxis: { title: 'Tiempo', minValue: 0, maxValue: 26 },
                            //    legend: 'none'
                            //};
                            options4 = {
                                title: 'Comparacion Peso vs. Tiempo',
                                hAxis: { title: 'Peso', minValue: 0, maxValue: 26 },
                                vAxis: { title: 'Tiempo', minValue: 0, maxValue: 26 },
                                legend: 'none'
                            };

                            break;
                        case "3":
                            //options1 = {
                            //    title: 'Comparacion Producto vs. Tiempo',
                            //    hAxis: { title: 'Producto', minValue: 0, maxValue: 26 },
                            //    vAxis: { title: 'Tiempo', minValue: 0, maxValue: 26 },
                            //    legend: 'none'
                            //};
                            //options2 = {
                            //    title: 'Comparacion Proveedor vs. Tiempo',
                            //    hAxis: { title: 'Proveedor', minValue: 0, maxValue: 26 },
                            //    vAxis: { title: 'Tiempo', minValue: 0, maxValue: 26 },
                            //    legend: 'none'
                            //};
                            options4 = {
                                title: 'Comparacion Cantidad vs. Tiempo',
                                hAxis: { title: 'Cantidad', minValue: 0, maxValue: 100 },
                                vAxis: { title: 'Tiempo', minValue: 0, maxValue: 100 },
                                legend: 'none'
                            };

                            break;
                        case "4":
                            options1 = {
                                title: 'Comparacion Producto vs. Tiempo',
                                hAxis: { title: 'Producto', minValue: 0, maxValue: 26 },
                                vAxis: { title: 'Tiempo', minValue: 0, maxValue: 26 },
                                legend: 'none'
                            };
                            options2 = {
                                title: 'Comparacion Proveedor vs. Tiempo',
                                hAxis: { title: 'Proveedor', minValue: 0, maxValue: 26 },
                                vAxis: { title: 'Tiempo', minValue: 0, maxValue: 26 },
                                legend: 'none'
                            };
                            options3 = {
                                title: 'Comparacion Unidad Medida vs. Tiempo',
                                hAxis: { title: 'Unidad M.', minValue: 0, maxValue: 26 },
                                vAxis: { title: 'Tiempo', minValue: 0, maxValue: 26 },
                                legend: 'none'
                            };
                            options4 = {
                                title: 'Comparacion Peso vs. Tiempo',
                                hAxis: { title: 'Peso', minValue: 0, maxValue: 26 },
                                vAxis: { title: 'Tiempo', minValue: 0, maxValue: 26 },
                                legend: 'none'
                            };


                            break;
                        default:
                    }

                    

                    $.each(ListaPrediccionGrafica, function (k, v) {
                        var Columnas = [];

                        var Columnascuadro1 = [];
                        var Columnascuadro2 = [];
                        var Columnascuadro3 = [];
                        var Columnascuadro4 = [];

                        switch (_ddlPronostico) {
                            case "1":
                                Columnas = [
                                v.peso,
                                v.tiempo
                                ];
                                Columna1 = 'Peso';
                                Columna2 = 'Tiempo';

                                Columnascuadro1 = [
                                v.producto,
                                v.tiempo
                                ];
                                Columna1cuadro1 = 'Producto';
                                Columna2cuadro1 = 'Tiempo';

                                Columnascuadro2 = [
                                v.proveedor,
                                v.tiempo
                                ];
                                Columna1cuadro2 = 'Proveedor';
                                Columna2cuadro2 = 'Tiempo';

                                Columnascuadro3 = [
                                v.unidadmedida,
                                v.tiempo
                                ];
                                Columna1cuadro3 = 'Unidad M.';
                                Columna2cuadro3 = 'Tiempo';

                                Columnascuadro4 = [
                                v.peso,
                                v.tiempo
                                ];
                                Columna1cuadro4 = 'Peso';
                                Columna2cuadro4 = 'Tiempo';

                                break;
                            case "2":
                                Columnas = [
                                v.peso,
                                v.tiempo
                                ];
                                Columna1 = 'Peso';
                                Columna2 = 'Tiempo';

                                Columnascuadro1 = [
                                v.producto,
                                v.tiempo
                                ];
                                Columna1cuadro1 = 'Producto';
                                Columna2cuadro1 = 'Tiempo';

                                Columnascuadro2 = [
                                v.proveedor,
                                v.tiempo
                                ];
                                Columna1cuadro2 = 'Proveedor';
                                Columna2cuadro2 = 'Tiempo';

                                Columnascuadro3 = [
                                v.unidadmedida,
                                v.tiempo
                                ];
                                Columna1cuadro3 = 'Unidad M.';
                                Columna2cuadro3 = 'Tiempo';

                                Columnascuadro4 = [
                                v.peso,
                                v.tiempo
                                ];
                                Columna1cuadro4 = 'Peso';
                                Columna2cuadro4 = 'Tiempo';


                                break;
                            case "3":
                                Columnas = [
                                v.cantidad,
                                v.tiempo
                                ];
                                Columna1 = 'Cantidad';
                                Columna2 = 'Tiempo';

                                Columnascuadro1 = [
                                v.producto,
                                v.tiempo
                                ];
                                Columna1cuadro1 = 'Producto';
                                Columna2cuadro1 = 'Tiempo';

                                Columnascuadro2 = [
                                v.actividad,
                                v.tiempo
                                ];
                                Columna1cuadro2 = 'Actividad';
                                Columna2cuadro2 = 'Tiempo';

                                Columnascuadro4 = [
                                v.cantidad,
                                v.tiempo
                                ];
                                Columna1cuadro4 = 'Cantidad';
                                Columna2cuadro4 = 'Tiempo';


                                break;
                            case "4":
                                Columnas = [
                                v.peso,
                                v.merma
                                ];
                                Columna1 = 'Peso';
                                Columna2 = 'Merma';

                                Columnascuadro1 = [
                                v.producto,
                                v.merma
                                ];
                                Columna1cuadro1 = 'Producto';
                                Columna2cuadro1 = 'Merma';

                                Columnascuadro2 = [
                                v.proveedor,
                                v.merma
                                ];
                                Columna1cuadro2 = 'Proveedor';
                                Columna2cuadro2 = 'Merma';

                                Columnascuadro3 = [
                                v.unidadmedida,
                                v.merma
                                ];
                                Columna1cuadro3 = 'Unidad M.';
                                Columna2cuadro3 = 'Merma';

                                Columnascuadro4 = [
                                v.peso,
                                v.merma
                                ];
                                Columna1cuadro4 = 'Peso';
                                Columna2cuadro4 = 'Merma';

                                break;
                            default:
                        }

                        Grafica.push(Columnas);
                        if (Columnascuadro1.length != 0) {
                            Grafica1.push(Columnascuadro1);
                        }
                        if (Columnascuadro2.length != 0) {
                            Grafica2.push(Columnascuadro2);
                        }
                        if (Columnascuadro3.length != 0) {
                            Grafica3.push(Columnascuadro3);
                        }
                        if (Columnascuadro4.length != 0) {
                            Grafica4.push(Columnascuadro4);
                        }

                    });

                    if (Grafica1.length == 0) {
                        $('#cuadro1').addClass('hide');
                    }
                    if (Grafica2.length == 0) {
                        $('#cuadro2').addClass('hide');
                    }
                    if (Grafica3.length == 0) {
                        $('#cuadro3').addClass('hide');
                    }
                    if (Grafica4.length == 0) {
                        $('#cuadro4').addClass('hide');
                    }


                    var data = new google.visualization.DataTable();
                    //var data1 = new google.visualization.DataTable();
                    var data2 = new google.visualization.DataTable();
                    //var data3 = new google.visualization.DataTable();
                    var data4 = new google.visualization.DataTable();

                    //data.addColumn('number', 'Producto');
                    data.addColumn('number', Columna1);
                    data.addColumn('number', Columna2);
                    //data.addColumn('number', 'Final1');
                    //data.addColumn('number', 'Final2');

                    //data1.addColumn('number', Columna1cuadro1);
                    //data1.addColumn('number', Columna2cuadro1);

                    data2.addColumn('number', Columna1cuadro2);
                    data2.addColumn('number', Columna2cuadro2);

                    //data3.addColumn('number', Columna1cuadro3);
                    //data3.addColumn('number', Columna2cuadro3);

                    data4.addColumn('number', Columna1cuadro4);
                    data4.addColumn('number', Columna2cuadro4);


                    data.addRows(Grafica);

                    //data1.addRows(Grafica1);
                    data2.addRows(Grafica2);
                    //data3.addRows(Grafica3);
                    data4.addRows(Grafica4);

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



            //        var chart = new google.charts.Scatter(document.getElementById('DiagramaDispercion'));
            //        chart.draw(data, google.charts.Scatter.convertOptions(options));


                    //var chart1 = new google.visualization.ScatterChart(document.getElementById('cuadro1'));
                    //chart1.draw(data1, options1);

                    var chart2 = new google.visualization.ScatterChart(document.getElementById('cuadro2'));
                    chart2.draw(data2, options2);

                    //var chart3 = new google.visualization.ScatterChart(document.getElementById('cuadro3'));
                    //chart3.draw(data3, options3);

                    var chart4 = new google.visualization.ScatterChart(document.getElementById('cuadro4'));
                    chart4.draw(data4, options4);


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