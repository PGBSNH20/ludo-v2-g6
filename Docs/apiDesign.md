## Api structure

- Gameboard
	- GET (history) f�r att starta ett p�b�rjat spel och visa avslutade spel
	- POST - (GameBoard) f�r att starta nytt spel [*]


- GamePlayer
	- GET - (diceRoll, Guid) skicka tillbaka GamePieces som �r flyttbara
	- GET - (Guid) returnera om det �r spelarens tur


- GamePiece
	- UPDATE - (GamePiece) Uppdaterar spelarens position