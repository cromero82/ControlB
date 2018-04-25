var Tetnia = function () {
    "use strict"
    return {        

        // Iniciallizacion vista index
        initIndex: function () {
            Tetnia.actionBotones = kendo.template($('#actionBotones').html());
        },

        // Iniciallizacion vista de edicion
        initEdicion: function (accion) {
            //if(accion == "Insertar"){}
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
                url: "/ADMIN/Tniveles/DelTnivel",
                data: {
                    id: id
                    //__RequestVerificationToken: getCookie("__RequestVerificationToken") //window.RequestVerificationToken
                }
            }).done(function (result) {
                if (result.Success) {
                    alerta("Resultado de la operación", result.Message, "success");
                    $('#grid').data('kendoGrid').dataSource.read();
                    $('#grid').data('kendoGrid').refresh();

                } else {
                    alerta("Resultado de la operación", result.Message, "error")
                }
            });
        },


    }

}();