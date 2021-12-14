var textphone = document.getElementById("errorPhone");
var textpin = document.getElementById("errorPin");
var textaddr = document.getElementById("errorAddr");
console.log("Outf");
function validate() {
    var phone = document.getElementById("phone#").value;
    var pin = document.getElementById("tbNum").value;
    var address = document.getElementById("addr").value;
    console.log("Inf");
    if (phone.length != 11) {
        textphone.innerHTML = "Your phone number must contain 11 digits.";
        return false;
    }
    else if (address.length < 5) {
        textphone.innerHTML = "";
        textaddr.innerHTML = "Please enter valid address.";
        return false;
    }
    else if (pin.length != 19) {
        textaddr.innerHTML = "";
        textphone.innerHTML = "";
        textpin.innerHTML = "Please enter valid 19 digit pin.";
        return false;
    }
    else
    {
        textphone.innerHTML = "";
        textpin.innerHTML = "";
        alert("Your have successfully ordered your product.");
        return true;
    }

    return true;
}
function addHyphen(element)
{
    let ele = document.getElementById(element.id);
    ele = ele.value.split('-').join('');    // Remove dash (-) if mistakenly entered.

    let finalVal = ele.match(/.{1,4}/g).join('-');
    document.getElementById(element.id).value = finalVal;
}