var InsTgrado = function () {
    "use strict"
    return {
        // ---------------------------------
        //           Propiedades 
        // ---------------------------------
        modal: $("#InsTgrado"),

        // ---------------------------------
        //           Metodos 
        // ---------------------------------
        init: function () {
            // Codigo de inicialización
            this.handleValitator();
            setTimeout(function () {
                $('#Nombre').focus();
            }, 300);
        },

        handleValitator: function () {
            this.modal.find("form").kendoValidator();
        },

        // Permite confirmar al usuario el resultado de la acción registrar (submit).
        onSuccess: function (result) {
            if (result.Success) {
                alerta("Resultado de la operación", result.Message, "success");
                $('#tgradosGrid').data('kendoGrid').dataSource.read();
                $('#tgradosGrid').data('kendoGrid').refresh();
               
                $('#myModal').modal('hide');
            }
            else {
                alerta("Resultado de la operación", result.Message, "error")
            }
        }

    }

}();
