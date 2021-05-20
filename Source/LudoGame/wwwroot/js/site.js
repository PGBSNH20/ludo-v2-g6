





//function paintBorad(position) {
//    var cell = document.getElementById(position);

//    cell.style.backgroundColor = `${color}`;
//    cell.style.border = "6px solid white";
//}

async function myFunction() {


    var requestOptions = {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
        },
        redirect: "follow",
    };

    var response1 = await fetch("https://localhost:44369/api/Gameboard/history", requestOptions);
    var data = await response1.json();
    console.log(data);
    console.log("hej")
    return data;
    //const Url = 'https://localhost:5002/api/gamepiece?id=2ef39deb-41cf-422f-c9d3-08d91b59e9f3';

    //$.ajax({
    //    url: Url,
    //    type: "GET",
    //    contentType:"application/x-www-form-urlencoded; charset=utf-8",
    //    success: function (result) {
    //        console.log(result)
    //    },
    //    error: function (error) {
    //        console.log(`Error ${error}`)
    //    }
    //}),
    //    console.log("hej")
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
