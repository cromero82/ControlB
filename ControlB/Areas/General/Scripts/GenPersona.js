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

//function change(e) {
//    $(this).value = kendo.toString(this.value(), 'd');
//}

function onUpdateRequest_Details(e) {
    debugger;
    e.LastStatementDate = $("#<YourDateFieldName>").val(); // set string value
}