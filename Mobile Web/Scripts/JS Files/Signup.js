function validation() {
    var regexpname = /^\S*$/;
    var regexpemail = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    var name = document.getElementById("exampleInputUsername").value;
    var email = document.getElementById("exampleInputEmail").value;
    var country= document.getElementById("select-country").value;
    var passw= document.getElementById("exampleInputPassword1").value;
    var cpassw= document.getElementById("exampleInputcPassword1").value;
    var text = document.getElementById("errorUser");
    var textemail = document.getElementById("errorEmail");
    var textcountry = document.getElementById("errorCountry");
    var textpassw = document.getElementById("errorPassw");
    var textcpassw = document.getElementById("errorCPassw");
    if (name.length < 4) {
        text.innerHTML="Username can't contain less than 4 characters.";
        return false;
    }
    else if (!regexpname.test(name))
    {
        text.innerHTML="Username can't contain spaces.";
        return false;
    }
    else if(email.length<10)
    {
        text.innerHTML="";
        textemail.innerHTML="Invalid email address.";
        return false;
    }
    else if (!regexpemail.test(email))
    {
        text.innerHTML="";
        textemail.innerHTML="Invalid email address.";
        return false;
    }
    else if(country=="Country"){
        text.innerHTML="";
        textemail.innerHTML="";
        textcountry.innerHTML="Kindly select your country.";
        return false;
    }
    else if (passw.length<8)
    {   
        text.innerHTML="";
        textemail.innerHTML="";
        textcountry.innerHTML=""; 
        textpassw.innerHTML="Password can't contain less than 8 characters.";
        return false;
    }
    else if (passw!=cpassw)
    {
        text.innerHTML="";
        textemail.innerHTML="";
        textcountry.innerHTML="";  
        textpassw.innerHTML="";
        textcpassw.innerHTML="Password doesn't match.";
        return false;
    }
    else
    {

        return true;
    }
}
