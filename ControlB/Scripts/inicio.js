// Script inicial de la template
// ------------------------------------------------

var modalBs = $('#myModal');
var modalBsContent = $('#myModal').find(".modal-content");
var gridRefresh = "";

function handleOnErrorModelState(e, status) {
    if (e.errors) {
        var message = "";

        $.each(e.errors, function (key, value) {
            if (value.errors) {
                message += value.errors.join(".\n");
            }
        });
        alerta("Resultado de la operación", message, "error")
    }
}

/* 01. Handles para oparaciones ajax con modales y formularios
---------------------------------------------  */
function handleAjaxModal() {
    console.log("((handleAjaxModal))");
    // Limpia los eventos asociados para elementos ya existentes, asi evita duplicación
    $("a[data-modal]").unbind("click");

    // Intercepta links para salto a otras paginas
    //handleLoadingOnLinks();

    // Evita cachear las transaccione Ajax previas
    $.ajaxSetup({ cache: false });

    // Configura evento del link para aquellos para los que desean abrir popups
    $("a[data-modal]").on("click", function (e) {
        var dataModalValue = $(this).data("modal");
        gridRefresh = $(this).data("kgrid")        
        $('#modalContent').load(this.href, function (response, status, xhr) {
            switch (status) {
                case "success":
                    modalBs.modal({ backdrop: 'static', keyboard: false }, 'show');

                    if (dataModalValue == "modal-lg") {
                        modalBs.find(".modal-dialog").addClass("modal-lg");
                    }
                    else if (dataModalValue == "modal-xl") {
                        modalBs.find(".modal-dialog").addClass("modal-xl");
                    }
                    else {
                        modalBs.find(".modal-dialog").removeClass("modal-lg");
                        modalBs.find(".modal-dialog").removeClass("modal-xl");
                    }

                    $('#myModal').modal('show');

                    break;


                case "error":
                    alerta("Error de ejecución: " + xhr.status + " " + xhr.statusText, "error")
                    //var message = "Error de ejecución: " + xhr.status + " " + xhr.statusText;
                    //if (xhr.status == 403) alerta(response, result.Message, "error");
                    //else alerta(message, result.Message, "error");
                    break;
            }

        });                
        return false;
    });


}

// agrega cultura español - Colombia
kendo.culture("es-CO");

        jQuery(document).ready(function () {

            "use strict";

            // Init Theme Core
            Core.init();

            // Init Theme Core
            Demo.init();

            // Init tray navigation smooth scroll
            //$('.tray-nav a').smoothScroll({
            //    offset: -145
            //});

            //----------------------------  GESTION DEL MODAL ---------------------------
            //--------------------------------------------------------------------------
            modalBsContent.on('click', '.holder-style', function (e) {
                e.preventDefault();
                modalBsContent.find('.holder-style').removeClass('holder-active');
                $(this).addClass('holder-active');
            });

            $("a[data-modal]").on('click', function (e) {
                var dataModalValue = $(this).data("modal");
                gridRefresh = $(this).data("kgrid")
                $('#modalContent').load(this.href, function (response, status, xhr) {
                    switch (status) {
                        case "success":
                            modalBs.modal({ backdrop: 'static', keyboard: false }, 'show');

                            if (dataModalValue == "modal-lg") {
                                modalBs.find(".modal-dialog").addClass("modal-lg");
                            }
                            else if (dataModalValue == "modal-xl") {
                                modalBs.find(".modal-dialog").addClass("modal-xl");
                            }
                            else {
                                modalBs.find(".modal-dialog").removeClass("modal-lg");
                                modalBs.find(".modal-dialog").removeClass("modal-xl");
                            }

                            $('#myModal').modal('show');

                            break;


                        case "error":
                            alerta("Error de ejecución: " + xhr.status + " " + xhr.statusText, "error")
                            //var message = "Error de ejecución: " + xhr.status + " " + xhr.statusText;
                            //if (xhr.status == 403) alerta(response, result.Message, "error");
                            //else alerta(message, result.Message, "error");
                            break;
                    }

                });
                return false;
            });

            function respuestaCargarVentana(dataRequest) {
                debugger;
                $("#contenidoVentana").html(dataRequest);
                $("#winModal").data("kendoWindow").open();
            }

            function findActive() {
                var activeModal = modalContent.find('.holder-active').attr('href');
                return activeModal;
            };

            // Custom tray navigation animation
            setTimeout(function () {
                $('.custom-nav-animation li').each(function (i, e) {
                    var This = $(this);
                    var timer = setTimeout(function () {
                        This.addClass('animated zoomIn');
                    }, 100 * i);
                });
            }, 600);


            // Sparklines Plugin
            //$('.inlinesparkline').sparkline('html', {
            //    type: 'line',
            //    height: 30,
            //    width: 100,

            //    lineColor: bgInfoDr, // Also tooltip icon color
            //    fillColor: bgInfoLr,

            //    spotColor: bgPrimary,
            //    minSpotColor: bgPrimary,
            //    maxSpotColor: bgPrimary,

            //    highlightSpotColor: bgWarningDr,
            //    highlightLineColor: bgWarningLr
            //});

            //var barColors = $.range_map({
            //    '1:6': bgWarning,
            //    '7:11': bgInfo,
            //    '12:': bgPrimary
            //})

            //$('.inlinesparkbar').sparkline('html', {
            //    type: 'bar',
            //    height: 25,
            //    barWidth: 4,
            //    barSpacing: 1,

            //    barColor: bgPrimary, // Also tooltip icon color
            //    fillColor: bgInfoLr,
            //    colorMap: barColors, // Colors mapped/stored in object above

            //    spotColor: bgPrimary,
            //    minSpotColor: bgPrimary,
            //    maxSpotColor: bgPrimary,

            //    highlightSpotColor: bgWarningDr,
            //    highlightLineColor: bgWarningLr
            //});

            //$('.inlinesparkpie').sparkline('html', {
            //    type: 'pie',
            //    width: 30,
            //    height: 23,
            //    offset: 90,
            //    sliceColors: [bgPrimary, bgInfo, bgWarning, bgAlert, bgDanger]
            //});
            //$('.inlinesparkpie2').sparkline('html', {
            //    type: 'pie',
            //    width: 23,
            //    height: 23,
            //    offset: -45,
            //    sliceColors: [bgPrimary, bgSuccess, bgAlert, bgDark, bgDanger]
            //});            

        });
