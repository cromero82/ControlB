var GenPersona = function () {
    "use strict"
    return {        

        // Iniciallizacion vista index
        initIndex: function () {
            GenPersona.actionBotones = kendo.template($('#actionBotones').html());
        },

        // Iniciallizacion vista de edicion
        initEdicion: function (accion) {
            //if(accion == "Insertar"){}
        },


        filterMunicipios: function () {
                return {
                    departamento: $("#departamentos").val()
                };
            }
    }

}();