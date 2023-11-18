function toggleForm(formId) {
    var form = document.getElementById(formId);
    var otherFormId = formId === 'loginForm' ? 'signinForm' : 'loginForm';
    var otherForm = document.getElementById(otherFormId);

    if (form.style.display === 'none') {
        form.style.display = 'block';
        otherForm.style.display = 'none';
        form.style.marginTop = '20px';
    } else {
        form.style.display = 'none';
        form.style.marginTop = '0';
    }
}
