

var Capacitacion = new Vue({
    el: "#app",
    data: {
        Lista_Capacitacion: [],
        Lista_Personal: [],
        Lista_Operarios: [],
        Lista_OperariosVisualizar: [],
        Lista_Preguntas: [],
        OpcionesRespuesta: [],
        tempOpcionesRespuesta: [],
        tempOpcionesRespuestaMultiple: [],
        dEstadoCapacitacion: [],
        Capacitacion_Personal: [],
        dTipoDocumento: [],
        vCodCapacitacion: "",
        vTemaCapacitacion: "",
        vCodPersonal: "",
        iIdPersonal: 0,
        iIdPregunta: -100,
        EstadoActualizar: 0,
        NotaMaxima: 20,
        Estado_Almacenamiento_Preguntas: 0,
        Estado_Almacenamiento_Operarios: 0,
        Estado_Ver_Test: 0,
        Latitud: -12.116283123011357,
        Longitud: -77.02498571422734,
        EmpresaE: '',
        RUCE: '',
        TelefonoE: '',
        NombreE: '',
        ApellidoPE: '',
        ApellidoME: '',
        DNIE: '',
        CelularE: '',
        selectedDocumento: '0',
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
        ListaCapacitacion: function () {

            axios.post("/Capacitacion/ListaCapacitacion/").then(function (response) {
                var datos = response.data.ListaCAPACITACION;
                this.Lista_Capacitacion = response.data.ListaCAPACITACION;
                $.each(datos, function (key, val) {
                    var date = new Date(parseInt(val.dFechaPropuestaCapacitacion.substr(6)));
                    var dia = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
                    var mes = date.getMonth() < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
                    var anio = date.getFullYear();
                    var fecha = dia + "/" + mes + "/" + anio;
                    val.dFechaPropuestaCapacitacion = fecha;
                });
                $('#tbCapacitacion').DataTable().destroy();

                var d = new Date();
                var strDate = d.getDate() + "/" + (d.getMonth() < 10 ? "0" + (d.getMonth() + 1) : d.getMonth() + 1) + "/" + d.getFullYear();

                $('#tbCapacitacion').DataTable({
                    "data": datos,
                    "columns": [
                        { "data": "vCodCapacitacion" },
                        { "data": "vTemaCapacitacion" },
                        { "data": "dFechaPropuestaCapacitacion" },
                        {
                            render: function (j, k, r) { 
                                var Estado = '';
                                $.each(Capacitacion.dEstadoCapacitacion, function (key, val) {
                                    if (val.co_codigo == r['iEstadoCapactiacion']) {
                                        Estado = val.de_tabla;
                                    }
                                });
                                return Estado;
                            }
                        },
                        {
                            render: function (j, k, r) {
                                if (r['iEstadoCapactiacion'] == '3' /*|| r['dFechaPropuestaCapacitacion'] < strDate*/) {
                                    return '';
                                } else {
                                    return '<button type="button" id="ButtonGestionar" class="Gestionar edit-modal btn btn-succes botonGestionar"><span class="glyphicon glyphicon-wrench"></span></button>';
                                }

                            }
                        },
                        {
                            render: function (j, k, r) {
                                if (r['iEstadoCapactiacion'] == '3') {
                                    return '';
                                } else {
                                    return '<button type="button" id="ButtonEditar" class="Editar edit-modal btn btn-warning botonEditar"><span class="glyphicon glyphicon-pencil"></span></button>';
                                }
                            }
                        },

                    ],
                });

            }.bind(this)).catch(function (error) {
            });
        },
        ListaEstadoCapacitacion: function () {
            var data = {
                co_tabla: 5
            };
            axios.post('/TGeneral/CargaTGeneral', data).then(response => {
                this.dEstadoCapacitacion = response.data;
                this.ListaCapacitacion();
            }).catch(error => {
                console.log(error);
                this.errored = true;
            });
        },
        ListaExpositorExterno: function (Codigo) {
            var data = {
                val: Codigo
            };
            axios.post('/Capacitacion/ListaExpositorExterno', data).then(response => {
                var ListaEE = response.data.ListaEE;
                $('#txtEmpresa').val(ListaEE[0]["NombreEmpresa"]);
                $('#txtRUC').val(ListaEE[0]["RUC"]);
                $('#txtTelefono').val(ListaEE[0]["Telefono"]);
                $('#txtExpositorE').val(ListaEE[0]["NombreExpositor"]);
                $('#txtApellidoPE').val(ListaEE[0]["ApellidoPaternoExpositor"]);
                $('#txtApellidoME').val(ListaEE[0]["ApellidoMaternoExpositor"]);
                $('#cboTipoDocumentoModal').val(ListaEE[0]["TipoDocumentoExpositor"]);
                $('#txtNroDocumentoModal').val(ListaEE[0]["NroDocumentoExpositor"]);
                $('#txtCelular').val(ListaEE[0]["TelefonoExpositor"]);

                $('#ExpNombre').val(ListaEE[0]["NombreExpositor"]);
                $('#ExpoApePat').val(ListaEE[0]["ApellidoPaternoExpositor"]);
                $('#ExpoApeMat').val(ListaEE[0]["ApellidoMaternoExpositor"]);
                $('#ExpoDNI').val(ListaEE[0]["NroDocumentoExpositor"]);

            }).catch(error => {
                console.log(error);
                this.errored = true;
            });
        },
        CRUDCapacitacion: function () {

            var fechaCapacitacion = $('#txtFechaCapacitacion').data('date');

            if ($('#txtTema').val().trim() == '') {
                Mensaje('El tema es obligatorio', 1);
                return;
            }

            if (fechaCapacitacion == undefined) {
                Mensaje('La fecha no tiene el formato correcto', 1);
                return;
            }

            //var d = new Date();
            //var end = d.getDate() + "/" + (d.getMonth() + 1) + "/" + d.getFullYear();

            //var start = new Date(fechaCapacitacion);
            //var end = new Date();
            //days = (end - fechaCapacitacion ) / (1000 * 60 * 60 * 24);
            //var dias = Math.round(days);
            //Descomentar al subir al servidor
            //fechaCapacitacion = fechaCapacitacion.substr(3, 2) + "/" + fechaCapacitacion.substr(0, 2) + "/" + fechaCapacitacion.substr(6, 10);

            var URL = '';
            var jsonData = {
                iIdCapacitacion: this.iIdCapacitacion,
                vTemaCapacitacion: $('#txtTema').val(),
                dFechaPropuestaCapacitacion: fechaCapacitacion,
                iEstadoCapactiacion: $('#cboEstadoCapacitacion').val(),
            };
            if (this.iIdCapacitacion == 0) {
                URL = '/Capacitacion/RegistrarCapacitacionCabecera/';
            } else {
                URL = '/Capacitacion/ActualizarCapacitacionCabecera/';
            }

            axios.post(URL, jsonData).then(function (response) {
                if (response.data.respuesta.codigo >=0) {
                    Mensaje('La Capacitacion se programo correctamente', 0);
                    this.ListaCapacitacion();
                    $("#ModalCapacitacion").modal('hide');
                } else {
                    Mensaje(response.data.respuesta.Mensaje, 2);
                }
            }.bind(this)).catch(function (error) {
            });
        },
        ListarPersonal: function (val) {
            axios.post("/Capacitacion/ListaPersonal/", { val: val }).then(function (response) {
                var data = response.data.ListaPersonal;
                if (val == 0) {
                    this.Lista_Personal = data
                    this.ListarGestionCapacitacion();
                } else {
                    this.iIdPersonal = data[0]['iIdPersonal'];
                    $('#ExpNombre').val(data[0]['vNombrePersonal']);
                    $('#ExpoApePat').val(data[0]['vApellidoPaternoPersonal']);
                    $('#ExpoApeMat').val(data[0]['vApellidoMaternoPersonal']);
                    $('#ExpoDNI').val(data[0]['NroDocumento']);
                }

            }.bind(this)).catch(function (error) {
            });
        },
        ListarGestionCapacitacion: function () {

            axios.post("/Capacitacion/ListarGestionCapacitacion/", { value: this.iIdCapacitacion }).then(function (response) {

                if (response.data.Capacitacion.length > 0) {
                    var Data = response.data.Capacitacion;
                    $('#dfecha').datetimepicker('setDate', new Date(parseInt(Data[0]['dFechaRealizacionCapacitacion'].substr(6))));
                    $('#horarinicio').datetimepicker('setDate', new Date('1990-01-01 ' + Data[0]['tHoraInicio']));
                    $('#horartermino').datetimepicker('setDate', new Date('1990-01-01 ' + Data[0]['tHoraFin']));
                    $('#horartermino').val(Data[0]['iTiempoTest']);
                    $('input:radio[name=optradio][value=' + Data[0]['iTipoExpositor'] + ']').prop('checked', true);

                    $('#ListaPersonalExpositor tr').each(function (k, v) {

                        var data = $(v).find('.idexpositor').prop('innerText');
                        if (data == Data[0]['iIdRepresentante']) {
                            $(v).find('.optExpositor').prop('checked', true);
                            Capacitacion.vCodPersonal = $(v).find('.vCodPersonal').prop('innerText');
                        }
                    });

                    var _Preguntas = [];
                    $.each(response.data.preguntas, function (key, val) {
                        var dato = {

                            "iIdPregunta": val.iIdPregunta,
                            "vEnunciadoPregunta": val.vEnunciadoPregunta,
                            "TipoRespuesta": $('input:radio[name=optRespuesta]:checked').val() == val.iTipoRespuestaPregunta ? "V/F" : "Opción",
                            "iTipoRespuestaPregunta": val.iTipoRespuestaPregunta,
                            "valortestPorcentaje": (val.iPuntajePregunta * 100) / 20,
                            "valortest": val.iPuntajePregunta,
                            "respuestas": val.FormatoRespuesta,
                        };
                        _Preguntas.push(dato);
                    });

                    this.Lista_Preguntas = _Preguntas;
                    this.OpcionesRespuesta = response.data.Opciones;
                    this.Capacitacion_Personal = response.data.Capacitacion_Personal;

                    if (Data[0]['iTipoExpositor'] == "1") {
                        this.ListaExpositorExterno(Data[0]['iIdRepresentante']);
                    } else {
                        var representante = Data[0]['iIdRepresentante'];
                        this.ListarPersonal(representante);
                    }
                } else {
                    $('#dfecha').datetimepicker('setDate', new Date());
                    $('#horarinicio').datetimepicker('setDate', new Date());
                    $('#horartermino').datetimepicker('setDate', new Date());
                    $('input:radio[name=optradio][value=0]').prop('checked', false);
                    $('input:radio[name=optradio][value=1]').prop('checked', false);

                    this.iIdPersonal = 0;
                    $('#ExpNombre').val('');
                    $('#ExpoApePat').val('');
                    $('#ExpoApeMat').val('');
                    $('#ExpoDNI').val('');

                    this.Lista_Preguntas = [];
                    this.Lista_Operarios = [];
                }
            }.bind(this)).catch(function (error) {
            });

        },
        GestionarCapacitacion: function (iIdCapacitacion, vCodCapacitacion, vTemaCapacitacion) {
            var f = new Date();
            var fa = f.getFullYear() + '-' + ('0' + (f.getMonth() + 1)).slice(-2) + '-' + ('0' + f.getDate()).slice(-2);
            this.iIdCapacitacion = iIdCapacitacion;
            this.vCodCapacitacion = vCodCapacitacion;
            this.vTemaCapacitacion = vTemaCapacitacion;

            var _ListaCapacitacion = this.Lista_Capacitacion;

            var _lista = _ListaCapacitacion.find(function (val) {
                return (val.iIdCapacitacion == iIdCapacitacion);
            });
            this.LimpiarExpositor();
            this.LimpiarFormularioGestionCapacitacion();         
            this.Latitud = _lista.dLatitud;
            this.Longitud = _lista.dLongitud;
            $('#Latitud').text(_lista.dLatitud);
            $('#Longitud').text(_lista.dLongitud);


            $('#GESTIONCAPACITACION').removeClass('hide');
            $('#CAPACITACION').addClass('hide');
            this.ListarPersonal(0);
        },
        MostrarPersonal: function () {
            $('#txtEmpresa').val("");
            $('#txtRUC').val("");
            $('#txtTelefono').val("");
            $('#txtExpositorE').val("");
            $('#txtApellidoPE').val("");
            $('#txtApellidoME').val("");
            $('#cboTipoDocumentoModal').val("0");
            $('#txtNroDocumentoModal').val("");
            $('#txtCelular').val("");
            $("#ModalPersonal").modal('show');
        },
        MostrarPersonalExterno: function () {
            this.vCodPersonal = "";
            $("#ModalEmpresaExterna").modal('show');
        },
        MostrarCapacitacion: function () {
            this.iIdCapacitacion = 0;
            $('.txtCodigo').addClass('hide');
            $('#cboEstadoCapacitacion').val(1);
            $("#ModalCapacitacion").modal('show');
        },
        ExpositorSeleccionado: function (vCodPersonal, iIdPersonal) {
            this.vCodPersonal = vCodPersonal;
            this.iIdPersonal = iIdPersonal;
        },
        AceptarExpositor: function () {

            var _Lista_Personal = this.Lista_Personal;
            var _vCodPersonal = this.vCodPersonal;
            var _lista = _Lista_Personal.find(x => x.vCodPersonal == _vCodPersonal);
            this.iIdPersonal = _lista.iIdPersonal;
            $('#ExpNombre').val(_lista.vNombrePersonal);
            $('#ExpoApePat').val(_lista.vApellidoPaternoPersonal);
            $('#ExpoApeMat').val(_lista.vApellidoMaternoPersonal);
            $('#ExpoDNI').val(_lista.NroDocumento);
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
            //this.Capacitacion_Personal
            if (this.vCodPersonal.length != 0) {
                var _Lista_Personal = this.Lista_Personal;
                _Lista_Personal = _Lista_Personal.filter(function (eval) {
                    return eval.vCodPersonal != _vCodPersonal;
                });
                this.Lista_Operarios = _Lista_Personal;
            } else {
                this.Lista_Operarios = this.Lista_Personal;
            }

            var _Capacitacion_Personal = this.Capacitacion_Personal;
            if (_Capacitacion_Personal.length > 0) {
                var _Lista_Operarios = this.Lista_Operarios;

                $.each(_Lista_Operarios, function (key, value) {
                    $.each(_Capacitacion_Personal, function (k, v) {
                        if (value.iIdPersonal == v.iIdPersonal) {
                            value.iEstadoPersonal = -1;
                        }
                    });
                });
                this.Lista_Operarios = _Lista_Operarios;
            }

            $("#ModalOperario").modal('show');
            $('#ModalOperario input').attr('disabled', false);
            $('#ModalOperario button').attr('disabled', false);
        },
        VerOperarios: function () {
            
            var _vCodPersonal = this.vCodPersonal;
            //this.Capacitacion_Personal
            if (this.vCodPersonal.length != 0) {
                var _Lista_Personal = this.Lista_Personal;
                _Lista_Personal = _Lista_Personal.filter(function (eval) {
                    return eval.vCodPersonal != _vCodPersonal;
                });
                this.Lista_Operarios = _Lista_Personal;
            } else {
                this.Lista_Operarios = this.Lista_Personal;
            }

            var _Capacitacion_Personal = this.Capacitacion_Personal;
            if (_Capacitacion_Personal.length > 0) {
                var _Lista_Operarios = this.Lista_Operarios;

                $.each(_Lista_Operarios, function (key, value) {
                    $.each(_Capacitacion_Personal, function (k, v) {
                        if (value.iIdPersonal == v.iIdPersonal) {
                            value.iEstadoPersonal = -1;
                        }
                    });
                });
                this.Lista_Operarios = _Lista_Operarios;
            }

            this.Lista_OperariosVisualizar = this.Lista_Operarios.filter(x=> x.iEstadoPersonal == -1);

            //$('#ModalOperario input').attr('disabled', true);
            //$('#ModalOperario button').attr('disabled', true);
            //$('#ModalOperario .cancelaroperarios').attr('disabled', false);
            $("#ModalVerOperario").modal('show');

        },
        SeleccionarMapa: function () {
            //$("#ModalMapa").modal('show');
            $('#Mapav2').removeClass('hide');
            $('#GESTIONCAPACITACION').addClass('hide');
            var popup = L.popup();
            if (Capacitacion.Latitud == null) {
                Capacitacion.Latitud = -12.116283123011357;
                $('#Latitud').text(-12.116283123011357);
            }
            if (Capacitacion.Longitud == null) {
                Capacitacion.Longitud = -77.02498571422734;
                $('#Longitud').text(-77.02498571422734);
            }

            if (mymap) {
                mymap.remove();
                mymap = L.map('googleMap');
            } else {
                mymap = L.map('googleMap');
            }

            mymap.setView([parseFloat(Capacitacion.Latitud), parseFloat(Capacitacion.Longitud)], 18);

            L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
            }).addTo(mymap);

            var popup = L.popup();
            var LatLong = {
                "lat": parseFloat(Capacitacion.Latitud),
                "lng": parseFloat(Capacitacion.Longitud)
            }

            popup
                    .setLatLng(LatLong)
                    .setContent("Punto de Capacitación.")
                    .openOn(mymap);

            function onMapClick(e) {
                //$(".leaflet-marker-icon").remove(); $(".leaflet-popup").remove(); $(".leaflet-interactive").remove();
                //var mark = L.marker([e.latlng.lat, e.latlng.lng]).addTo(mymap);
                //if (!map.hasLayer(mark)) {
                //    map.removeLayer(mark);
                //}
                //mymap.clearLayers();
                //.bindPopup("<b>Hello world!</b><br />I am a popup.").openPopup();

                $('#Latitud').text(e.latlng.lat);
                $('#Longitud').text(e.latlng.lng);
                popup
                    .setLatLng(e.latlng)
                    .setContent("La ubicación seleccionada esta entre estos puntos :" + e.latlng.toString())
                    .openOn(mymap);
            }

            mymap.on('click', onMapClick);


        },
        CerrarMapa: function () {
            $('#GESTIONCAPACITACION').removeClass('hide');
            $('#Mapav2').addClass('hide');
        },
        GrabarOpcionVF: function () {
            var datos = this.OpcionesRespuesta;
            var _ResTextOpcion = "";
            var _chkEstadoCorrecto = "";
            var _iEstadoOpcion = $('input:radio[name=opRespuesta]:checked').val();
            var _iIdPregunta = this.iIdPregunta;

            if (this.EstadoActualizar == 0) {
                var list = {
                    "iIdPregunta": _iIdPregunta,
                    "vEnunciadoOpcion": _ResTextOpcion,
                    "estado": _chkEstadoCorrecto,
                    "iEstadoOpcion": _iEstadoOpcion
                };
                datos.push(list);
                this.OpcionesRespuesta = datos;
            } else {
                _iIdPregunta = this.EstadoActualizar;
                $.each(datos, function (key, val) {
                    if (val.iIdPregunta == _iIdPregunta) {
                        val.vEnunciadoOpcion = _ResTextOpcion;
                        val.estado = _chkEstadoCorrecto;
                        val.iEstadoOpcion = _iEstadoOpcion;
                    }
                });
            }
            this.OpcionesRespuesta = datos;
        },
        AgregarRespuesta: function () {
            var datos = this.OpcionesRespuesta;
            var _iIdPregunta = this.EstadoActualizar != 0 ? this.EstadoActualizar : this.iIdPregunta;

            var _ResTextOpcion = $('#ResTextOpcion').val().trim();
            var _chkEstadoCorrecto = $('#chkEstadoCorrecto').is(':checked') ? 'Correcto' : 'Incorrecto';
            var _iEstadoOpcion = $('#chkEstadoCorrecto').is(':checked') ? 1 : 0;

            var _ValidarE = datos.find(function (val) {
                if (_iEstadoOpcion == 1) {
                    return (val.iEstadoOpcion == 1 && val.iIdPregunta == _iIdPregunta);
                }
                return false;
            });
            if (_ValidarE != undefined) {
                MensajeModal('Ya hay una respuesta con la opcion correcta', 2);
                //alert('Ya hay una respuesta con la opcion correcta');
                return;
            }

            if (_ResTextOpcion.length == 0) {
                MensajeModal('Debe ingresar una descripción para la respuesta', 2);
                //alert('Debe ingresar una descripción para la respuesta');
                return;
            }

            var _Validar = datos.find(function (val) {
                return (val.vEnunciadoOpcion == _ResTextOpcion && val.iIdPregunta == _iIdPregunta);
            });
            if (_Validar != undefined) {
                MensajeModal('Ya existe una respuesta igual', 2);
                //alert('Ya existe una respuesta igual');
                return;
            }
            var list = {
                "iIdPregunta": _iIdPregunta,
                "vEnunciadoOpcion": _ResTextOpcion,
                "estado": _chkEstadoCorrecto,
                "iEstadoOpcion": _iEstadoOpcion
            };
            datos.push(list);
            this.OpcionesRespuesta = datos;

            var _ListaO = [];
            var _ListaO = datos.filter(function (elem) {
                return elem.iIdPregunta == _iIdPregunta;
            });
            //$.each(datos, function (k, v) {
            //    if (v.iIdPregunta == _iIdPregunta) {
            //        var list = { "iIdPregunta": v.iIdPregunta, "vEnunciadoOpcion": v.vEnunciadoOpcion, "estado": v.estado, "iEstadoOpcion": v.iEstadoOpcion };
            //        _ListaO.push(list);
            //    }
            //});

            this.tempOpcionesRespuesta = _ListaO;


            $('#ResTextOpcion').val('');
            $('#chkEstadoCorrecto').attr('checked', false);
        },
        AgregarRespuestaMultiple: function () {
            var datos = this.OpcionesRespuesta;
            var _iIdPregunta = this.EstadoActualizar != 0 ? this.EstadoActualizar : this.iIdPregunta;


            var _ResTextOpcion = $('#ResTextOpcionMultiple').val().trim();
            var _chkEstadoCorrecto = $('#chkEstadoCorrectoMultiple').is(':checked') ? 'Correcto' : 'Incorrecto';
            var _iEstadoOpcion = $('#chkEstadoCorrectoMultiple').is(':checked') ? 1 : 0;

            if (_ResTextOpcion.length == 0) {
                MensajeModal('Debe ingresar una descripción para la respuesta', 2);
                //alert('Debe ingresar una descripción para la respuesta');
                return;
            }

            var _Validar = datos.find(function (val) {
                return (val.vEnunciadoOpcion == _ResTextOpcion && val.iIdPregunta == _iIdPregunta);
            });
            if (_Validar != undefined) {
                MensajeModal('Ya existe una respuesta igual', 2);
                //alert('Ya existe una respuesta igual');
                return;
            }
            var list = {
                "iIdPregunta": _iIdPregunta,
                "vEnunciadoOpcion": _ResTextOpcion,
                "estado": _chkEstadoCorrecto,
                "iEstadoOpcion": _iEstadoOpcion
            };
            datos.push(list);
            this.OpcionesRespuesta = datos;

            var _ListaO = datos.filter(function (elem) {
                return elem.iIdPregunta == _iIdPregunta;
            });
            //$.each(datos, function (k, v) {
            //    if (v.iIdPregunta == _iIdPregunta) {
            //        var list = { "iIdPregunta": v.iIdPregunta, "vEnunciadoOpcion": v.vEnunciadoOpcion, "estado": v.estado, "iEstadoOpcion": v.iEstadoOpcion };
            //        _ListaO.push(list);
            //    }
            //});

            this.tempOpcionesRespuestaMultiple = _ListaO;


            $('#ResTextOpcionMultiple').val('');
            $('#chkEstadoCorrectoMultiple').attr('checked', false);
        },
        QuitarOpcion: function (vEnunciadoOpcion, iIdPregunta) {
            if (this.Estado_Ver_Test == 0) {
                var datos = this.OpcionesRespuesta;
                var result = datos.filter(function (elem) {

                    return (elem.vEnunciadoOpcion != vEnunciadoOpcion || elem.iIdPregunta != iIdPregunta);
                });
                this.OpcionesRespuesta = result;
                var _ListaO = result.filter(function (elem) {
                    return elem.iIdPregunta == iIdPregunta;
                });

                this.tempOpcionesRespuesta = _ListaO;
            }

        },
        QuitarOpcionMultiple: function (vEnunciadoOpcion, iIdPregunta) {

            if (this.Estado_Ver_Test == 0) {
                var datos = this.OpcionesRespuesta;
                var result = datos.filter(function (elem) {

                    return (elem.vEnunciadoOpcion != vEnunciadoOpcion || elem.iIdPregunta != iIdPregunta);
                });
                this.OpcionesRespuesta = result;
                var _ListaO = result.filter(function (elem) {
                    return elem.iIdPregunta == iIdPregunta;
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

                var _optRespuesta = $('input:radio[name=optRespuesta]:checked').val();
                var _TipoRespuesta = $('input:radio[name=optRespuesta]:checked').val() == 1 ? "V/F" : "Opción";

                var _iIdPregunta = this.iIdPregunta;
                var datos = this.Lista_Preguntas;

                var _Validar = datos.find(function (val) {
                    return val.vEnunciadoPregunta == _Enunciadotest;
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
                if (_optRespuesta == 2) {
                    var datosR = this.OpcionesRespuesta;
                    var _Validar = datosR.find(function (val) {
                        return (val.iEstadoOpcion == 1 && val.iIdPregunta == _iIdPregunta);
                    });
                    if (_Validar == undefined) {
                        MensajeModal('Debe ingresar una opcion con estado correcto', 2);
                        //alert('Debe ingresar una opcion con estado correcto');
                        return;
                    }

                }
                var lista = {
                    "iIdPregunta": _iIdPregunta,
                    "vEnunciadoPregunta": _Enunciadotest,
                    "TipoRespuesta": _TipoRespuesta,
                    "iTipoRespuestaPregunta": _optRespuesta,
                    "valortestPorcentaje": _valortest_porcentaje,
                    "valortest": _valortest,
                    "respuestas": Capacitacion.PreguntaOpcionXML(),
                };
                datos.push(lista);

                if (_optRespuesta == 1) {
                    this.GrabarOpcionVF();
                }

                this.iIdPregunta = _iIdPregunta + 1;
                this.Lista_Preguntas = datos;

            } else {

                var _iIdPregunta = this.EstadoActualizar;
                var _Enunciadotest = $('#Enunciadotest').val();
                var _optRespuesta = $('input:radio[name=optRespuesta]:checked').val();
                var _valortest_porcentaje = $('#valortest').val();
                var _valortest = (this.NotaMaxima * _valortest_porcentaje) / 100;

                var datos = this.Lista_Preguntas;
                $.each(datos, function (key, val) {
                    if (val.iIdPregunta == _iIdPregunta) {
                        val.vEnunciadoPregunta = _Enunciadotest;
                        val.valortestPorcentaje = _valortest_porcentaje;
                        val.valortest = _valortest;
                        val.iTipoRespuestaPregunta = _optRespuesta;
                        val.respuestas = Capacitacion.PreguntaOpcionXML();
                    }
                });
                if (_optRespuesta == 1) {
                    this.GrabarOpcionVF();
                }
            }
            this.LimpiarFormulario();

        },
        PreguntaOpcionXML: function () {
            var _Respuestas = '';
            if ($('input:radio[name = optRespuesta]:checked').val() == 1) {
                var _ResTextOpcion = "";
                var _chkEstadoCorrecto = "";
                var _iEstadoOpcion = $('input:radio[name=opRespuesta]:checked').val();
                var _iIdPregunta = this.iIdPregunta;

                var ListaRespuesta = [];
                var Respuesta = {
                    "iIdPregunta": _iIdPregunta,
                    "vEnunciadoOpcion": _ResTextOpcion,
                    "estado": _chkEstadoCorrecto,
                    "iEstadoOpcion": _iEstadoOpcion
                };
                ListaRespuesta.push(Respuesta);
                _Respuestas = this.GenerarXML(ListaRespuesta);
                _Respuestas = _Respuestas.replace(/</g, '[').replace(/>/g, ']');
            } else if ($('input:radio[name = optRespuesta]:checked').val() == 2) {
                _Respuestas = this.GenerarXML(this.tempOpcionesRespuesta);
                _Respuestas = _Respuestas.replace(/</g, '[').replace(/>/g, ']');
            } else if ($('input:radio[name = optRespuesta]:checked').val() == 3) {
                _Respuestas = this.GenerarXML(this.tempOpcionesRespuestaMultiple);
                _Respuestas = _Respuestas.replace(/</g, '[').replace(/>/g, ']');
            }



            return _Respuestas;
        },
        QuitarPregunta: function (iIdPregunta) {
            var _Lista_Preguntas = this.Lista_Preguntas;
            var _OpcionesRespuesta = this.OpcionesRespuesta;

            _Lista_Preguntas = _Lista_Preguntas.filter(function (val) {
                return val.iIdPregunta != iIdPregunta;
            });
            _OpcionesRespuesta = _OpcionesRespuesta.filter(function (val) {
                return val.iIdPregunta != iIdPregunta;
            });
            this.Lista_Preguntas = _Lista_Preguntas;
            this.OpcionesRespuesta = _OpcionesRespuesta;



        },
        EditarPregunta: function (iIdPregunta) {

            var _Lista_Preguntas = this.Lista_Preguntas;
            var _OpcionesRespuesta = this.OpcionesRespuesta;

            var _ListaP = _Lista_Preguntas.find(function (val) {
                return val.iIdPregunta == iIdPregunta;
            });

            var _ListaO = [];

            $('#Enunciadotest').val(_ListaP.vEnunciadoPregunta);
            $('#valortest').val(_ListaP.valortestPorcentaje);

            $('input:radio[name=optRespuesta][value=' + _ListaP.iTipoRespuestaPregunta + ']').prop('checked', true);
            if (_ListaP.iTipoRespuestaPregunta == 1) {
                $('#tipoRespuestaOpciones').addClass('hide');
                $('#tipoRespuestaOpcionesMultiple').addClass('hide');
                $('#tipoRespuestaVF').removeClass('hide');
                _ListaO = _OpcionesRespuesta.find(function (val) {
                    return val.iIdPregunta == iIdPregunta;
                });
                $('input:radio[name=opRespuesta][value=' + _ListaO.iEstadoOpcion + ']').prop('checked', true);


            } else if (_ListaP.iTipoRespuestaPregunta == 2) {
                $('#tipoRespuestaVF').addClass('hide');
                $('#tipoRespuestaOpcionesMultiple').addClass('hide');
                $('#tipoRespuestaOpciones').removeClass('hide');

                $.each(_OpcionesRespuesta, function (k, v) {
                    if (v.iIdPregunta == iIdPregunta) {
                        var list = {
                            "iIdPregunta": v.iIdPregunta,
                            "vEnunciadoOpcion": v.vEnunciadoOpcion,
                            //"estado": v.iEstadoOpcion == 1 ? 'Correcto' : 'Incorrecto',
                            "iEstadoOpcion": v.iEstadoOpcion,
                        };
                        _ListaO.push(list);
                    }
                });
                this.tempOpcionesRespuesta = _ListaO;
            } else if (_ListaP.iTipoRespuestaPregunta == 3) {
                $('#tipoRespuestaVF').addClass('hide');
                $('#tipoRespuestaOpciones').addClass('hide');
                $('#tipoRespuestaOpcionesMultiple').removeClass('hide');

                $.each(_OpcionesRespuesta, function (k, v) {
                    if (v.iIdPregunta == iIdPregunta) {
                        var list = {
                            "iIdPregunta": v.iIdPregunta,
                            "vEnunciadoOpcion": v.vEnunciadoOpcion,
                            //"estado": v.iEstadoOpcion == 1 ? 'Correcto' : 'Incorrecto',
                            "iEstadoOpcion": v.iEstadoOpcion,
                        };
                        _ListaO.push(list);
                    }
                });
                this.tempOpcionesRespuestaMultiple = _ListaO;
            }


            $('#btnAgregarPregunta').text('Actualizar Pregunta');
            $('#btnCancelarPregunta').removeClass('hide');
            this.EstadoActualizar = _ListaP.iIdPregunta;



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
            this.tempOpcionesRespuestaMultiple = [];
        },
        LimpiarExpositor: function () {
            this.iIdPersonal = 0;
            $('#ExpNombre').val('');
            $('#ExpoApePat').val('');
            $('#ExpoApeMat').val('');
            $('#ExpoDNI').val('');
            $('#ExpoEmpresa').val('');

        },
        LimpiarFormularioGestionCapacitacion: function(){
            this.Lista_Preguntas = [];
            this.OpcionesRespuesta = [];
            this.Capacitacion_Personal = [];
            $('#dfecha').datetimepicker('setDate', new Date());
            $('#horarinicio').datetimepicker('setDate', new Date());
            $('#horartermino').datetimepicker('setDate', new Date());

            $('#horartermino').val(20);
            $('input:radio[name=optradio][value=0]').prop('checked', true);
        },
        GrabarPreguntas: function () {
            if (!this.ValidarCantidadPreguntas())
                return;

            this.Estado_Almacenamiento_Preguntas = 1;
            $("#ModalTest").modal('hide');
        },
        CancelarPreguntas: function () {
            $("#ModalTest").modal('hide');
            this.Estado_Almacenamiento_Preguntas = 0;
        },
        GrabarOperarios: function () {
            var _Capacitacion_Personal = []
            $('#ListaPersonalCapacitacion tr').each(function (k, v) {
                var check = $(v).find('[type=checkbox]')[0];
                if ($(check).prop('checked')) {
                    var dato = {
                        'iIdPersonal': $(check).attr('data-iIdPersonal'),
                    }
                    _Capacitacion_Personal.push(dato);
                }
            });
            this.Capacitacion_Personal = _Capacitacion_Personal;
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
                Mensaje("La hora final es mayor a la hora de inicio", 2);
                //alert("La hora final es mayor a la hora de inicio");
                return;
            }
            if ($('#ExpNombre').val().trim() == '') {
                Mensaje("Ingrese un expositor", 2);
                //alert("Ingrese un expositor");
                return;
            }


            if (!this.ValidarCantidadPreguntas())
                return;
            //debugger;
            //if ($('input[name="optRespuesta"]:checked').val() == 1) {
            //    this.iIdCapacitacion = 1;
            //}
            var nLatitud = (parseFloat($('#Latitud').text()) == 0 ? parseFloat("-76.96249462061785") : parseFloat($('#Latitud').text()));
            var nLongitud = (parseFloat($('#Longitud').text()) == 0 ? parseFloat("-12.130453115407523") : parseFloat($('#Longitud').text()));

            var fechaCapacitacion = $('#dfecha').data('date');
            //Descomentar al subir al servidor
            //fechaCapacitacion = fechaCapacitacion.substr(3, 2) + "/" + fechaCapacitacion.substr(0, 2) + "/" + fechaCapacitacion.substr(6, 10);

            var GestionCapacitacion = {
                'iIdCapacitacion': this.iIdCapacitacion,
                'iIdRepresentante': this.iIdPersonal,
                'dFechaRealizacionCapacitacion': fechaCapacitacion,
                'tHoraInicio': $('#horarinicio').data('date'),// $('#horarinicio').val(),
                'tHoraFin': $('#horartermino').data('date'),//$('#horartermino').val(),
                'iTiempoTest': $('#tiempotest').val(),
                'nLatitud': nLatitud,
                'nLongitud': nLongitud,
                'iTipoExpositor': $('input:radio[name=optradio]:checked').val()
            }

            var _Lista_Preguntas = this.Lista_Preguntas;
            var _Preguntas = [];
            $.each(_Lista_Preguntas, function (key, val) {
                var dato = {
                    "iIdPregunta": parseInt(val.iIdPregunta),
                    "vEnunciadoPregunta": val.vEnunciadoPregunta,
                    "iPuntajePregunta": val.valortest,
                    "iTipoRespuestaPregunta": val.iTipoRespuestaPregunta,
                    "respuestas": val.respuestas,
                };
                _Preguntas.push(dato);
            });

            var _CapacitacionPersonal = this.Capacitacion_Personal;

            var _ExpositorExterno = [];
            var ExpositorExterno = {
                "NombreEmpresa": $('#txtEmpresa').val(),
                "RUC": $('#txtRUC').val(),
                "Telefono": $('#txtTelefono').val(),
                "NombreExpositor": $('#txtExpositorE').val(),
                "ApellidoPaternoExpositor": $('#txtApellidoPE').val(),
                "ApellidoMaternoExpositor": $('#txtApellidoME').val(),
                "TipoDocumentoExpositor": $('#cboTipoDocumentoModal').val(),
                "NroDocumentoExpositor": $('#txtNroDocumentoModal').val(),
                "TelefonoExpositor": $('#txtCelular').val(),
            }
            _ExpositorExterno.push(ExpositorExterno);

            var jsonData = { GestionCapacitacion: GestionCapacitacion, _Preguntas: _Preguntas, _CapacitacionPersonal: _CapacitacionPersonal, _ExpositorExterno: _ExpositorExterno };
            axios.post("/Capacitacion/RegistrarCapacitacion/", jsonData).then(function (response) {
                if (response.data.respuesta.codigo >= 0) {
                    Mensaje('La Capacitacion se programo correctamente', 0);
                    //alert('La Capacitacion se programo correctamente');
                    //this.Estado_Almacenamiento_Preguntas = 0;
                    //this.Estado_Almacenamiento_Operarios = 0;
                    $('#GESTIONCAPACITACION').addClass('hide');
                    $('#CAPACITACION').removeClass('hide');
                    this.ListaCapacitacion();
                } else {
                    Mensaje(response.data.respuesta.Mensaje, 2);
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
                MensajeModal('El valor de las preguntas debe llegar al 100%', 2);
                this.Estado_Almacenamiento_Preguntas = 0;
                return false;
            };
            return true;
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

            if ($('#txtEmpresa').val() == '') {
                MensajeModal('El nombnre de la empresa no a sido ingresada', 2);
                return false;
            }
            if ($('#txtRUC').val() == '') {
                MensajeModal('El RUC de la empresa no a sido ingresada', 2);
                return false;
            }
            if ($('#txtTelefono').val() == '') {
                MensajeModal('El txtTelefono de la empresa no a sido ingresada', 2);
                return false;
            }
            if ($('#txtApellidoPE').val() == '') {
                MensajeModal('El apellido paterno del expositor externo de la empresa no a sido ingresada', 2);
                return false;
            }
            if ($('#txtApellidoME').val() == '') {
                MensajeModal('El apellido materno del expositor de la empresa no a sido ingresada', 2);
                return false;
            }
            if ($('#txtCelular').val() == '') {
                MensajeModal('El celular del expositor de la empresa no a sido ingresada', 2);
                return false;
            }
            if ($('#cboTipoDocumentoModal').val() == '') {
                MensajeModal('El docuemento del expositor de la empresa no a sido ingresada', 2);
                return false;
            } 
            if ($('#txtNroDocumentoModal').val() == '') {
                MensajeModal('El nro documento del expositor de la empresa no a sido ingresada', 2);
                return false;
            }
            if ($('#txtCelular').val() == '') {
                MensajeModal('El celular del expositor de la empresa no a sido ingresada', 2);
                return false;
            }

            $('#ExpNombre').val($('#txtExpositorE').val());
            $('#ExpoApePat').val($('#txtApellidoPE').val());
            $('#ExpoApeMat').val($('#txtApellidoME').val());
            $('#ExpoDNI').val($('#txtNroDocumentoModal').val());
            this.iIdPersonal = 0;

            $("#ModalEmpresaExterna").modal('hide');
        },
        GenerarXML: function (dato) {
            var object = dato;
            var XML = '<ListaRespuesta>';
            var hijos = '';
            $.each(object, function (k, v) {
                var doc = $.parseXML("<Respuesta/>")
                var json = v;
                var xml = doc.getElementsByTagName("Respuesta")[0];
                var key, elem;
                for (key in json) {
                    if (json.hasOwnProperty(key)) {
                        elem = doc.createElement(key)
                        $(elem).text(json[key])
                        xml.appendChild(elem);
                    }
                }
                hijos += xml.outerHTML;
            });
            XML += hijos + '</ListaRespuesta>';
            return XML;
        },
        MostrarTest: function () {
            var _Lista_Preguntas = [];
            var _Lista_Opciones = [];
            var _html = "";
            axios.post("/TestEvaluacion/GenerarCamposCapacitacion/").then(function (response) {
                if (response.data.ListaPregunta.length > 0) {
                    this.Lista_Preguntas = response.data.ListaPregunta;
                    this.OpcionesRespuesta = response.data.ListaOpciones;
                }

                _Lista_Preguntas = this.Lista_Preguntas;
                _Lista_Opciones = this.OpcionesRespuesta;

                $.each(_Lista_Preguntas, function (key, val) {
                    _html = _html +
                        '<div class="col-sm-12 text-center">' +
                        "<h3>" + (key + 1) + ".- " + val.vEnunciadoPregunta + "</h3></div>";
                    switch (parseInt(val.iTipoRespuestaPregunta)) {
                        case 1:
                            $.each(_Lista_Opciones, function (keyR, valR) {

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
                            $.each(_Lista_Opciones, function (k, v) {
                                if (val.iIdPregunta == v.iIdPregunta) {
                                    bEstado = v.iEstadoOpcion == 1 ? "checked" : "";
                                    _html = _html + '<label class="radio-inline"><input type="radio" class="radio" name="pregunta' + val.iIdPregunta + '" value="' + v.iIdOpcion + '" ' + bEstado + ' disabled >' + v.vEnunciadoOpcion + '</label>';
                                }
                            });
                            _html = _html + '</div>'; break;
                        case 3:
                            _html = _html + '<div class="col-sm-12 text-center _Examen">';
                            var bEstado = "checked";
                            $.each(_Lista_Opciones, function (k, v) {
                                if (val.iIdPregunta == v.iIdPregunta) {
                                    bEstado = v.iEstadoOpcion == 1 ? "checked" : "";
                                    _html = _html + '<label class="checkbox-inline"><input type="checkbox" name="pregunta' + val.iIdPregunta + '" value="' + v.iIdOpcion + '" ' + bEstado + ' disabled>' + v.vEnunciadoOpcion + '</label>';
                                }
                            });
                            _html = _html + '</div>'; break;
                        default: _html += ''; break;
                    }

                });
                $('#ModalVisualizarTest').modal('show');
                $('#PContenido').html(_html);

            }.bind(this)).catch(function (error) {
            });
        },
    },
    computed: {},
    created: function () {
        this.ListaEstadoCapacitacion();
        this.ListaTipoDocumento();
        //this.ListaCapacitacion();

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
    $('.txtCodigo').removeClass('hide');
    Capacitacion.iIdCapacitacion = data["iIdCapacitacion"];
    $('#cboEstadoCapacitacion').val(data['iEstadoCapactiacion']);
    $('#txtTema').val(data["vTemaCapacitacion"]);
    $('#txtCodigo').val(data["vCodCapacitacion"]);

    var fecha = data["dFechaPropuestaCapacitacion"].substring(3, 5) + "/" + data["dFechaPropuestaCapacitacion"].substring(0, 2) + "/" + data["dFechaPropuestaCapacitacion"].substring(6, 10)

    $("#txtFechaCapacitacion").datetimepicker("setDate", new Date(fecha));
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
$('#dfecha > .form-control').prop('disabled', true);

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
$('#horarinicio > .form-control').prop('disabled', true);


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
$('#horartermino > .form-control').prop('disabled', true);


var minDate = moment();
$('#txtFechaCapacitacion').datetimepicker({    
    language: 'es',
    weekStart: 1,
    todayBtn: 1,
    autoclose: 1,
    todayHighlight: 1,
    startView: 2,
    minView: 2,
    forceParse: 0,
    minDate: moment(),
});
$('#txtFechaCapacitacion > .form-control').prop('disabled', true);
var mymap;