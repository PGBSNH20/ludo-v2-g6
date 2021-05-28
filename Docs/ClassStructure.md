
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
### Controllers : contains HTTP requests
* GameBoardController.cs: contains get and post methods that return all available gameboards from the database, return a specific gameboard from the database, add/create a new gamaboard to database, update a gameboard, piecesposition, playerturn and winner to database
* GamePieceController.cs: contains get method that return all pieces belonging to a specific gameboard
### Migrations EF Migrations
### Models: contains our classes 
- **Requests\\**
  - GetMoveRequest.cs: class that returns strings instead of int when passing an object 
* Color.cs
* GameBoard.cs
* GameBoardDTO.cs: contains data in a string format 
* GamePiece.cs
* GamePieceDTO.cs: contains the same GamePiececlass properties/data but in a string format 
* GamePlayer.cs
### Repositories: contains interfaces and repo to the repository pattern
- **Contracts\\** contains our interfaces
   - IGameBoardRepository.cs
   - IGamePieceRepository.cs
   - IGamePlayerRepository.cs
   - IRepository.cs
* GameBoardRepository.cs: contains methods we use in GameBoardController(requests)
* GamePieceRepository.cs: contains methods we use in GamePieceController(requests)
* GamePlayerRepository.cs: contains methods we use in GameBoardController(requests)
* Repository.cs: it contains all the methods that communicate with the database
### Services
* LudoContext.cs: represents the tables in the database  
#### appsettings.json
#### Dockerfile.json
#### Program.cs
#### Startup.cs


## TestRestApi: project tests with Xunit
* GameBoardRepositoryTest.cs: inherits from IGameBoardRepository
* GamePieceRepositoryTest.cs: inherits from IGamePieceRepository
* GamePlayerRepositoryTest.cs: inherits from IGamePlayerRepository
* UnitTest.cs: contains tests for the methods related to the requests








