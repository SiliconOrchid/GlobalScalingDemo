//const serviceEndpoint = 'http://localhost:7071/api/';   // include trailing slash
const serviceEndpoint = 'https://globalscalingdemofrontendhost.azurefd.net/api/';
//const serviceEndpoint = 'https://{your function app hostname}.azurewebsites.net/api/';


const serverApiMethod = "CalculatePrimeNumber"; // do not include any slashes


window.onload = function () {

    var messageElement = document.getElementById("messageElement");

    fetch(serviceEndpoint + serverApiMethod)
         .then(response => response.text())
         .then(text => {
            messageElement.innerHTML = text;
         }).catch(err => {
             messageElement.innerHTML = "Failure connecting to server";
         });
};