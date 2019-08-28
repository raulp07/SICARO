

new Vue({
    el: "#app",
    data: {
    },
    methods: {
        ValidarUsusario: function () {

            var _Ususario = $('#Usuario').val();
            var _Password = $('#Password').val();
            if (_Ususario == '') {
                alert("Ingrese un Usuario");
                return;
            }
            if (_Password == '') {
                alert("Ingrese una Contraseña");
                return;
            }

            var ValidacionUsuario = {
                'CtaUsuario': _Ususario,
                'Contrasenia': _Password
            }

            var jsonData = { Ususario: ValidacionUsuario };
            axios.post("/Login/ValidarUsuario/", jsonData).then(function (response) {

                var data = response.data;
                if (data.length > 0) {
                    Mensaje('Bienvenido', 0);
                    //alert("Bienvenido al sistema");
                    setTimeout(function () {
                        window.location.href = '/home/index/';
                    }, 1100);
                    
                }

                //if (response.data.perosnalizaicon == 1) {
                //    alert('La Capacitacion se programo correctamente');
                //    $('#GESTIONCAPACITACION').addClass('hide');
                //    $('#CAPACITACION').removeClass('hide');
                //} else {
                //    alert('Ocurrio un error');
                //}
            }.bind(this)).catch(function (error) {
            });
        },
    },
    computed: {},
    created: function () {
    },
    mounted: function () {
    }
});