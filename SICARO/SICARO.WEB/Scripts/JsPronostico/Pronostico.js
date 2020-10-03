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
            GreenInicio: 0,
            GreenFin: 35,
            YellowInicio: 35,
            YellowFin: 70,
            RedInicio: 70,
            RedFin: 100,
            RangoPronosticado: 20,
            seleccionTipoPronostico: '0',
            seleccionProducto: '0',
            seleccionMateriaPrima: '0',
            seleccionProveedor: '0',
            seleccionIntervalo: '0',
            seleccionActividad: '0',
            ProductoMateria: true,
            EnviarCorreo: true,
        },
        methods: {
            ListarProducto: function () {

                var data = { iIdproducto: 0 }
                axios.post("/Producto/ListarProducto/", data).then(function (response) {
                    this.Lista_Producto = response.data;
                }.bind(this)).catch(function (error) {
                });
            },
            ListarMateriaPrima: function () {

                axios.post("/Predicciones/ListaMateriaPrima/", "").then(function (response) {
                    if (response.data.ListaMATERIA_PRIMA > 0) {
                        alert(response.data);
                    }
                    this.Lista_Materia_Prima = response.data.ListaMATERIA_PRIMA;
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
                        $('.divproveedor').show();
                        //$('.divUnidadMedida').show();
                        $('.divIntervaloProduccion').show();
                        $('.divActividad').hide();
                        this.ProductoMateria = false;
                        break;

                    case 2:
                        $('.divproveedor').show();
                        //$('.divUnidadMedida').show();
                        $('.divIntervaloProduccion').hide();
                        $('.divActividad').hide();
                        this.ProductoMateria = true;
                        break;
                    case 3:
                        $('.divproveedor').hide();
                        //$('.divUnidadMedida').hide();
                        $('.divIntervaloProduccion').hide();
                        $('.divActividad').show();
                        this.ProductoMateria = false;
                        break;
                    case 4:
                        $('.divproveedor').show();
                        //$('.divUnidadMedida').show();
                        $('.divIntervaloProduccion').hide();
                        $('.divActividad').hide();
                        this.ProductoMateria = false;
                        break;
                }

                $('#ddlPronostico').prop('disabled', true);
                $('#slProducto').prop('disabled', true);
                $('#slMateriaPrima').prop('disabled', true);
                $('#slProveedor').prop('disabled', true);
                $('#slActividad').prop('disabled', true);
                $('#slIntervaloUtilizadoProduccion').prop('disabled', true);
                $('#btnActualizarIntervalos').addClass('hide');

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
            ConsultarMateriaPrimaProveedor: function () {

                var iIdMateriaPrima = this.seleccionMateriaPrima;
                var jsonData = { iIdMateriaPrima: iIdMateriaPrima };
                axios.post("/Predicciones/ListaMateriaPrimaProveedor/", jsonData).then(function (response) {
                    this.Lista_Proveedor = response.data.ListaMATERIA_PRIMAProveedor;
                }.bind(this)).catch(function (error) {
                });
            },
            MostrarConfiguracionIntervalo: function () {
                $('#ConfiguracionIntervalos').attr('style', 'display:block');
            },
            OcultarConfiguracionIntervalo: function () {

                var jsonData = {
                    GreenInicio: this.GreenInicio,
                    GreenFin: this.GreenFin,
                    YellowInicio: this.YellowInicio,
                    YellowFin: this.YellowFin,
                    RedInicio: this.RedInicio,
                    RedFin: this.RedFin,
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

                $('.resultado').removeClass('active');
                $('.' + lista.idControlProduccion).addClass('active');
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
                        val.idControlProduccion = val.Color + '_' + val.idControlProduccion;
                    });
                    this.Lista_Control_Produccion = datos;
                }.bind(this)).catch(function (error) {
                });
            },
            GuardarControlProduccion: function () {
                this.GenerarGrafico();

                var date = new Date();
                var dia = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
                var mes = date.getMonth() < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
                var anio = date.getFullYear();
                var fecha = dia + "/" + mes + "/" + anio;
                var hora = date.getHours() + ':' + date.getMinutes();

                var Correo = "";

                var Color = '';
                if (Pronostico.RedInicio <= Pronostico.RangoPronosticado && Pronostico.RangoPronosticado < Pronostico.RedFin) {
                    Color = 'Rojo';
                } else if (Pronostico.YellowInicio <= Pronostico.RangoPronosticado && Pronostico.RangoPronosticado < Pronostico.YellowFin) {
                    Color = 'Amarillo';
                } else if (Pronostico.GreenInicio <= Pronostico.RangoPronosticado && Pronostico.RangoPronosticado < Pronostico.GreenFin) {
                    Color = 'Verde';
                }

                var producto_materiaprima = ''
                var CuartoTexto = '';
                if (this.ProductoMateria) {
                    producto_materiaprima = 'Producto: ' + $('#slProducto option:selected').text() + '<br />';
                } else {
                    producto_materiaprima = 'Materia Prima: ' + $('#slMateriaPrima option:selected').text() + '<br />';
                }

                switch (this.seleccionTipoPronostico) {
                    case 1: CuartoTexto = 'Intervalo de veces utilizado en producción: ' + $('#slIntervaloUtilizadoProduccion option:selected').text(); break;
                    case 2: CuartoTexto = ''; break;
                    case 3: CuartoTexto = 'Actividad de producción: ' + $('#slActividad option:selected').text(); break;
                    case 4: CuartoTexto = ''; break;
                }

                correo = 'Estimado Presidente de Calidad, <br /><br />' +
                         'Usted esta recibiendo este correo debido a que la alarma del indicador de pronosticos del sistema ICARO detecto el ' + fecha + ' a las ' + hora + ' : <br /><br />' +
                         'Que el indicador marco el color ' + Color + '; en la predicción de valor ' + Pronostico.RangoPronosticado + '<br /><br />' +
                         'Detalle de la Alarma: <br /><br />' +
                         'Tipo de pronostico: ' + $('#ddlPronostico option:selected').text() + '<br />' +
                         producto_materiaprima +
                         'Proveedor: ' + $('#slProveedor option:selected').text() + '<br />' +
                         CuartoTexto + '<br /><br /><br />' +
                         'Por favor no responda a este correo; si usted tiene dudas contactar con el correo : sys.icaro@gmail.com <br />' +
                         'Saludos';


                var param = {
                    CorreoContenido: this.EnviarCorreo ? correo : '',
                }

                axios.post("/Pronostico/GuardarControlProduccion/", param).then(function (response) {
                    if (response.data.resultado >= 0) {
                        
                        if (this.EnviarCorreo) {
                            Mensaje('El correo fue enviado con exito al Presidente de Calidad', 0);
                        }
                        this.EnviarCorreo = false;
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
                        Pronostico.GreenInicio = v.GreenInicio;
                        Pronostico.GreenFin = v.GreenFin;
                        Pronostico.YellowInicio = v.YellowInicio;
                        Pronostico.YellowFin = v.YellowFin;
                        Pronostico.RedInicio = v.RedInicio;
                        Pronostico.RedFin = v.RedFin;
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
            CambioInicioAmarrillo: function (v) {
                Pronostico.RedFin = v;
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
            this.seleccionMateriaPrima = parseInt($('#Producto').val());
            this.seleccionProveedor = parseInt($('#Proveedor').val());
            this.seleccionIntervalo = parseInt($('#Intervalo').val());
            this.seleccionActividad = parseInt($('#Actividad').val());
            this.RangoPronosticado = parseInt($('#Prediccion').val());
            this.ModificarConulta();


            this.ListarProducto();
            this.ListarMateriaPrima();
            if (this.ProductoMateria) {
                this.ConsultarProveedor();
            } else {
                this.ConsultarMateriaPrimaProveedor();
            }
            this.ListaTipoPronostico();
            this.ListaActividad();
            this.ListaIntervaloVecesProduccion();
            this.ListaCategoriaProducto();
        },
        mounted: function () {
        }
    });
});