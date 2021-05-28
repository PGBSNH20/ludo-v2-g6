"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.addEventListener("DOMContentLoaded", function (event) {
    document.getElementById("dice").disabled = true;
});

connection.start().then(function () {
    document.getElementById("dice").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("ReceiveMove", async function (gameBoardId, gamePieceId, gamePlayerId) {
    clearText()
    await movePiece(gameBoardId, gamePieceId, gamePlayerId)
    await getItems(gameBoardId);
});


async function getItems(id) {
    const respons = await fetch(`https://localhost:44369/api/gamepiece?id=${id}`);
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
        const tempGameBoardId = `${data[i].gameBoardId}`
        const tempGamePieceId = `${data[i].pieceId}`
        const tempGamePlayerId = `${data[i].gamePlayerId}`
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
                cell = document.getElementById(`${color}_${yellowCount}`);
            }
        }
        else if (id > 58) {
            continue;
        }
        else if (id > 52) {
            cell = document.getElementById(`${color}_${id}`)
        }
        else {
            cell = document.getElementById(`${id}`);
        }

        const piece = document.createElement("button")
        piece.style.backgroundColor = data[i].color;
        piece.style.border = "2px solid black"
        piece.style.height = "80% ";
        piece.style.width = "80% ";

        piece
            .classList
            .add('pieces_onboard')

        piece.addEventListener('click', function () {

            connection.invoke("SendMessage", tempGameBoardId, tempGamePieceId, tempGamePlayerId).catch(function (err) {
                return console.error(err.toString());
            });
            event.preventDefault();

        });

        cell.appendChild(piece)
    }
}

async function movePiece(gameBoardId, gamePieceId, gamePlayerId) {

    var diceRoll = document.getElementById("diceRoll").innerText;
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
        document.getElementById("message").innerText = JSON.stringify(json)
    }
    else {
        var json = await respons.json()
        document.getElementById("message").innerText = JSON.stringify(json)
    }
}
function Dice() {
    var dice = Math.floor(Math.random() * 6) + 1;
    document.getElementById("diceRoll").innerHTML = dice;
}
function clearText() {
    var element = document.getElementsByClassName("pieces_onboard");

    while (element[0]) {
        element[0].parentNode.removeChild(element[0]);
    };
}


