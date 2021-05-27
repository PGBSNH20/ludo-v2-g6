"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established

connection.on("ReceiveMessage", function (message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${message}`;
});

connection.start().then(function () {
    console.log("hej")
}).catch(function (err) {
    return console.error(err.toString());
});

window.onload = document.getElementById("message").addEventListener("selectionchange", function (event) {
    //var user = document.getElementById("userInput").value;
    var message = document.getElementById("message").innerText;
    connection.invoke("SendMessage", message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

//elementToObserve = window.document.getElementById("message");

//observer = new MutationObserver(function (messagesList, observer){
//    var message = document.getElementById("message").innerHTML;
//    connection.invoke("SendMessage", message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//}