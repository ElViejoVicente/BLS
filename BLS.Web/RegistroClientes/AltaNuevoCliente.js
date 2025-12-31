

function VerAlertasCondicional(s, e) {

    if (s.cp_swType != null) {

        if (s.cp_swClose != '') {
        }

        if (s.cp_Reload != '') {
        }

        // Si hay redirect, usa el swal con contador y redirige al finalizar
        if (s.cp_RedirectUrl) {
            var url = s.cp_RedirectUrl;

            // limpia para evitar que se dispare otra vez
            s.cp_RedirectUrl = null;

            // muestra mensaje con cuenta regresiva de 10 segundos
            mostrarMensajeSweetCount(
                s.cp_swType,
                s.cp_swMsg,
                10,
                function () { window.location.href = url; },
                { confirmButtonText: "Ir al login" }
            );

        } else {
            // si no hay redirect, usa tu swal normal
            mostrarMensajeSweet(s.cp_swType, s.cp_swMsg);
        }

        s.cp_swType = null;
        s.cp_swMsg = null;
    }
}


function SoloLetras(s, e) {
    var key = e.htmlEvent.key;

    // Permitir letras y espacios
    var regex = /^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]$/;

    if (!regex.test(key)) {
        e.htmlEvent.preventDefault();
    }
}

function SoloNumeros(s, e) {
    var key = e.htmlEvent.key;

    // Permitir solo números
    if (!/^\d$/.test(key)) {
        e.htmlEvent.preventDefault();
    }
}



function validarPasswordVisual(s, e) {

    var password = s.GetText();

    validarRegla("length", password.length >= 8);
    validarRegla("upper", /[A-Z]/.test(password));
    validarRegla("lower", /[a-z]/.test(password));
    validarRegla("number", /\d/.test(password));
    validarRegla("symbol", /[\W_]/.test(password));
}

// ---------------------------
// Validación completa (reglas + coincidencia) + feedback visual
// y seteo de Session["ssContraseñaValida"] vía callback
// ---------------------------
var _ultimoEstadoPwdOk = null;

function passwordCumpleReglas(pwd) {
    if (!pwd) return false;
    if (pwd.length < 8) return false;
    if (!/[A-Z]/.test(pwd)) return false;
    if (!/[a-z]/.test(pwd)) return false;
    if (!/\d/.test(pwd)) return false;
    if (!/[\W_]/.test(pwd)) return false;
    if (/\s/.test(pwd)) return false; // sin espacios
    return true;
}

function setEstadoVisualPassword(ok, msg) {
    var el = document.getElementById("passwordMatch");
    if (!el) return;

    if (ok) {
        el.classList.remove("text-danger");
        el.classList.add("text-success");
        el.innerHTML = "✔ " + (msg || "Contraseña válida");
    } else {
        el.classList.remove("text-success");
        el.classList.add("text-danger");
        el.innerHTML = "❌ " + (msg || "Revisa la contraseña");
    }
}

function setSessionPasswordOk(ok) {
    // Evitar callbacks repetidos
    if (_ultimoEstadoPwdOk === ok) return;
    _ultimoEstadoPwdOk = ok;

    // Guardar también en hidden field por si lo quieres leer en servidor
    if (typeof hfPasswordOk !== "undefined" && hfPasswordOk) {
        hfPasswordOk.Set("ok", ok ? "1" : "0");
    }

    // Setear Session en servidor
    if (typeof cbPwdSession !== "undefined" && cbPwdSession) {
        cbPwdSession.PerformCallback(ok ? "1" : "0");
    }
}

function validarPasswordYConfirmacion() {
    // Nota: Requiere ClientInstanceName="txtPassword" y "txtConfirPassword"
    var pwd = (typeof txtPassword !== "undefined" && txtPassword) ? txtPassword.GetText() : "";
    var conf = (typeof txtConfirPassword !== "undefined" && txtConfirPassword) ? txtConfirPassword.GetText() : "";

    var reglasOk = passwordCumpleReglas(pwd);
    var coinciden = pwd.length > 0 && (pwd === conf);

    if (!reglasOk) {
        setEstadoVisualPassword(false, "La contraseña no cumple los requisitos");
        setSessionPasswordOk(false);
        return false;
    }

    if (!coinciden) {
        setEstadoVisualPassword(false, "Las contraseñas no coinciden");
        setSessionPasswordOk(false);
        return false;
    }

    setEstadoVisualPassword(true, "Contraseña OK y coincide");
    setSessionPasswordOk(true);
    return true;
}


function validarRegla(id, cumple) {
    var el = document.getElementById(id);

    if (cumple) {
        el.classList.remove("text-danger");
        el.classList.add("text-success");
        el.innerHTML = "✔ " + el.innerText.replace("❌", "").replace("✔", "").trim();
    } else {
        el.classList.remove("text-success");
        el.classList.add("text-danger");
        el.innerHTML = "❌ " + el.innerText.replace("❌", "").replace("✔", "").trim();
    }
}




// ==========================
// Persistencia Cascada (HF)
// ==========================
(function () {
    "use strict";

    function safeVal(v) { return (v === null || v === undefined) ? "" : v; }

    function setHF(key, val) {
        if (typeof hfDireccion === "undefined" || !hfDireccion) return;
        hfDireccion.Set(key, safeVal(val));
    }

    function getHF(key) {
        if (typeof hfDireccion === "undefined" || !hfDireccion) return "";
        return safeVal(hfDireccion.Get(key));
    }

    function clearCombo(cmb) {
        if (!cmb) return;
        try { cmb.SetValue(null); } catch (e) { }
        try { cmb.SetText(""); } catch (e) { }
    }

    function enableCombo(cmb, enabled) {
        if (!cmb) return;
        try { cmb.SetEnabled(enabled); } catch (e) { }
    }

    window.syncDireccionHF = function () {
        setHF("estado", (cmbEstado && cmbEstado.GetValue) ? cmbEstado.GetValue() : "");
        setHF("municipio", (cmbMunicipio && cmbMunicipio.GetValue) ? cmbMunicipio.GetValue() : "");
        setHF("ciudad", (cmbCiudad && cmbCiudad.GetValue) ? cmbCiudad.GetValue() : "");
        setHF("ciudadText", (cmbCiudad && cmbCiudad.GetText) ? cmbCiudad.GetText() : "");
        setHF("cp", (cmbCodigoPostal && cmbCodigoPostal.GetValue) ? cmbCodigoPostal.GetValue() : "");
    };

    window.restoreDireccionFromHF = function () {
        try {
            var estado = getHF("estado");
            var municipio = getHF("municipio");
            var ciudad = getHF("ciudad");
            var ciudadText = getHF("ciudadText");
            var cp = getHF("cp");

            if (estado && cmbEstado && cmbEstado.SetValue) cmbEstado.SetValue(estado);
            if (municipio && cmbMunicipio && cmbMunicipio.SetValue) cmbMunicipio.SetValue(municipio);

            if (cmbCiudad) {
                if (ciudad && cmbCiudad.SetValue) cmbCiudad.SetValue(ciudad);
                else if (ciudadText && cmbCiudad.SetText) cmbCiudad.SetText(ciudadText);
            }

            if (cp && cmbCodigoPostal && cmbCodigoPostal.SetValue) cmbCodigoPostal.SetValue(cp);

        } catch (e) { }
    };

    window.onEstadoChanged = function (s, e) {
        syncDireccionHF();

        clearCombo(cmbMunicipio);
        clearCombo(cmbCiudad);
        clearCombo(cmbCodigoPostal);

        setHF("municipio", "");
        setHF("ciudad", "");
        setHF("ciudadText", "");
        setHF("cp", "");

        enableCombo(cmbMunicipio, false);
        enableCombo(cmbCiudad, false);
        enableCombo(cmbCodigoPostal, false);

        var estado = (cmbEstado && cmbEstado.GetValue) ? cmbEstado.GetValue() : null;
        if (!estado) return;

        cmbMunicipio.PerformCallback(estado);
        enableCombo(cmbMunicipio, true);
    };

    window.onMunicipioChanged = function (s, e) {
        syncDireccionHF();

        clearCombo(cmbCiudad);
        clearCombo(cmbCodigoPostal);

        setHF("ciudad", "");
        setHF("ciudadText", "");
        setHF("cp", "");

        enableCombo(cmbCiudad, false);
        enableCombo(cmbCodigoPostal, false);

        var municipio = (cmbMunicipio && cmbMunicipio.GetValue) ? cmbMunicipio.GetValue() : null;
        if (!municipio) return;

        cmbCiudad.PerformCallback(municipio);
        enableCombo(cmbCiudad, true);
    };

    window.onCiudadChanged = function (s, e) {
        syncDireccionHF();

        clearCombo(cmbCodigoPostal);
        setHF("cp", "");
        enableCombo(cmbCodigoPostal, false);

        var asentamiento = (cmbCiudad && cmbCiudad.GetText) ? cmbCiudad.GetText() : "";
        if (!asentamiento) return;

        cmbCodigoPostal.PerformCallback(asentamiento);
        enableCombo(cmbCodigoPostal, true);
    };

    window.onCodigoPostalChanged = function (s, e) {
        syncDireccionHF();
    };

    window.AltaNuevoCliente_BeforeAction = function () {
        try { syncDireccionHF(); } catch (e) { }
    };

    if (typeof window.mostrarMensajeSweet === "function") {
        var _orig = window.mostrarMensajeSweet;
        window.mostrarMensajeSweet = function (type, message) {
            try { syncDireccionHF(); } catch (e) { }
            var r = _orig(type, message);
            try { syncDireccionHF(); } catch (e2) { }
            return r;
        };
    }
    if (typeof window.mostrarMensajeSweetCount === "function") {
        var _orig2 = window.mostrarMensajeSweetCount;
        window.mostrarMensajeSweetCount = function () {
            try { syncDireccionHF(); } catch (e) { }
            var r = _orig2.apply(this, arguments);
            try { syncDireccionHF(); } catch (e2) { }
            return r;
        };
    }
})();

