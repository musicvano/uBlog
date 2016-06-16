(function Init() {
    // Get the modal
    var modal = document.getElementById('modal');
    var inputPassword = document.getElementById('password');

    // Get the button that opens the modal
    var btn = document.getElementById("login");

    // When the user clicks the button, open the modal 
    btn.onclick = function() {
        modal.style.display = "block";
        inputPassword.focus();
    }

    var CloseModal = function () {
        modal.style.display = 'none';
        inputPassword.value = '';
    };

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function(event) {
        if (event.target == modal) {
            CloseModal();
        }
    }

    document.onkeydown = function (e) {
        if (e.keyCode == 27) {
            CloseModal();
        }
    }
})();