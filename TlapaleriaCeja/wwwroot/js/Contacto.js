var cont = 0;

function validarFormulario() {

    const items = document.querySelectorAll(".item");
    const ban = true;

    for (const item of items) {
        if (item.value == "") {
            item.classList.add("error");
            item.parentElement.classList.add("error");
            cont++;
        }

        if (items[1].value != "") {
            checkEmail();
        }

        items[1].addEventListener("keyup", () => {
            checkEmail();
        })

        item.addEventListener("keyup", () => {
            if (item.value != "") {
                item.classList.remove("error");
                item.parentElement.classList.remove("error");
            } else {
                item.classList.add("error");
                item.parentElement.classList.add("error");
                cont++;
            }
        })
       
    }
    if (cont > 0) {
        cont = 0;
        return false;
    }

    return true;
}

function checkEmail() {
    var correo = document.getElementById("email");
    const emailRegex = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/;
    const errorTxtEmail = document.querySelector(".error-txt.email");


    if (!correo.value.match(emailRegex)) {
        correo.classList.add("error");
        correo.parentElement.classList.add("error");
        cont++;

        if (correo.value != "") {
            errorTxtEmail.innerText = "Ingresa un correo válido"
        } else {
            errorTxtEmail.innerText = "El correo no debe ir vacío"
        }
    } else {
        correo.classList.remove("error");
        correo.parentElement.classList.remove("error");
    }
}

document.getElementById("contactForm").addEventListener("submit", function (event) {
    if (!validarFormulario()) {
        event.preventDefault();
        return;
    }
    swal("MUCHAS GRACIAS", "Su comentario ha sido enviado con éxito", "success");
});
