






//async function myFunction() {


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
    const respons = await fetch('https://localhost:44369/api/gamepiece?id=0a4c1107-112a-4968-37f5-08d91c353a39');
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
            cell.style.backgroundColor = data[i].color;
            cell.style.backgroundColor = `red`;
            cell.style.border = "6px solid white";


        }

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
