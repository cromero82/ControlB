var area = null;
var controlador = null;
var accion = null;

init();

function handleOnErrorModelState(ev) {
    alerta("Error en servidor", ev.xhr.statusText, "error");
}

function init() {
    var url = window.location;
    var elementosRuta = url.pathname.split("/");
    area = elementosRuta[1];
    controlador = elementosRuta[2];
    accion = elementosRuta[3];
    if (typeof accion === 'undefined' || accion === null) {
        accion = controlador;
    }
    $('.sidebar-menu li a').find('.active').removeClass('menu-open');
    try {
        $('.sidebar-menu li a').each(function () {
            // -- Abre el menu externo (efecto de la template)
            if ($(this).find('.siderbar-title').prevObject["0"].outerText == controlador) {
                $(this).addClass('menu-open');
            }
            $('#sidebar_left > div > ul > li').each(function () {
                // -- Recorre los submenus, activando el efecto del template de la posicion según el menu y la pagina actual (reconocer la posicion)
                $(this).find('ul > li').each(function () {
                    var accionMenu = this.children[0].href.split(/[/]+/).pop();
                    if (accionMenu == accion) {
                        $(this).addClass('active');
                        ($(this).parent()).parent().addClass('active');
                    }
                })
            })
        });
    } catch (ex) {

    }
    // --   add clase menu-open al ultimo menu ( o todos los menus secundarios) que asocien cada acción  
    $('.sidebar-menu').find('.' + accion).addClass('menu-open')
    $('.sidebar-menu').find('.' + accion).addClass('active')
}