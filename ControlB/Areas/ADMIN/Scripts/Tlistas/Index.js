var Index = function () {
    "use strict"
    return {
        // ---------------------------------
        //           Propiedades 
        // ---------------------------------        

        // ---------------------------------
        //           Metodos 
        // ---------------------------------

        init: function () {
            // Codigo de inicialización
            this.handleTemplates();
        },

        handleTemplates: function () {
            Index.actionBotonesDep = kendo.template($('#actionBotonesDep').html());
            Index.actionBotonesMun = kendo.template($('#actionBotonesMun').html());
        },

        // pregunta al usuario la eliminacion del registro
        validarEliminacion: function (id, nombre) {
            var id_ = id;
            var nombre_ = nombre;
            swal({
                title: "Por favor, confirme con respecto a: '" + nombre + "'",
                text: "¿Está seguro que querer eliminar el registro?  ",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
            .then((willDelete) => {
                if (willDelete) {
                    this.eliminar(id_, nombre_);
                }
            });
        },

        // elimina el registro del conductor
        eliminar: function (id, nombre) {
            $.ajax({
                method: "POST",
                url: "/ADMIN/Tgrados/DelTgrado",
                data: {
                    id: id
                    //__RequestVerificationToken: getCookie("__RequestVerificationToken") //window.RequestVerificationToken
                }
            }).done(function (result) {
                if (result.Success) {
                    alerta("Resultado de la operación", result.Message, "success");
                    $('#tgradosGrid').data('kendoGrid').dataSource.read();
                    $('#tgradosGrid').data('kendoGrid').refresh();

                } else {
                    alerta("Resultado de la operación", result.Message, "error")
                }
            });
        },


        clicBuscarDatosCo: function () {
            var codDane = "368307001885";
            $.ajax({
                url: "https://www.datos.gov.co/resource/xax6-k7eu.json?codigoestablecimiento=" + codDane,
                type: "GET",
                data: {
                    "$limit": 200,
                    "$$app_token": "KLhKnhKZUVbEIcGgYN1XH8P73"
                }
            }).done(function (data) {
                debugger;
                datosConsultados = data;
            });
            //enviarPost("registrar");
        },

        // Consulta datos de departamentos consumiendo servicio web
        datosAbiertosDepartamentos: function () {
            $.ajax({
                url: "https://www.datos.gov.co/resource/74kd-j7s9.json",
                type: "GET",
                data: {
                    "$limit": 200,
                    "$$app_token": "KLhKnhKZUVbEIcGgYN1XH8P73"
                }
            }).done(function (data) {
                Index.insertarDepartamentos(data)
            });
            //enviarPost("registrar");
        },

        // inserta departamentos  en el sistema
        insertarDepartamentos: function (data) {
            var DatosStringJson = JSON.stringify(data);
            $.ajax({
                method: "POST",
                url: "/ADMIN/Tlistas/InsDepartamentos",
                data: {
                    DatosStringJson: DatosStringJson
                    //, __RequestVerificationToken: getCookie("__RequestVerificationToken") //window.RequestVerificationToken
                }
            }).done(function (result) {
                if (result.Success) {
                    alerta("Resultado de la operación", result.Message, "success");
                    $('#tdepartamentosGrid').data('kendoGrid').dataSource.read();
                    $('#tdepartamentosGrid').data('kendoGrid').refresh();

                } else {
                    alerta("Resultado de la operación", result.Message, "error")
                }
            });
        },

        // Consulta datos de municipios consumiendo servicio web
        datosAbiertosMunicipios: function () {
            $.ajax({
                url: "https://www.datos.gov.co/api/id/5q56-d6fe.json",
                type: "GET",
                data: {
                    "$limit": 1500,
                    "$$app_token": "KLhKnhKZUVbEIcGgYN1XH8P73"
                }
            }).done(function (data) {
                Index.insertarMunicipios(data)
            });
            //enviarPost("registrar");
        },

        // inserta municipios  en el sistema
        insertarMunicipios: function (data) {
            var DatosStringJson = JSON.stringify(data);
            $.ajax({
                method: "POST",
                url: "/ADMIN/Tlistas/InsListaMunicipios",
                data: {
                    DatosStringJson: DatosStringJson
                    //, __RequestVerificationToken: getCookie("__RequestVerificationToken") //window.RequestVerificationToken
                }
            }).done(function (result) {
                if (result.Success) {
                    alerta("Resultado de la operación", result.Message, "success");
                    $('#tmunicipiosGrid').data('kendoGrid').dataSource.read();
                    $('#tmunicipiosGrid').data('kendoGrid').refresh();

                } else {
                    alerta("Resultado de la operación", result.Message, "error")
                }
            });
        }

    }

}();