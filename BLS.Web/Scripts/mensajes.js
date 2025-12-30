/*document javascript para creaciòn de mensajes informativos para el usuario del sistema GPB
 * se consume la libreria https://sweetalert.js.org/guides/
 * para mayor informacion recurrir a la doc oficial
 */

const SWEETALERT_ZINDEX = 300000; // Superior a los z-index de DevExpress
const swalTop = Swal.mixin({ zIndex: SWEETALERT_ZINDEX });

//llamar esta funcion cuando la ejecuciòn sea desde un evento callback de devExpress en lugar del control de usuario
function mostrarMensajeSweet(type, message) {
    if (type != null && message != null) {
        console.log("llamando a la funcion del mensaje Sweet...." + "[" + type + "]");
        switch (type) {
            case "info":
                msgInfo(message);
                break;
            case "success":
                msgSuccess(message);
                break;
            case "warning":
                msgWarning(message);
                break;
            case "error":
                msgError(message);
                break;
            case "preguntar":
                msgQuestion(message);
                break;
            case "preguntarJS":
                msgQuestionJS(message);
                break;
            default:
                console.log('opcion incorrecta al llamar mensaje sweet');
        }

    } else {
        console.log("Parametros CP con valores nulos");
    }
}

function msgInfo(mensaje) {
    console.log(mensaje);
    swalTop.fire(mensaje, "Información importante!", "info");
}

function msgSuccess(mensaje) {
    console.log(mensaje);
    swalTop.fire(mensaje, "Proceso realizado con éxito!", "success");
}

function msgWarning(mensaje) {
    console.log(mensaje);
    swalTop.fire(mensaje, "Precaución!", "warning");
}

function msgError(mensaje) {
    console.log(mensaje);
    swalTop.fire(mensaje, "Ha ocurrido un error en sistema!", "error");
}


function msgQuestionJS(mensaje, callback) {
    swalTop.fire({
        text: mensaje,
        icon: "question",
        showCancelButton: true,
        confirmButtonText: 'Sí',
        cancelButtonText: 'No',
        reverseButtons: true,
        allowOutsideClick: false,
        allowEscapeKey: true
    })
        .then((result) => {
            if (result.isConfirmed && typeof callback === 'function') {
                callback();
            }
        });
}

function msgGPBQuestionJSV2(mensaje, yesCallback, noCallback) {
    swalTop.fire({
        title: 'Confirmación',
        text: mensaje,
        icon: 'question',
        showCancelButton: true,
        confirmButtonText: 'Sí',
        cancelButtonText: 'No',
        reverseButtons: true,
        allowOutsideClick: false,
        allowEscapeKey: true
    }).then((result) => {
        if (result.isConfirmed) {
            if (typeof yesCallback === 'function') yesCallback();
        } else if (result.dismiss === Swal.DismissReason.cancel) {
            if (typeof noCallback === 'function') noCallback();
        }
    });
}

/**
* Muestra un mensaje SweetAlert2 con cuenta regresiva y ejecuta un callback al finalizar el timer
* (ideal para redirecciones después de mostrar un "success").
*
* @param {string} type - info|success|warning|error|question
* @param {string} message - mensaje principal
* @param {number} seconds - segundos de cuenta regresiva (ej. 10)
* @param {function} onFinish - función a ejecutar al terminar (ej. redirect)
* @param {object} options - opcional: overrides para Swal.fire (title, confirmButtonText, etc.)
*/
function mostrarMensajeSweetCount(type, message, seconds, onFinish, options) {
    if (type == null || message == null) {
        console.log("Parametros nulos en mostrarMensajeSweetCount");
        return;
    }

    var ms = (Number(seconds) > 0 ? Number(seconds) : 10) * 1000;
    var swalTitle = (options && options.title) ? options.title : getDefaultTitleByType(type);
    var confirmText = (options && options.confirmButtonText) ? options.confirmButtonText : "Ir ahora";
    var showConfirm = (options && typeof options.showConfirmButton === "boolean") ? options.showConfirmButton : true;

    let intervalId = null;

    swalTop.fire(Object.assign({
        title: swalTitle,
        html: `
            <div style="text-align:center; white-space:pre-line;">${escapeHtml(message)}</div>
            <div style="margin-top:10px; font-size:12px; opacity:.85;">
                Redirigiendo en <b><span id="swal-countdown">${Math.ceil(ms / 1000)}</span></b> segundos...
            </div>
        `,
        icon: type,
        timer: ms,
        timerProgressBar: true,
        showConfirmButton: showConfirm,
        confirmButtonText: confirmText,
        allowOutsideClick: false,
        allowEscapeKey: true,
        didOpen: () => {
            // Actualiza el contador cada 250ms aprox (suave)
            const countdownEl = Swal.getHtmlContainer().querySelector('#swal-countdown');
            intervalId = setInterval(() => {
                const left = Swal.getTimerLeft();
                if (countdownEl && left != null) {
                    countdownEl.textContent = String(Math.max(0, Math.ceil(left / 1000)));
                }
            }, 250);
        },
        willClose: () => {
            if (intervalId) clearInterval(intervalId);
        }
    }, (options || {})))
        .then((result) => {
            // Si se confirmó (clic en botón) o se cerró por timer, ejecuta callback
            if (result.isConfirmed || result.dismiss === Swal.DismissReason.timer) {
                if (typeof onFinish === "function") onFinish();
            }
        });
}

/** Helper: título por defecto según el tipo (puedes ajustar a tu gusto) */
function getDefaultTitleByType(type) {
    switch (type) {
        case "info": return "Información importante!";
        case "success": return "Proceso realizado con éxito!";
        case "warning": return "Precaución!";
        case "error": return "Ha ocurrido un error en sistema!";
        case "question": return "Confirmación";
        default: return "Mensaje";
    }
}

/**
 * Escapa HTML básico para evitar que un mensaje con < > rompa el swal (o inyecte HTML).
 * Si tú controlas 100% el contenido del mensaje, podrías omitirlo, pero es más seguro así.
 */
function escapeHtml(text) {
    if (text == null) return "";
    return String(text)
        .replace(/&/g, "&amp;")
        .replace(/</g, "&lt;")
        .replace(/>/g, "&gt;")
        .replace(/"/g, "&quot;")
        .replace(/'/g, "&#039;");
}

/** Ejemplo “atajo” para success con contador (opcional) */
function msgSuccessCount(mensaje, seconds, onFinish) {
    mostrarMensajeSweetCount("success", mensaje, seconds, onFinish, {
        title: "Proceso realizado con éxito!",
        confirmButtonText: "Ir al login"
    });
}
