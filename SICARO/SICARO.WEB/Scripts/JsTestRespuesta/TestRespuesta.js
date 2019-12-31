﻿

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
                            $.each(response.data.ListaOpciones, function (keyR, valR) {

                                if (val.iIdPregunta == valR.iIdPregunta) {
                                    _html = _html + '<div class="col-sm-12 text-center _Examen">';
                                    if (valR.iEstadoOpcion == 1) {
                                        _html = _html + '<label class="radio-inline"><input type="radio" class="radio" name="pregunta' + val.iIdPregunta + '" value="1" checked disabled>Verdadero</label>';
                                        _html = _html + '<label class="radio-inline"><input type="radio" class="radio" name="pregunta' + val.iIdPregunta + '" value="0" disabled>Falso</label>';
                                    } else {
                                        _html = _html + '<label class="radio-inline"><input type="radio" class="radio" name="pregunta' + val.iIdPregunta + '" value="1" disabled>Verdadero</label>';
                                        _html = _html + '<label class="radio-inline"><input type="radio" class="radio" name="pregunta' + val.iIdPregunta + '" value="0" checked disabled>Falso</label>';
                                    }
                                    _html = _html + '</div>';
                                }
                            });
                            break;
                        case 2:
                            _html = _html + '<div class="col-sm-12 text-center _Examen">';
                            var bEstado = "checked";
                            $.each(response.data.ListaOpciones, function (k, v) {                                
                                if (val.iIdPregunta == v.iIdPregunta) {
                                    bEstado = v.iEstadoOpcion == 1 ? "checked" : "";
                                    _html = _html + '<label class="radio-inline"><input type="radio" class="radio" name="pregunta' + val.iIdPregunta + '" value="' + v.iIdOpcion + '" ' + bEstado + ' disabled >' + v.vEnunciadoOpcion + '</label>';
                                }
                            });
                            _html = _html + '</div>'; break;
                        case 3:
                            _html = _html + '<div class="col-sm-12 text-center _Examen">';
                            var bEstado = "checked";
                            $.each(response.data.ListaOpciones, function (k, v) {
                                if (val.iIdPregunta == v.iIdPregunta) {
                                    bEstado = v.iEstadoOpcion == 1 ? "checked" : "";
                                    _html = _html + '<label class="checkbox-inline"><input type="checkbox" name="pregunta' + val.iIdPregunta + '" value="' + v.iIdOpcion + '" ' + bEstado + ' disabled>' + v.vEnunciadoOpcion + '</label>';
                                }
                            });
                            _html = _html + '</div>'; break;
                        default: _html += ''; break;
                    }

                });
                $('#PMuestra').addClass('hide');
                $('#PTest').removeClass('hide');
                $('#PContenido').html(_html);
                //Minutos.innerHTML = ":" + this.minutos;
                //if (this.minutos < 10) { this.minutos = "0" + this.minutos }
                //Minutos.innerHTML = ":" + this.minutos;
                //control = setInterval(this.cronometro, 1000);

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

            $('#PMuestra').addClass('hide');
            $('#PTest').addClass('hide');
            $('#PFinal').removeClass('hide');

            var _Lista_Preguntas = this.Lista_Preguntas;
            var _Lista_Opciones = this.Lista_Opciones;

            var _puntaje = 0;
            var _Detalle = [];
            $.each(_Lista_Preguntas, function (key, val) {
                $.each(_Lista_Opciones, function (keyR, valR) {
                    if (val.iIdPregunta == valR.iIdPregunta) {

                        var _optradio = $('input:radio[name=pregunta' + val.iIdPregunta + ']:checked').val();
                        _optradio = _optradio == undefined ? -1 : _optradio;
                        var _SubDetalle = {};
                        if (valR.iEstadoOpcion == _optradio) {
                            _puntaje = _puntaje + val.iPuntajePregunta;
                            _SubDetalle = {
                                "iIdPregunta": valR.iIdPregunta,
                                "iIdOpcion": valR.iIdOpcion,
                                "iEstadoRespuesta": 1,
                            }
                        } else {
                            _SubDetalle = {
                                "iIdPregunta": valR.iIdPregunta,
                                "iIdOpcion": valR.iIdOpcion,
                                "iEstadoRespuesta": 0,
                            }
                        }
                        _Detalle.push(_SubDetalle);
                    }
                });
            });
            debugger;
            var parametros = {
                iPuntajePersonal: _puntaje
            }

            var jsonData = { parametros: parametros, Detalle_Capacitacion: _Detalle };

            $('#PMuestra').addClass('hide');
            $('#PTest').addClass('hide');
            $('#PFinal').removeClass('hide');
            axios.post("/TestEvaluacion/RegistrarTest/", jsonData).then(function (response) {
                if (response.data.respuesta > 0) {
                    alert("Se grabo correctamente la respuesta");
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