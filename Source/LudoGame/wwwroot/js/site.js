
const url = 'https://localhost:44369/api/gamepiece?id=';

async function getItems(id) {
    const respons = await fetch(url+id);
    const data = await respons.json();
    console.log(data)
    paintBorad(data)
}


async function paintBorad(data) {
    var redCount = 0;
    var blueCount = 0;
    var greenCount = 0;
    var yellowCount = 0;
    var cell;

    for (var i = 0; i < data.length; i++) {
        const id = data[i].currentPosition;
        const color = `${data[i].color}`;
        if (id === "0") {
            if (color === "red") {
                redCount++;
                cell = document.getElementById(`${color}_${redCount}`);
            }
            if (color === "green") {
                greenCount++;
                cell = document.getElementById(`${color}_${greenCount}`);
            }
            if (color === "blue") {
                blueCount++;
                cell = document.getElementById(`${color}_${blueCount}`);
            }
            if (color === "yellow") {
                yellowCount++;
                var cell = document.getElementById(`${color}_${yellowCount}`);
            }
        }
        else if (id > 52) {
            cell = document.getElementById(`${color}_${id}`)
        }
        else {
            cell = document.getElementById(`${id}`);
        }

        cell.style.display = "flex";
        cell.style.justifyContent = "center";
        cell.style.alignItems = "center";

        const piece = document.createElement("button")
        piece.style.backgroundColor = data[i].color;
        piece.style.border = "2px solid black"
        piece.style.height = "80% ";
        piece.style.width = "80% ";

        const tempGameBoardId = `${data[i].gameBoardId}`
        const tempGamePieceId = `${data[i].pieceId}`
        const tempGamePlayerId = `${data[i].gamePlayerId}`
        piece
            .classList
            .add('pieces_onboard')

        piece.addEventListener('click', function () {
            movePiece(tempGameBoardId, tempGamePieceId, tempGamePlayerId)
        });

        cell.appendChild(piece)
    }
}

async function movePiece(gameBoardId, gamePieceId, gamePlayerId) {
    var diceRoll = document.getElementById("message").innerText;
    const respons = await fetch('https://localhost:44369/api/gameboard/move', {
        method: 'POST',
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            "gameBoardId": gameBoardId,
            "gamePieceId": gamePieceId,
            "gamePlayerId": gamePlayerId,
            "diceRoll": diceRoll
        })
    });
    if (respons.ok) {
        var json = await respons.json()
        document.getElementById("message").innerText = `It's now ${JSON.stringify(json)}s turn`
    }
    else {
        var json = await respons.json()
        document.getElementById("message").innerText = JSON.stringify(json)
    }
}
function Dice() {

    var dice = Math.floor(Math.random() * 6) + 1;
    document.getElementById("message").innerHTML = dice;

}
