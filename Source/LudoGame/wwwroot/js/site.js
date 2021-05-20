







function myFunction() {


    const Url = 'https://localhost:5002/api/gamepiece?id=2ef39deb-41cf-422f-c9d3-08d91b59e9f3';

    $.ajax({
        url: Url,
        type: "GET",
        success: function (result) {
            console.log(result)
        },
        error: function (error) {
            console.log(`Error ${error}`)
        }

    }),
        console.log("hej")
}





async function getItems() {
    await fetch('https://localhost:5002/api/gamepiece?id=2ef39deb-41cf-422f-c9d3-08d91b59e9f3')
        .then(response => response.json())
        .then(data => _useItems(data))
        .catch(error => console.error('Unable to get items.', error));

    console.log("hej")
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
