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
