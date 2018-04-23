// oculta el modal personalizado
function ocultarModal() {
    $("#myModal").modal('hide');
};

// actualiza el form (pendiente determinar cual div borrar)
function actualizarModal(elemento, dataHtml) {
    $("#" + elemento).html(dataHtml);
}

///-- Ejecuta una petición ajax (Post) en el servidor y devuelve la respuesta a la función definida en el parametro: funcionRespuesta.
function ejecutarPeticionAjax(data, url, funcionRespuesta) {
    var _funcionRespuesta = funcionRespuesta;
    $.ajaxSetup({ cache: false });
    //Consulta la información solicitada
    $.ajax({
        method: "POST",
        url: url,
        data: data,
        content: "application/json; charset=utf-8",
        dataType: "html",
        beforeSend: function () {
            $('#loader_titan').show();
        },
        success: function (data) {
            //$('#loader_titan').show();
            $('#loader_titan').hide();
            setTimeout(_funcionRespuesta, 1, JSON.parse(data));
        },
        error: function (ex) {
            $('#loader_titan').hide();
            alert("Error");
            // Aqui divMostrarErrorr
        }
    }).done(function (data) {
        $('#loader_titan').hide();
    });
}

function onSuccessGenerico(data) {
    if (typeof data.HtmlSuccess != 'undefined') {
        if (data.HtmlSuccess == "Ok") {
            mostrarMensaje("Resultado de la transacción", data.Message, "success");
            ocultarModal();
            // En caso de ser necesario, actualiza la lista de kendo
            if (gridRefresh != "") {
                actualizarDatosKendoGrid(gridRefresh);
                gridRefresh = ""
            }
        } else {
            mostrarMensaje("Resultado de la transacción", data.Message, "warning");
        }
    } else {
        // En caso de errores en formulario - Model.IsValid()
        actualizarModal("modalContent", data);
    }
};

function onFailureGenerico(data) {
    mostrarMensaje("Resultado de la transacción", "Se ha presentado un error del sistema", "danger");
};

function mostrarMensaje(titulo, mensaje, tipo) {
    // Mensaje alert
    if (tipo == "danger") {
        tipo = "error";
    }
    swal(titulo, mensaje, tipo);

    // Notificación semi-permanente
    //var kendoNotificacion = $("#kendoNotificacion").data("kendoNotification");
    //kendoNotificacion.show({
    //    title: titulo,
    //    message: mensaje
    //}, "info");

}

function actualizarDatosKendoGrid(idGrid) {
    var grid = $("#" + idGrid).data("kendoGrid");
    grid.dataSource.read();
}

function interceptorErroresKendo(e, status) {
    debugger;
    if (e.errors) {
        var message = "";
        $.each(e.errors, function (key, value) {
            if (value.errors) {
                message += value.errors.join(".\n");
            }
        });
        alert("Resultado de la operación: " + message)
    }
}

//Se modifica para recargue del datatable asociado con el campo IdTabla y la URL de la data.
function mensajeAdvertenciaEliminar(urlEliminar, dataId, kendoGridId) {
    swal({
        title: "¿Está usted seguro?",
        text: "A continuación se eliminara el registro",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn btn-danger",
        confirmButtonText: "Sí, eliminelo!",
        cancelButtonClass: "btn btn-succes",
        cancelButtonText: "No, cancelar!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            type: "post",
            url: urlEliminar,
            data: dataId,
            success: function (data) {
                if (data.TipoResultado == "success") {
                    swal("Eliminado!", "El registro ah sido eliminado con exito.", "success");
                    actualizarDatosKendoGrid(kendoGridId);
                } else {
                    swal("Lo sentimos!", "El registro no pudo ser eliminado", "warning");
                }
            },
            error: function (ex) {
                swal("Error!", ex, "error");
            }
        })
    });
};