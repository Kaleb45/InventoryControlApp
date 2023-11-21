function toggleForm(formId) {
    var container = document.getElementById(formId + 'Container');
    var form = document.getElementById(formId);
    var otherFormId = formId === 'loginForm' ? 'signinForm' : 'loginForm';
    var otherForm = document.getElementById(otherFormId);

    if (container.style.height === '0px' || container.style.height === '') {
        // Expande el contenedor en ancho y altura
        container.style.width = '400px'; // ajusta el ancho según tus necesidades
        container.style.height = 'auto'; // ajusta la altura según tus necesidades

        setTimeout(function () {
            // Muestra el formulario
            form.style.display = 'block';
            otherForm.style.display = 'none';
        }, 300); // Ajusta según la duración de la expansión del contenedor
    } else {
        // Oculta el formulario y colapsa el contenedor
        form.style.display = 'none';
        container.style.height = '0';

        setTimeout(function () {
            // Restablece el ancho del contenedor
            container.style.width = '25%';
            container.style.padding = '10px';
            container.style.marginLeft = 'auto';
            container.style.marginRight = 'auto';
            container.style.marginBottom = '1opx';
            container.style.marginTop = '10px';
        }, 300); // Ajusta según la duración de la animación de colapso
    }
}

function mostrarContrasena() {
    var x = document.getElementById("passwordInput");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}

function myFunction() {
    var x = document.querySelector("nav");
    if (x.className === "") {
        x.className = "responsive";
    } else {
        x.className = "";
    }
}

function recargarPagina() {
    location.reload();
    location.reload();
}

function toggleContent(event) {
    var titleId = event.target.closest('.titles').id;
    var contentId = titleId + "Content";
    var content = document.getElementById(contentId);

    // Cierra todos los elementos abiertos
    var openContents = document.querySelectorAll('.table-database.open, .insert-database.open, content-container.open');
    openContents.forEach(function (openContent) {
        if (openContent.id !== contentId) {
            openContent.classList.remove('open');
        }
    });

    // Realiza la animación
    content.classList.toggle('open');
}