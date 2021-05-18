function validation() {
    var name = document.getElementById("exampleInputUsername").value;
    var passw = document.getElementById("exampleInputPassword1").value;
    var text = document.getElementById("errorUser");
    var textpassw = document.getElementById("errorPassw");
    var regexpname = /^\S*$/;
    if (name.length < 4) {
        text.innerHTML = "Username can't contain less than 4 characters.";
        return false;
    }
    else if (!regexpname.test(name)) {
        text.innerHTML = "Username can't contain spaces.";
        return false;
    }
    else if (passw.length < 8) {
        text.innerHTML = "";
        textpassw.innerHTML = "Password can't contain less than 8 characters.";
        return false;
    }
    else
    {
        return true;
    }
}