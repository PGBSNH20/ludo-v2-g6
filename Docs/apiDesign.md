## Api structure

- Gameboard
	- GET (history) för att starta ett påbörjat spel och visa avslutade spel
	- POST - (GameBoard) för att starta nytt spel [*]


- GamePlayer
	- GET - (diceRoll, Guid) skicka tillbaka GamePieces som är flyttbara
	- GET - (Guid) returnera om det är spelarens tur


- GamePiece
	- UPDATE - (GamePiece) Uppdaterar spelarens position