
## docker-compose
* .dockerignore
* docker-compose.yml: Innehåller våra docker-compose properties

## LudoGame: ASP.NET Core Web App
### wwwroot
- **CSS\\**
  - LudoSheet.css
  - site.css
- **JS\\**
- **signalr\\**
  - **dist\\**
    - **browser\\**
      - signalr.js 
* chat.js
* site.js
### Hubs
* ChatHub.cs
### Pages
- **Forms\\**
    - Player.cshtml: innehåller HTML för spelbrädan 
    - Response.cshtml.cs: 
- **Shared\\**
  - _layout.cshtml
  - _loginPartial.cshtml
  - _ValidationScriptsPartial.cshtml
* _ViewImports.cshtml
* _ViewStart.cshtml
* History.cshtml
  - History.cshtml.cs
* Index.cshtml
  - Index.cshtml.cs
#### appsettings.json
#### libman.json
#### Program.cs
#### Startup.cs


## RestApi: ASP.NET Core Web API
### Controllers : innehåller HTTP requests
* GameBoardController.cs: innehåller get och post metoder som hämtar alla sparade gameboards, hämtar ett visst gameboard genom ett gameboardId(Guid), skapar ett nytt spel, updaterar positionen på pjäserna, tur på spelare samt kollar för en vinnare. 
* GamePieceController.cs : innehåller en get metod som hämtar alla pjäsar som tillhör ett gameboard genom att gameboardId(Guid)
### Migrations EF Migrations
### Models: innehåller klasserna
- **Requests\\**
  - GetMoveRequest.cs
* Color.cs
* GameBoard.cs
* GameBoardDTO.cs: nedskalad version av Gameboard utan känslig information (Guid)
* GamePiece.cs
* GamePieceDTO.cs: nedskalad version av gamepiece utan känslig information (Guid)
* GamePlayer.cs
### Repositories: innehåller interfaces och repon för ett repository pattern
- **Contracts\\** innehåller våra interfaces
   - IGameBoardRepository.cs
   - IGamePieceRepository.cs
   - IGamePlayerRepository.cs
   - IRepository.cs
* GameBoardRepository.cs: innehåller metoder som används i GameBoardController(requests)
* GamePieceRepository.cs: innehåller metoder som används i GamePieceController(requests)
* GamePlayerRepository.cs: innehåller metoder som används i GameBoardController(requests)
* Repository.cs: innehåller alla metoder som kommuniverar med databasen 
### Services
* LudoContext.cs: representerar tabbellerna i databasen  
#### appsettings.json
#### Dockerfile.json
#### Program.cs
#### Startup.cs


## TestRestApi: projekt för testing med Xunit
* GameBoardRepositoryTest.cs: ärver av IGameBoardRepository
* GamePieceRepositoryTest.cs: ärver av IGamePieceRepository
* GamePlayerRepositoryTest.cs: ärver av IGamePlayerRepository
* UnitTest.cs: Håller tester för metoder relaterade till requests








