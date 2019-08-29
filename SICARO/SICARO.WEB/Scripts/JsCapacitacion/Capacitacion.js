

var Capacitacion = new Vue({
    el: "#app",
    data: {
        Lista_Capacitacion: [],
        Lista_Personal: [],
        Lista_Operarios: [],
        Lista_Preguntas: [],
        OpcionesRespuesta: [],
        tempOpcionesRespuesta: [],
        tempOpcionesRespuestaMultiple: [],
        vCodCapacitacion: "",
        vTemaCapacitacion: "",
        vCodPersonal: "",
        iIdPersonal: 0,
        codPregunta: 1,
        EstadoActualizar: 0,
        NotaMaxima: 20,
        Estado_Almacenamiento_Preguntas: 0,
        Estado_Almacenamiento_Operarios: 0,
        Estado_Ver_Test: 0,
        Latitud: 0,
        Longitud: 0,
        EmpresaE: '',
        RUCE: '',
        TelefonoE: '',
        NombreE: '',
        ApellidoPE: '',
        ApellidoME: '',
        DNIE: '',
        CelularE: '',
    },
    methods: {
        ListaCapacitacion: function () {

            axios.post("/Capacitacion/ListaCapacitacion/").then(function (response) {
                var datos = response.data.ListaCAPACITACION;

                $.each(datos, function (key, val) {
                    var date = new Date(parseInt(val.dFechaPropuestaCapacitacion.substr(6)));
                    var dia = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
                    var mes = date.getMonth() < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
                    var anio = date.getFullYear();
                    var fecha = mes + "/" + dia + "/" + anio;
                    val.dFechaPropuestaCapacitacion = fecha;
                });
                $('#tbCapacitacion').DataTable().destroy();

                $('#tbCapacitacion').DataTable({
                    "data": datos,
                    "columns": [
                        { "data": "vCodCapacitacion" },
                        { "data": "vTemaCapacitacion" },
                        { "data": "dFechaPropuestaCapacitacion" },
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

            }.bind(this)).catch(function (error) {
            });
        },
        CRUDCapacitacion: function () {

            var URL = '';
            var jsonData = {
                iIdCapacitacion: this.iIdCapacitacion,
                vTemaCapacitacion: $('#txtTema').val(),
                dFechaPropuestaCapacitacion: $('#txtFechaCapacitacion').data('date')
            };
            if (this.iIdCapacitacion == 0) {
                URL = '/Capacitacion/RegistrarCapacitacionCabecera/';
            } else {
                URL = '/Capacitacion/ActualizarCapacitacionCabecera/';
            }

            axios.post(URL, jsonData).then(function (response) {
                if (response.data.perosnalizaicon == 1) {
                    Mensaje('La Capacitacion se programo correctamente', 0);
                    this.ListaCapacitacion();
                    $("#ModalCapacitacion").modal('hide');
                } else {
                    Mensaje('Ocurrio un error', 2);
                }
            }.bind(this)).catch(function (error) {
            });
        },
        ListarPersonal: function () {
            axios.post("/Capacitacion/ListaPersonal/").then(function (response) {
                this.Lista_Personal = response.data.ListaPersonal;
            }.bind(this)).catch(function (error) {
            });
        },
        GestionarCapacitacion: function (iIdCapacitacion, vCodCapacitacion, vTemaCapacitacion) {
            var f = new Date();
            var fa = f.getFullYear() + '-' + ('0' + (f.getMonth() + 1)).slice(-2) + '-' + ('0' + f.getDate()).slice(-2);
            this.iIdCapacitacion = iIdCapacitacion;
            this.vCodCapacitacion = vCodCapacitacion;
            this.vTemaCapacitacion = vTemaCapacitacion;
            $('#GESTIONCAPACITACION').removeClass('hide');
            $('#CAPACITACION').addClass('hide');
            this.ListarPersonal();
        },
        MostrarPersonal: function () {
            $("#ModalPersonal").modal('show');
        },
        MostrarPersonalExterno: function () {
            $("#ModalEmpresaExterna").modal('show');
        },
        MostrarCapacitacion: function () {
            this.iIdCapacitacion = 0;
            $("#ModalCapacitacion").modal('show');
        },
        ExpositorSeleccionado: function (vCodPersonal, iIdPersonal) {
            this.vCodPersonal = vCodPersonal;
            this.iIdPersonal = iIdPersonal;
        },
        AceptarExpositor: function () {

            var _Lista_Personal = this.Lista_Personal;
            var _vCodPersonal = this.vCodPersonal;
            var _lista = _Lista_Personal.find(function (val) {
                return (val.vCodPersonal == _vCodPersonal);
            });
            $('#ExpNombre').val(_lista.vNombrePersonal);
            $('#ExpoApePat').val(_lista.vApellidoPaternoPersonal);
            $('#ExpoApeMat').val(_lista.vApellidoMaternoPersonal);
            $("#ModalPersonal").modal('hide');
        },
        PrepararTest: function () {
            this.Estado_Ver_Test = 0;
            $('#ModalTest input').attr('disabled', false);
            $('#ModalTest button').attr('disabled', false);

            $("#ModalTest").modal('show');

        },
        VerTest: function () {
            this.Estado_Ver_Test = 1;
            $("#ModalTest").modal('show');
            $('#ModalTest input').attr('disabled', true);
            $('#ModalTest button').attr('disabled', true);
            $('#ModalTest .btncalcelartest').attr('disabled', false);
            $('#ModalTest input[value = Editar]').attr('disabled', false);


        },
        AgregarOperarios: function () {

            var _vCodPersonal = this.vCodPersonal;

            if (this.vCodPersonal.length != 0) {
                var _Lista_Personal = this.Lista_Personal;
                _Lista_Personal = _Lista_Personal.filter(function (eval) {
                    return eval.vCodPersonal != _vCodPersonal;
                });
                this.Lista_Operarios = _Lista_Personal;
            } else {
                this.Lista_Operarios = this.Lista_Personal;
            }
            $("#ModalOperario").modal('show');
            $('#ModalOperario input').attr('disabled', false);
            $('#ModalOperario button').attr('disabled', false);


        },
        VerOperarios: function () {
            this.Lista_Operarios = this.Lista_Personal;
            $('#ModalOperario input').attr('disabled', true);
            $('#ModalOperario button').attr('disabled', true);
            $('#ModalOperario .cancelaroperarios').attr('disabled', false);
            $("#ModalOperario").modal('show');

        },
        SeleccionarMapa: function () {
            $("#ModalMapa").modal('show');
            var uluru = { lat: -9.563234298135303, lng: -71.63956062343755 };
            var map = new google.maps.Map(document.getElementById('googleMap'), {
                zoom: 6,
                center: uluru
            });

            var marker = new google.maps.Marker({
                position: map.getCenter(),
                map: map,
                draggable: true
            });
            google.maps.event.addListener(marker, 'dragend', function (event) {
                $('#Latitud').text(marker.getPosition().lat());
                $('#Longitud').text(marker.getPosition().lng());
                console.log(this.getPosition().toString());
            });
        },
        GrabarOpcionVF: function () {
            var datos = this.OpcionesRespuesta;
            var _ResTextOpcion = "";
            var _chkEstadoCorrecto = "";
            var _estadovalor = $('input:radio[name=opRespuesta]:checked').val();
            var _codPregunta = this.codPregunta;

            if (this.EstadoActualizar == 0) {
                var list = { "codpregunta": _codPregunta, "Respuesta": _ResTextOpcion, "estado": _chkEstadoCorrecto, "estadovalor": _estadovalor };
                datos.push(list);
                this.OpcionesRespuesta = datos;
            } else {
                _codpregunta = this.EstadoActualizar;
                $.each(datos, function (key, val) {
                    if (val.codpregunta == _codpregunta) {
                        val.Respuesta = _Respuesta;
                        val.Respuesta = _ResTextOpcion;
                        val.estado = _chkEstadoCorrecto;
                        val.estadovalor = _estadovalor;
                    }
                });
            }
            this.OpcionesRespuesta = datos;
        },
        AgregarRespuesta: function () {
            var datos = this.OpcionesRespuesta;
            var _codPregunta = this.codPregunta;

            var _ValidarE = datos.find(function (val) {
                return (val.estadovalor == 1 && val.codpregunta == _codPregunta);
            });
            if (_ValidarE != undefined) {
                MensajeModal('Ya hay una respuesta con la opcion correcta', 2);
                //alert('Ya hay una respuesta con la opcion correcta');
                return;
            }


            var _ResTextOpcion = $('#ResTextOpcion').val().trim();
            var _chkEstadoCorrecto = $('#chkEstadoCorrecto').is(':checked') ? 'Correcto' : 'Incorrecto';
            var _estadovalor = $('#chkEstadoCorrecto').is(':checked') ? 1 : 0;
            if (_ResTextOpcion.length == 0) {
                MensajeModal('Debe ingresar una descripción para la respuesta', 2);
                //alert('Debe ingresar una descripción para la respuesta');
                return;
            }

            var _Validar = datos.find(function (val) {
                return (val.Respuesta == _ResTextOpcion && val.codpregunta == _codPregunta);
            });
            if (_Validar != undefined) {
                MensajeModal('Ya existe una respuesta igual', 2);
                //alert('Ya existe una respuesta igual');
                return;
            }
            var list = { "codpregunta": _codPregunta, "Respuesta": _ResTextOpcion, "estado": _chkEstadoCorrecto, "estadovalor": _estadovalor };
            datos.push(list);
            this.OpcionesRespuesta = datos;

            var _ListaO = [];
            var _ListaO = datos.filter(function (elem) {
                return elem.codpregunta == _codPregunta;
            });
            //$.each(datos, function (k, v) {
            //    if (v.codpregunta == _codPregunta) {
            //        var list = { "codpregunta": v.codpregunta, "Respuesta": v.Respuesta, "estado": v.estado, "estadovalor": v.estadovalor };
            //        _ListaO.push(list);
            //    }
            //});

            this.tempOpcionesRespuesta = _ListaO;


            $('#ResTextOpcion').val('');
            $('#chkEstadoCorrecto').attr('checked', false);
        },
        AgregarRespuestaMultiple: function () {
            var datos = this.OpcionesRespuesta;
            var _codPregunta = this.codPregunta;


            var _ResTextOpcion = $('#ResTextOpcionMultiple').val().trim();
            var _chkEstadoCorrecto = $('#chkEstadoCorrectoMultiple').is(':checked') ? 'Correcto' : 'Incorrecto';
            var _estadovalor = $('#chkEstadoCorrectoMultiple').is(':checked') ? 1 : 0;

            if (_ResTextOpcion.length == 0) {
                MensajeModal('Debe ingresar una descripción para la respuesta', 2);
                //alert('Debe ingresar una descripción para la respuesta');
                return;
            }

            var _Validar = datos.find(function (val) {
                return (val.Respuesta == _ResTextOpcion && val.codpregunta == _codPregunta);
            });
            if (_Validar != undefined) {
                MensajeModal('Ya existe una respuesta igual', 2);
                //alert('Ya existe una respuesta igual');
                return;
            }
            var list = { "codpregunta": _codPregunta, "Respuesta": _ResTextOpcion, "estado": _chkEstadoCorrecto, "estadovalor": _estadovalor };
            datos.push(list);
            this.OpcionesRespuesta = datos;

            var _ListaO = datos.filter(function (elem) {
                return elem.codpregunta == _codPregunta;
            });
            //$.each(datos, function (k, v) {
            //    if (v.codpregunta == _codPregunta) {
            //        var list = { "codpregunta": v.codpregunta, "Respuesta": v.Respuesta, "estado": v.estado, "estadovalor": v.estadovalor };
            //        _ListaO.push(list);
            //    }
            //});

            this.tempOpcionesRespuestaMultiple = _ListaO;


            $('#ResTextOpcionMultiple').val('');
            $('#chkEstadoCorrectoMultiple').attr('checked', false);
        },
        QuitarOpcion: function (Respuesta, codpregunta) {
            if (this.Estado_Ver_Test == 0) {
                var datos = this.OpcionesRespuesta;
                var result = datos.filter(function (elem) {

                    return (elem.Respuesta != Respuesta || elem.codpregunta != codpregunta);
                });
                this.OpcionesRespuesta = result;
                var _ListaO = result.filter(function (elem) {
                    return elem.codpregunta == codpregunta;
                });

                this.tempOpcionesRespuesta = _ListaO;
            }

        },
        QuitarOpcionMultiple: function (Respuesta, codpregunta) {

            if (this.Estado_Ver_Test == 0) {
                var datos = this.OpcionesRespuesta;
                var result = datos.filter(function (elem) {

                    return (elem.Respuesta != Respuesta || elem.codpregunta != codpregunta);
                });
                this.OpcionesRespuesta = result;
                var _ListaO = result.filter(function (elem) {
                    return elem.codpregunta == codpregunta;
                });

                this.tempOpcionesRespuestaMultiple = _ListaO;
            }

        },
        AgregarPregunta: function () {
            if (this.EstadoActualizar == 0) {
                var _Enunciadotest = $('#Enunciadotest').val().trim();
                var _valortest_porcentaje = $('#valortest').val();
                var _valortest = (this.NotaMaxima * _valortest_porcentaje) / 100;

                if (_Enunciadotest.length == 0) {
                    MensajeModal('El enunciado esta vacio, ingrese uno', 2);
                    //alert('El enunciado esta vacio, ingrese uno');
                    return;
                }
                if (_valortest_porcentaje <= 0) {
                    MensajeModal('El valor de esta pregunta no puede ser 0', 2);
                    //alert('El valor de esta pregunta no puede ser 0');
                    return;
                }

                var _optradio = $('input:radio[name=optRespuesta]:checked').val();
                var _TipoRespuesta = $('input:radio[name=optRespuesta]:checked').val() == 1 ? "V/F" : "Opción";

                var _codPregunta = this.codPregunta;
                var datos = this.Lista_Preguntas;




                var _Validar = datos.find(function (val) {
                    return val.Enunciadotest == _Enunciadotest;
                });
                if (_Validar != undefined) {
                    MensajeModal('Ya existe una respuesta igual', 2);
                    //alert('Ya existe una respuesta igual');
                    return;
                };
                var sumatoria_puntos = 0;
                $.each(datos, function (key, val) {
                    sumatoria_puntos = sumatoria_puntos + parseInt(val.valortestPorcentaje);
                });
                if (sumatoria_puntos == 100) {
                    MensajeModal('La suma del valor de las preguntas ya alcanzaron el puntaje maximo', 2);
                    //alert('La suma del valor de las preguntas ya alcanzaron el puntaje maximo');
                    return;
                };
                if ((sumatoria_puntos + parseInt(_valortest_porcentaje)) > 100) {
                    MensajeModal('La suma del valor de las preguntas sobrevasa el puntaje maximo se recomienda un valor de ' + (100 - sumatoria_puntos), 2);
                    //alert('La suma del valor de las preguntas sobrevasa el puntaje maximo se recomienda un valor de ' + (100 - sumatoria_puntos));
                    return;
                };
                if (_optradio == 2) {
                    var datosR = this.OpcionesRespuesta;
                    var _Validar = datosR.find(function (val) {
                        return (val.estadovalor == 1 && val.codpregunta == _codPregunta);
                    });
                    if (_Validar == undefined) {
                        MensajeModal('Debe ingresar una opcion con estado correcto', 2);
                        //alert('Debe ingresar una opcion con estado correcto');
                        return;
                    }

                }

                var lista = { "codpregunta": _codPregunta, "Enunciadotest": _Enunciadotest, "TipoRespuesta": _TipoRespuesta, "optradio": _optradio, "valortestPorcentaje": _valortest_porcentaje, "valortest": _valortest };
                datos.push(lista);

                if (_optradio == 1) {
                    this.GrabarOpcionVF();
                }

                this.codPregunta = _codPregunta + 1;
                this.Lista_Preguntas = datos;

            } else {

                var _codpregunta = this.EstadoActualizar;
                var _Enunciadotest = $('#Enunciadotest').val();
                var _valortest = $('#valortest').val();
                var _optradio = $('input:radio[name=optradio]:checked').val();

                var datos = this.Lista_Preguntas;
                $.each(datos, function (key, val) {
                    if (val.codpregunta == _codpregunta) {
                        val.Enunciadotest = _Enunciadotest;
                        val.valortest = _valortest;
                        val.optradio = _optradio;
                    }
                });
            }
            this.LimpiarFormulario();

        },
        QuitarPregunta: function (codpregunta) {
            var _Lista_Preguntas = this.Lista_Preguntas;
            var _OpcionesRespuesta = this.OpcionesRespuesta;

            _Lista_Preguntas = _Lista_Preguntas.filter(function (val) {
                return val.codpregunta != codpregunta;
            });
            _OpcionesRespuesta = _OpcionesRespuesta.filter(function (val) {
                return val.codpregunta != codpregunta;
            });
            this.Lista_Preguntas = _Lista_Preguntas;
            this.OpcionesRespuesta = _OpcionesRespuesta;



        },
        EditarPeqgunta: function (codpregunta) {

            var _Lista_Preguntas = this.Lista_Preguntas;
            var _OpcionesRespuesta = this.OpcionesRespuesta;

            var _ListaP = _Lista_Preguntas.find(function (val) {
                return val.codpregunta == codpregunta;
            });

            var _ListaO = [];

            $('#Enunciadotest').val(_ListaP.Enunciadotest);
            $('#valortest').val(_ListaP.valortest);

            $('input:radio[name=optradio][value=' + _ListaP.optradio + ']').prop('checked', true);
            if (_ListaP.optradio == 1) {
                $('#tipoRespuestaOpciones').addClass('hide');
                $('#tipoRespuestaVF').removeClass('hide');
                _ListaO = _OpcionesRespuesta.find(function (val) {
                    return val.codpregunta == codpregunta;
                });
                $('input:radio[name=opRespuesta][value=' + _ListaO.estadovalor + ']').prop('checked', true);


            } else if (_ListaP.optradio == 2) {
                $('#tipoRespuestaVF').addClass('hide');
                $('#tipoRespuestaOpciones').removeClass('hide');

                $.each(_OpcionesRespuesta, function (k, v) {
                    if (v.codpregunta == codpregunta) {
                        var list = { "codpregunta": v.codpregunta, "Respuesta": v.Respuesta, "estado": v.estado, "estadovalor": v.estadovalor };
                        _ListaO.push(list);
                    }
                });
                this.tempOpcionesRespuesta = _ListaO;
            }


            $('#btnAgregarPregunta').text('Actualizar Pregunta');
            $('#btnCancelarPregunta').removeClass('hide');
            this.EstadoActualizar = _ListaP.codpregunta;



        },
        CancelarPregunta: function () {
            this.LimpiarFormulario();
        },
        LimpiarFormulario: function () {
            $('#Enunciadotest').val('');
            $('#valortest').val(0);
            this.EstadoActualizar = 0;
            $('#btnCancelarPregunta').addClass('hide');
            $('#btnAgregarPregunta').text('Agregar Pregunta');
            this.tempOpcionesRespuesta = [];
        },
        GrabarPreguntas: function () {
            this.ValidarCantidadPreguntas();

            this.Estado_Almacenamiento_Preguntas = 1;
            $("#ModalTest").modal('hide');
        },
        CancelarPreguntas: function () {
            $("#ModalTest").modal('hide');
            this.Estado_Almacenamiento_Preguntas = 0;
        },
        GrabarOperarios: function () {
            this.Estado_Almacenamiento_Operarios = 1;
            $("#ModalOperario").modal('hide');
        },
        CancelarOperarios: function () {
            this.Estado_Almacenamiento_Operarios = 0;
            $("#ModalOperario").modal('hide');
        },
        GrabarCapacitacion: function () {

            var _horarinicio = $('#horarinicio').data('date');
            var _horartermino = $('#horartermino').data('date');
            if (_horartermino <= _horarinicio) {
                Mensaje("La hora final es mayor a la hora de inicio", 0);
                //alert("La hora final es mayor a la hora de inicio");
                return;
            }
            if ($('#ExpNombre').val().trim() == '') {
                Mensaje("Ingrese un expositor", 0);
                //alert("Ingrese un expositor");
                return;
            }


            this.ValidarCantidadPreguntas();
            //debugger;
            //if ($('input[name="optRespuesta"]:checked').val() == 1) {
            //    this.iIdCapacitacion = 1;
            //}

            var GestionCapacitacion = {
                'iIdCapacitacion': this.iIdCapacitacion,
                'iIdRepresentante': this.iIdPersonal,
                'dFechaRealizacionCapacitacion': $('#dfecha').data('date'),
                'tHoraInicio': $('#horarinicio').data('date'),// $('#horarinicio').val(),
                'tHoraFin': $('#horartermino').data('date'),//$('#horartermino').val(),
                'iTiempoTest': $('#tiempotest').val(),
                'nLatitud': $('#Latitud').text() == "0" ? "-76.96249462061785" : $('#Latitud').text(),
                'nLongitud': $('#Longitud').text() == "0" ? "-12.130453115407523" : $('#Longitud').text()
            }

            var _Lista_Preguntas = this.Lista_Preguntas;
            var _Preguntas = [];
            $.each(_Lista_Preguntas, function (key, val) {
                var dato = {
                    "iIdPregunta": parseInt(val.codpregunta),
                    "vEnunciadoPregunta": val.Enunciadotest,
                    "iPuntajePregunta": val.valortest,
                    "iTipoRespuestaPregunta": val.optradio
                };
                _Preguntas.push(dato);
            });

            var _OpcionesRespuesta = this.OpcionesRespuesta;
            var _Respuestas = [];
            $.each(_OpcionesRespuesta, function (key, val) {
                var dato = {
                    "iIdPregunta": parseInt(val.codpregunta),
                    "vEnunciadoOpcion": val.Respuesta,
                    "iEstadoOpcion": val.estadovalor
                };
                _Respuestas.push(dato);
            });


            var jsonData = { GestionCapacitacion: GestionCapacitacion, _Preguntas: _Preguntas, _Respuestas: _Respuestas };
            axios.post("/Capacitacion/RegistrarCapacitacion/", jsonData).then(function (response) {
                if (response.data.perosnalizaicon == 1) {
                    Mensaje('La Capacitacion se programo correctamente', 0);
                    //alert('La Capacitacion se programo correctamente');
                    //this.Estado_Almacenamiento_Preguntas = 0;
                    //this.Estado_Almacenamiento_Operarios = 0;
                    $('#GESTIONCAPACITACION').addClass('hide');
                    $('#CAPACITACION').removeClass('hide');
                } else {
                    Mensaje('Ocurrio un error', 2);
                    //alert('Ocurrio un error');
                }

            }.bind(this)).catch(function (error) {
            });
        },
        CancelarCapacitacion: function () {
            $('#CAPACITACION').removeClass('hide');
            $('#GESTIONCAPACITACION').addClass('hide');
        },
        ValidarCantidadPreguntas: function () {
            var datos = this.Lista_Preguntas;
            var sumatoria_puntos = 0;
            $.each(datos, function (key, val) {
                sumatoria_puntos = sumatoria_puntos + parseInt(val.valortestPorcentaje);
            });
            if (sumatoria_puntos < 100) {

                alert('El valor de las preguntas debe llegar al 100%');
                this.Estado_Almacenamiento_Preguntas = 0;
                return;
            };
        },
        TipoRespuestas: function () {
            if ($('input[name="optRespuesta"]:checked').val() == 1) {
                $('#tipoRespuestaVF').removeClass('hide');
                $('#tipoRespuestaOpciones').addClass('hide');
                $('#tipoRespuestaOpcionesMultiple').addClass('hide');
            } else if ($('input[name="optRespuesta"]:checked').val() == 2) {
                $('#tipoRespuestaVF').addClass('hide');
                $('#tipoRespuestaOpciones').removeClass('hide');
                $('#tipoRespuestaOpcionesMultiple').addClass('hide');
            } else if ($('input[name="optRespuesta"]:checked').val() == 3) {
                $('#tipoRespuestaVF').addClass('hide');
                $('#tipoRespuestaOpciones').addClass('hide');
                $('#tipoRespuestaOpcionesMultiple').removeClass('hide');
            }
        },
        GrabarExpositorExterno: function () {

            $('#ExpNombre').val(this.NombreE);
            $('#ExpoApePat').val(this.ApellidoPE);
            $('#ExpoApeMat').val(this.ApellidoME);
            $("#ModalEmpresaExterna").modal('hide');
        },
    },
    computed: {},
    created: function () {
        this.ListaCapacitacion();
    },
    mounted: function () {
    }
})

$("#tbCapacitacion").on("click", "button.Gestionar", function () {

    var table = $('#tbCapacitacion').DataTable();
    var data = null;
    if (table.row(this).child.isShown()) {
        data = table.row(this).data();
    } else {
        data = table.row($(this).parents("tr")).data();
    }

    Capacitacion.GestionarCapacitacion(data["iIdCapacitacion"], data["vCodCapacitacion"], data["vTemaCapacitacion"]);
});

$("#tbCapacitacion").on("click", "button.Editar", function () {

    var table = $('#tbCapacitacion').DataTable();
    var data = null;
    data = table.row($(this).parents("tr")).data();

    Capacitacion.iIdCapacitacion = data["iIdCapacitacion"];
    $('#txtTema').val(data["vTemaCapacitacion"]);
    $('#txtCodigo').val(data["vCodCapacitacion"]);    
    $("#txtFechaCapacitacion").datetimepicker("setDate", new Date(data["dFechaPropuestaCapacitacion"]));
    $("#ModalCapacitacion").modal('show');

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

$('#horarinicio').datetimepicker({
    language: 'es',
    weekStart: 1,
    todayBtn: 1,
    autoclose: 1,
    todayHighlight: 1,
    startView: 1,
    minView: 0,
    maxView: 1,
    forceParse: 0
});

$('#horartermino').datetimepicker({
    language: 'es',
    weekStart: 1,
    todayBtn: 1,
    autoclose: 1,
    todayHighlight: 1,
    startView: 1,
    minView: 0,
    maxView: 1,
    forceParse: 0
});

$('#txtFechaCapacitacion').datetimepicker({
    language: 'es',
    weekStart: 1,
    todayBtn: 1,
    autoclose: 1,
    todayHighlight: 1,
    startView: 2,
    minView: 2,
    forceParse: 0

});