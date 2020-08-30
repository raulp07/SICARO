$(document).ready(function () {

    var Pronostico = new Vue({
        el: "#app",
        data: {
            Lista_Materia_Prima: [],
            Lista_Producto: [],
            Lista_Proveedor: [],
            Lista_Control_Produccion: [],
            dTipoPronostico: [],
            dActividad: [],
            dIntervaloVecesProduccion: [],
            idCategoria: 0,
            RedInicio: 0,
            RedFin: 35,
            YellowInicio: 35,
            YellowFin: 70,
            GreenInicio: 70,
            GreenFin: 100,
            RangoPronosticado: 20,
            seleccionTipoPronostico: '0',
            seleccionProducto: '0',
            seleccionProveedor: '0',
            seleccionIntervalo: '0',
            seleccionActividad: '0',
        },
        methods: {
            ListarProducto: function () {

                var data = { iIdproducto: 0 }
                axios.post("/Producto/ListarProducto/", data).then(function (response) {
                    this.Lista_Producto = response.data;
                }.bind(this)).catch(function (error) {
                });
            },
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
            GenerarGrafico: function () {

                google.charts.load('current', { 'packages': ['gauge'] });
                google.charts.setOnLoadCallback(drawChart);
                function drawChart() {
                    var data = google.visualization.arrayToDataTable([
                    ['Label', 'Value'],
                    ['Rango', Pronostico.RangoPronosticado]
                    ]);
                    var options = {
                        width: 250, height: 250,
                        redFrom: Pronostico.RedInicio, redTo: Pronostico.RedFin,
                        yellowFrom: Pronostico.YellowInicio, yellowTo: Pronostico.YellowFin,
                        greenFrom: Pronostico.GreenInicio, greenTo: Pronostico.GreenFin,
                        //minorTicks: 20,
                        max: Pronostico.GreenFin,
                        min: Pronostico.RedInicio,
                        //majorTicks: ['100', '1']
                    };
                    var chart = new google.visualization.Gauge(document.getElementById('chart_div'));
                    chart.draw(data, options);

                }
            },
            EmpezarEvaluacion: function () {

                var jsonData = { iIdMateriaPrima: 0 };
                axios.post("/Predicciones/ListaMateriaPrima/", jsonData).then(function (response) {
                    this.Lista_Materia_Prima = response.data.ListaMATERIA_PRIMA;

                    //this.ListaControlPoduccion();
                    this.GenerarGrafico();
                }.bind(this)).catch(function (error) {
                });
            },
            ModificarConulta: function () {

                var opcion = this.seleccionTipoPronostico;//$('#ddlPronostico').val();
                $('.GestionarIndicador').attr('disabled', false);
                switch (opcion) {
                    case 0:
                        $('.GestionarIndicador').attr('disabled', true);
                        break;
                    case 1:
                        $('.divProveedor').show();
                        //$('.divUnidadMedida').show();
                        $('.divIntervaloProduccion').show();
                        $('.divActividad').hide();
                        break;

                    case 2:
                        $('.divProveedor').show();
                        //$('.divUnidadMedida').show();
                        $('.divIntervaloProduccion').hide();
                        $('.divActividad').hide();
                        break;
                    case 3:
                        $('.divProveedor').hide();
                        //$('.divUnidadMedida').hide();
                        $('.divIntervaloProduccion').hide();
                        $('.divActividad').show();
                        break;
                    case 4:
                        $('.divProveedor').show();
                        //$('.divUnidadMedida').show();
                        $('.divIntervaloProduccion').hide();
                        $('.divActividad').hide();
                        break;
                }
            },
            ConsultarProveedor: function () {

                //var iIdMateriaPrima = $('#slProducto').val();
                //var jsonData = { iIdMateriaPrima: iIdMateriaPrima };
                //axios.post("/Predicciones/ListaMateriaPrimaProveedor/", jsonData).then(function (response) {
                //    this.Lista_Proveedor = response.data.ListaMATERIA_PRIMAProveedor;
                //    this.ListaControlPoduccion();
                //}.bind(this)).catch(function (error) {
                //});

                var iIdproducto = this.seleccionProducto;//$('#slProducto').val();
                var jsonData = { iIdproducto: iIdproducto };
                axios.post("/Producto/ListarProductoProveedor/", jsonData).then(function (response) {
                    this.Lista_Proveedor = response.data;
                }.bind(this)).catch(function (error) {
                });
            },
            MostrarConfiguracionIntervalo: function () {
                $('#ConfiguracionIntervalos').attr('style', 'display:block');
            },
            OcultarConfiguracionIntervalo: function () {
                
                var jsonData = {
                    RedInicio: this.RedInicio,
                    RedFin: this.RedFin,
                    YellowInicio: this.YellowInicio,
                    YellowFin: this.YellowFin,
                    GreenInicio: this.GreenInicio,
                    GreenFin: this.GreenFin,
                    idCategoria: this.idCategoria,
                };
                axios.post("/Pronostico/GuardarCategoriaRango/", jsonData).then(function (response) {
                    $('#ConfiguracionIntervalos').attr('style', 'display:none');
                }.bind(this)).catch(function (error) {
                });

                //this.EmpezarEvaluacion();
            },
            MostrarDetalle: function (lista) {
                $('#Consulta').val(lista.tipoPronostico);
                this.ModificarConulta();
                $('#slProducto').val(lista.idProducto);
                this.RangoPronosticado = lista.predicion;
                this.GenerarGrafico();
            },
            ListaControlPoduccion: function () {

                var idProducto = $('#slProducto').val();
                if (idProducto == 0) {
                    return;
                }
                var jsonData = {
                    tipoPronostico: this.seleccionTipoPronostico,
                    idProducto: this.seleccionProducto,
                    idProveedor: this.seleccionProveedor,
                    idIntervaloProduccion: this.seleccionIntervalo,
                    idActividad: this.seleccionActividad,
                };
                axios.post("/Pronostico/ListaControlProduccion/", jsonData).then(function (response) {
                    var datos = response.data.CONTROLPRODUCCION;
                    $.each(datos, function (key, val) {
                        var date = new Date(parseInt(val.fechaProduccion.substr(6)));
                        var dia = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
                        var mes = date.getMonth() < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
                        var anio = date.getFullYear();
                        var fecha = dia + "/" + mes + "/" + anio;
                        val.fechaProduccion = fecha;
                    });
                    this.Lista_Control_Produccion = datos;
                }.bind(this)).catch(function (error) {
                });
            },
            GuardarControlProduccion: function () {
                this.GenerarGrafico();


                axios.post("/Pronostico/GuardarControlProduccion/", "").then(function (response) {
                    if (response.data.resultado >= 0) {
                        Mensaje('Registro Completo');
                        this.ListaControlPoduccion();
                    }
                }.bind(this)).catch(function (error) {
                });
            },
            ListarPronostico: function () {
                axios.post("/Pronostico/GuardarControlProduccion/", param).then(function (response) {
                    if (response.data.resultado > 0) {
                        alert('Registro Completo');
                    }
                }.bind(this)).catch(function (error) {
                });
            },
            ListaCategoriaProducto: function () {
                var param = { iIdproducto: this.seleccionProducto }
                axios.post("/Categoria/ListaCategoriaProducto/", param).then(function (response) {

                    $.each(response.data, function (k, v) {
                        Pronostico.idCategoria = v.idCategoria;
                        Pronostico.RedInicio = v.RedInicio;
                        Pronostico.RedFin = v.RedFin;
                        Pronostico.YellowInicio = v.YellowInicio;
                        Pronostico.YellowFin = v.YellowFin;
                        Pronostico.GreenInicio = v.GreenInicio;
                        Pronostico.GreenFin = v.GreenFin;
                    });
                }.bind(this)).catch(function (error) {
                });
            },

            Salir: function () {
                window.location.href = "/Home";
            },
            CambioFinRojo: function (v) {
                Pronostico.YellowInicio = v;
            },
            CambioInicioAmarrillo: function () {
                Pronostico.YellowInicio = Pronostico.RedFin;
            },
            CambioFinAmarillo: function (v) {
                Pronostico.GreenInicio = v;
            },
            CambioInicioVerde: function (v) {
                Pronostico.YellowFin = v;
            }

        },
        //computed: {
        //    RedFin: function () {
        //        var dato = 'dd';
        //        return Pronostico.YellowInicio = Pronostico.RedFin;
        //    }
        //},
        created: function () {
            this.seleccionTipoPronostico = parseInt($('#Tipopronostico').val());
            this.seleccionProducto = parseInt($('#Producto').val());
            this.seleccionProveedor = parseInt($('#Proveedor').val());
            this.seleccionIntervalo = parseInt($('#Intervalo').val());
            this.seleccionActividad = parseInt($('#Actividad').val());
            this.RangoPronosticado = parseInt($('#Prediccion').val());
            this.ModificarConulta();


            this.ListarProducto();
            this.ConsultarProveedor();
            this.ListaTipoPronostico();
            this.ListaActividad();
            this.ListaIntervaloVecesProduccion();
            this.ListaCategoriaProducto();
        },
        mounted: function () {
        }
    });
});