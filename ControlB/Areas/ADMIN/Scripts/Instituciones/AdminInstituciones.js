var AdminInstituciones = function () {
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
            AdminInstituciones.actionBotones = kendo.template($('#actionBotones').html());
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
                url: "/ADMIN/Instituciones/DelInstitucion",
                data: {
                    id: id
                    //__RequestVerificationToken: getCookie("__RequestVerificationToken") //window.RequestVerificationToken
                }
            }).done(function (result) {
                if (result.Success) {
                    alerta("Resultado de la operación", result.Message, "success");
                    $('#institucionesGrid').data('kendoGrid').dataSource.read();
                    $('#institucionesGrid').data('kendoGrid').refresh();

                } else {
                    alerta("Resultado de la operación", result.Message, "error")
                }
            });
        }
    }

}();