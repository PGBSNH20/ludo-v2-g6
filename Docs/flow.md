## Index.html
    - Välj antal spelare
    - Tryck på knappen
        - Skicka värdet backend
        - Generera en länk per spelare

## 13/5

- Vi börjar med backend och får vårt API att fungera
- Get 
- Post
- Put

## 14/5 
ÄNTLIGEN funkar databasen!
Några metoder i Controllers kommer till

En tur i Ludo:
- RollDice(GamePlayer) - return int
- GetPlayablePieces(GamePlayer, DiceRoll) - return List<GamePiece>
    Hämtar GamePieces som står på banan och, om man slår 1 eller 6, i boet.
- CheckPossibleMoves(List<GamePiece>, RollDice) - return List<GamePiece>
    - IsCoastClear(GamePlayer, RollDice) return bool
        Kollar om kusten är klar för varje GamePiece i listan och lägger de möjliga i returlistan
- Move(GamePiece, DiceRoll)
    Uppdatera
    
