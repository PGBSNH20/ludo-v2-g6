






//async function myFunction() {

const { Button } = require("bootstrap");


//var requestOptions = {
//    method: "GET",
//    headers: {
//        'Content-Type': 'application/json',
//    },
//    redirect: "follow",
//};

//var response1 = await fetch("https://localhost:44369/api/Gameboard/history", requestOptions);
//var data = await response1.json();
//console.log(data);
//console.log("hej")
//return data;
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


//await fetch(url)
//    .then(response => {
//        const contentType = response.headers.get('content-type');
//        if (!contentType || !contentType.includes('application/json')) {
//            throw new TypeError("Oops, we haven't got JSON!");
//        }
//        return response.json();
//    })
//    .then(data => console.log(data))
//    .catch(error => console.error('Unable to get items.', error));

//}

/*const url = 'https://localhost:44369/api/gamepiece?id=2ef39deb-41cf-422f-c9d3-08d91b59e9f3';*/
async function getItems() {
    const respons = await fetch('https://localhost:44369/api/gamepiece?id=9922342a-8d75-4fa9-3684-08d91c4e63af');
    const data = await respons.json();
    console.log(data[1].color)
    console.log(data[1].currentPosition)
    console.log(data)
    paintBorad(data)

}



async function paintBorad(data) {

    for (var i = 0; i < data.length; i++) {

        console.log(data[i].currentPosition);
        const id = data[i].currentPosition;
        if (id === "0")
            continue;
        var cell = document.getElementById(`${id}`);
        cell.style.display = "flex";
        cell.style.justifyContent = "center";
        cell.style.alignItems = "center";

        const piece = document.createElement("button")
        piece.style.backgroundColor = data[i].color;
        piece.style.height = "80% ";
        piece.style.width = "80% ";

        piece
            .classList
            .add('game_piece')

        piece.addEventListener('click', function () {
            console.log("knapp")
            //movePiece(Diceroll)
        });

        cell.appendChild(piece)

    }

}

async function movePiece() {
    const respons = await fetch('https://localhost:44369/api/gameboard/move', {
        method: 'POST',
        headers: {
            'Accept' : 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            'gameBoardId': '9922342a-8d75-4fa9-3684-08d91c4e63af',
            'gamePieceId': 'bb11e6c6-d374-4f96-9398-ecc9abe2c782',
            'diceRoll': '6'
        })
    });
    respons.json();


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
