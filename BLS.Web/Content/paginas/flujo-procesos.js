function iconMaxMin() {
    var i = $('#iconCollapse');
    i.attr('class', i.hasClass('fas fa-angle-double-down') ? 'fas fa-angle-double-up' : i.attr('data-original'));
}
function OnInitFloating(s, e) {
    fab.SetActionContext("ShareItemContext", false);
}
function OnActionItemClick(s, e) {
    if (e.actionName === "Recargar") {
        MyCallbackPanel.PerformCallback();
    }
}

function mensajes_EndCallback(s, e) {

    if (s.cp_swType != null) {
        mostrarMensajeSweet(s.cp_swType, s.cp_swMsg);
        s.cp_swType = null;
        s.cp_swMsg = null;
    }
}

function OnToolbarItemClick(s, e) {
    switch (e.item.name) {
        case "CustomExportToXLS":
            e.processOnServer = true;
            e.usePostBack = true;
            break;
        case "CustomExportToXLSX":
            e.processOnServer = true;
            e.usePostBack = true;
            break;

    }
}

function OnGetInfo(id) {
    HidParam.Set('Id', id);
    ppInfoSeccion.Show();
}