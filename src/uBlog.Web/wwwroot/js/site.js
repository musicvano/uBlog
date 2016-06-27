(function Init() {
    // Get the modal
    var modal = document.getElementById('modal');
    var inputPassword = document.getElementById('password');

    // Get the button that opens the modal
    var btn = document.getElementById("login");

    // When the user clicks the button, open the modal 
    btn.onclick = function () {
        modal.style.display = "block";
        inputPassword.focus();
    }

    var CloseModal = function () {
        modal.style.display = "none";
        inputPassword.value = "";
    };

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
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

function Submit() {
    var xhr = new XMLHttpRequest();
    var inputPassword = document.getElementById('password');
    var form = document.getElementById("loginForm");
    xhr.open("POST", "admin", true);
    xhr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhr.onreadystatechange = function () {

        if (xhr.readyState == 4) {
            if (xhr.status == 200) {
                alert("OK :)");
                form.reset();
            }
            else {
                alert("Fail");
                form.reset();
            }
        }
    };
    xhr.send(inputPassword.value);
    //inputPassword.value = "";
}