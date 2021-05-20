////const uri = 'https://localhost:5002/api/gamepiece?id='

//async function gameBoardPices(gameBoardID) {


//    let xhr = new XMLHttpRequest;
//    xhr.open('GET', `https://localhost:5002/api/gamepiece?id=${gameBoardID}`, true)


//    let response = await fetch(`https://localhost:5002/api/gamepiece?id=${gameBoardID}`);
//    if (!response.ok) {   // Catch errors
//        throw new Error(`HTTP error! status: ${response.status}`);
//    } else {    // Present result
//        const respons = await response.json();

//        let i = 0
//        do {
//            const position = respons[i].
//        }

//    }
//}




  /*  var serviceUrl = 'http://testapp1158.azurewebsites.net';*/
    function CORSRequest() {
        var method = $('#method').val();
        $.ajax({
        type: method,
            url: 'https://localhost:5002/api/gamepiece?id=2ef39deb-41cf-422f-c9d3-08d91b59e9f3'
        }).done(function (data) {
        $('#data').text(data);
        }).error(function (jqXHR, textStatus, errorThrown) {
        $('#data').text(jqXHR.responseText || textStatus);
        });
    }



function getItems() {
    fetch('https://localhost:5002/api/gamepiece?id=2ef39deb-41cf-422f-c9d3-08d91b59e9f3')
        .then(response => response.json())
        .then(data => _useItems(data))
        .catch(error => console.error('Unable to get items.', error));

    console.log("hej")
}
function _useItems(data) {

    document.getElementById("hejsan").innerText = data.value.color;
     //data.forEach(item => {

    //});
}




//function setPieces() {
//    var gamboardPosition = document.getElementById('4');

//    gamboardPosition.style.backgroundColor = "red";
//    gamboardPosition.style.border = "6px solid white";

//document.getElementById("randomjoke").innerText = tojson.value.joke;
//}
//function Dice() {

//    var dice = Math.floor(Math.random() * 6) + 1;
//    document.getElementById("dice").innerHTML = dice;

//}
