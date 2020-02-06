

new Vue({
    el: "#app",
    data: {
        Lista_Preguntas: [],
        Lista_Opciones: [],
        vCodCapacitacion: "",
        vTemaCapacitacion: "",
        centesimas: 0,
        segundos: 60,
        minutos: 30,
        horas: 0,
    },
    methods: {
        EmpezarEvaluacion: function () {

            axios.post("/TestEvaluacion/GenerarCamposCapacitacion/").then(function (response) {
                this.Lista_Preguntas = response.data.ListaPregunta;
                this.Lista_Opciones = response.data.ListaOpciones;
                var _html = "";

                this.minutos = parseInt(this.Lista_Preguntas[0].iUsuarioCrea) - 1;

                $.each(response.data.ListaPregunta, function (key, val) {
                    _html = _html +
                        '<div class="col-sm-12 text-center">' +
                        "<h3>" + (key + 1) + ".- " + val.vEnunciadoPregunta + "</h3></div>";
                    switch (val.iTipoRespuestaPregunta) {
                        case 1:
                            _html = _html +
                        '<div class="col-sm-12 text-center _Examen">' +
                        '<label class="radio-inline"><input type="radio" class="radio" name="pregunta' + val.iIdPregunta + '" value="1">Verdadero</label>' +
                        '<label class="radio-inline"><input type="radio" class="radio" name="pregunta' + val.iIdPregunta + '" value="0">Falso</label>' +
                        '</div>';
                            break;
                        case 2:
                            _html = _html + '<div class="col-sm-12 text-center _Examen">';
                            $.each(response.data.ListaOpciones, function (k, v) {
                                if (val.iIdPregunta == v.iIdPregunta) {
                                    _html = _html + '<label class="radio-inline"><input type="radio" class="radio" name="pregunta' + val.iIdPregunta + '" value="' + v.iIdOpcion + '">' + v.vEnunciadoOpcion + '</label>';
                                }
                            });
                            _html = _html + '</div>'; break;
                        case 3:
                            _html = _html + '<div class="col-sm-12 text-center _Examen">';
                            $.each(response.data.ListaOpciones, function (k, v) {
                                if (val.iIdPregunta == v.iIdPregunta) {
                                    _html = _html + '<label class="checkbox-inline"><input type="checkbox" name="pregunta' + val.iIdPregunta + '" value="' + v.iIdOpcion + '">' + v.vEnunciadoOpcion + '</label>';
                                }
                            });
                            _html = _html + '</div>'; break;
                        default: _html += ''; break;
                    }
                });
                $('#PMuestra').addClass('hide');
                $('#PTest').removeClass('hide');
                $('#PContenido').html(_html);
                Minutos.innerHTML = ":" + this.minutos;
                if (this.minutos < 10) { this.minutos = "0" + this.minutos }
                Minutos.innerHTML = ":" + this.minutos;
                control = setInterval(this.cronometro, 1000);

            }.bind(this)).catch(function (error) {
            });
        },
        cronometro: function () {
            if (this.centesimas == 0) {
                this.segundos--;
                if (this.segundos < 10) { this.segundos = "0" + this.segundos }
                Segundos.innerHTML = ":" + this.segundos;
            }
            if (this.segundos == 0) {
                this.segundos = 61;
            }
            if ((this.centesimas == 0) && (this.segundos == 61)) {
                if ((this.centesimas == 0) && (this.segundos == 61) && (this.minutos == 0)) {

                    clearInterval(control);


                    this.GuardarRespuestas();
                    return;
                }
                this.minutos--;
                if (this.minutos < 10) { this.minutos = "0" + this.minutos }

                Minutos.innerHTML = ":" + this.minutos;
            }
        },
        GuardarRespuestas: function () {

            //$('#PMuestra').addClass('hide');
            //$('#PTest').addClass('hide');
            //$('#PFinal').removeClass('hide');

            var _Lista_Preguntas = this.Lista_Preguntas;
            var _Lista_Opciones = this.Lista_Opciones;

            var _puntaje = 0;
            var _Detalle = [];


            var _SubDetalle = {};

            $.each(_Lista_Preguntas, function (key, val) {
                
                switch (val.iTipoRespuestaPregunta) {
                    case 1:
                        var _VF = _Lista_Opciones.find(function (valI) {
                            return (valI.iIdPregunta == val.iIdPregunta);
                        });
                        var _optradio = $('input:radio[name=pregunta' + val.iIdPregunta + ']:checked').val();
                        _optradio = _optradio == undefined ? -1 : _optradio;
                        if (_VF.iEstadoOpcion == _optradio) {
                            _puntaje +=  val.iPuntajePregunta;
                        }

                        ; break;
                    case 2:
                        var _Respuestas = _Lista_Opciones.find(x => x.iIdPregunta == val.iIdPregunta && x.iEstadoOpcion == 1);
                        var _iIdOpcion = $('input:radio[name="pregunta' + val.iIdPregunta + '"]:checked').val();
                        if (_Respuestas.iIdOpcion == _iIdOpcion) {
                            _puntaje +=  val.iPuntajePregunta;
                        }
                        ; break;
                    case 3:
                        var _RespuestasMultiple = $.grep(_Lista_Opciones,function (valI) {
                            return (valI.iIdPregunta == val.iIdPregunta && valI.iEstadoOpcion == 1);
                        });
                        var CantidadRespuestas = 0;
                        var CantidadRespuestasMarcadas = 0;
                        CantidadRespuestasMarcadas = $('input:checkbox[name="pregunta' + val.iIdPregunta + '"]:checked').length;
                        $.each(_RespuestasMultiple, function (KeyM, ValM) {
                            $('input:checkbox[name="pregunta' + val.iIdPregunta + '"]:checked').each(function (KeyMR, ValMR) {
                                if (ValM.iIdOpcion == ValMR.value) {
                                    CantidadRespuestas++;
                                }
                            });
                        });

                        if (_RespuestasMultiple.length == CantidadRespuestas && CantidadRespuestasMarcadas == CantidadRespuestas) {
                            _puntaje += val.iPuntajePregunta;
                        }
                        ; break;
                    default:
                }


                _Detalle.push(_SubDetalle);
                //$.each(_Lista_Opciones, function (keyR, valR) {
                //    if (val.iIdPregunta == valR.iIdPregunta) {


                // Evaluar para la insercion del detalle personal capacitacion
                //var _optradio = $('input:radio[name=pregunta' + val.iIdPregunta + ']:checked').val();
                //_optradio = _optradio == undefined ? -1 : _optradio;

                //if (valR.iEstadoOpcion == _optradio) {
                //    _puntaje = _puntaje + val.iPuntabjePregunta;
                //    _SubDetalle = {
                //        "iIdPregunta": valR.iIdPregunta,
                //        "iIdOpcion": valR.iIdOpcion,
                //        "iEstadoRespuesta": 1,
                //    }
                //} else {
                //    _SubDetalle = {
                //        "iIdPregunta": valR.iIdPregunta,
                //        "iIdOpcion": valR.iIdOpcion,
                //        "iEstadoRespuesta": 0,
                //    }
                //}
                //    }
                //});
            });
            var parametros = {
                iPuntajePersonal: _puntaje
            }

            var jsonData = { parametros: parametros, Detalle_Capacitacion: _Detalle };
            $('#PMuestra').addClass('hide');
            $('#PTest').addClass('hide');
            $('#PFinal').removeClass('hide');
            axios.post("/TestEvaluacion/RegistrarTest/", jsonData).then(function (response) {
                if (response.data.respuesta > 0) {
                    Mensaje("Se grabo correctamente la respuesta", 0);
                }
            }.bind(this)).catch(function (error) {
            });
        }
    },
    computed: {},
    created: function () {
    },
    mounted: function () {
    }
})