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
    }

}();