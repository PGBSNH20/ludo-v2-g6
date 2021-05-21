






//async function myFunction() {



/*const url = 'https://localhost:44369/api/gamepiece?id=2ef39deb-41cf-422f-c9d3-08d91b59e9f3';*/
async function getItems(id) {
    const respons = await fetch(`https://localhost:44369/api/gamepiece?id=${id}`);
    const data = await respons.json();
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

        console.log(data[i].gameBoardId)
        console.log(data[i].pieceId)

        piece.addEventListener('click', function () {
            movePiece(data[i].gameBoardId, data[i].pieceId)
        });

        cell.appendChild(piece)

    }

}

async function movePiece(gameBoardId,gamePieceId) {
    const respons = await fetch('https://localhost:44369/api/gameboard/move', {
        method: 'POST',
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            "gameBoardId": `"${gameBoardId}"`,
            "gamePieceId": `"${gamePieceId}"`,
            "diceRoll": "6"
        })
        
    });
    console.log(respons.json());


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
