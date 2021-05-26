## Api structure

- Gameboard
	- GET - (history) ) hämtar alla pågående och avslutade spel
	- GET - (Game) hämtar ett gameboard/spel baserat på dess id(GUID)
	- POST - (GameBoard) för att starta nytt spel
	- POST - (Move) validerar en move, uppdaterar position på pjäserna, uppdaterar spelarentur och uppdaterat en vinare och ändra state på ett spel


- GamePiece
	- GET - hämtar gamepieces (DTO) baserat gameId(Guid)
	
