function toggleForm(formId) {
    var container = document.getElementById(formId + 'Container');
    var form = document.getElementById(formId);
    var otherFormId = formId === 'loginForm' ? 'signinForm' : 'loginForm';
    var otherForm = document.getElementById(otherFormId);

    if (container.style.height === '0px' || container.style.height === '') {
        // Expande el contenedor en ancho y altura
        container.style.width = '300px'; // ajusta el ancho según tus necesidades
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
