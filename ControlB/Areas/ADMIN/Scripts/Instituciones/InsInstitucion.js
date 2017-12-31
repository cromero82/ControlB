﻿var InsInstitucion = function () {
    "use strict"
    return {
        // ---------------------------------
        //           Propiedades 
        // ---------------------------------
        modal: $("#InsInstitucion"),

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
                $('#institucionesGrid').data('kendoGrid').dataSource.read();
                $('#institucionesGrid').data('kendoGrid').refresh();

                //modalBs.modal('hide');
                $('#myModal').modal('hide');
            }
            else {
                alerta("Resultado de la operación", result.Message, "error")
            }
        }

    }

}();
