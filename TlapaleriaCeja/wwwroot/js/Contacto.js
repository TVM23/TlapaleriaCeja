function validarFormulario() {
    // Obtener los valores de los campos
    var nombre = document.getElementById("name").value;
    var email = document.getElementById("email").value;
    var telefono = document.getElementById("phone").value;
    var mensaje = document.getElementById("message").value;

    // Verificar que los campos obligatorios no estén vacíos
    if (nombre.trim() === "") {
        mostrarError("El nombre no debe ir vacío");
        return false; // Detener el envío del formulario
    }
    if (email.trim() === "") {
        mostrarError("El correo no debe ir vacío");
        return false; // Detener el envío del formulario
    }
    if (telefono.trim() === "") {
        mostrarError("Debes ingresar un número de teléfono");
        return false; // Detener el envío del formulario
    }
    if (mensaje.trim() === "") {
        mostrarError("El mensaje no debe ir vacío");
        return false; // Detener el envío del formulario
    }

    // Si todos los campos están llenos, permitir el envío del formulario
    return true;
}

function mostrarError(mensaje) {
    // Mostrar mensaje de error
    var errorDiv = document.createElement("div");
    errorDiv.className = "error-txt";
    errorDiv.textContent = mensaje;

    // Insertar el mensaje de error después del campo respectivo
    var botonEnviar = document.getElementById("submitButton");
    botonEnviar.parentNode.insertBefore(errorDiv, botonEnviar.nextSibling);
}

// Agregar evento submit al formulario para llamar a la función validarFormulario
document.getElementById("contactForm").addEventListener("submit", function (event) {
    // Validar el formulario antes de enviarlo
    if (!validarFormulario()) {
        // Detener el envío del formulario si la validación falla
        event.preventDefault();
        return;
    }
    swal("MUCHAS GRACIAS", "Su comentario ha sido enviado con éxito", "success");
});
