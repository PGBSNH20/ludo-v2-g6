
## docker-compose
* .dockerignore
* docker-compose.yml: Innehåller våra docker-compose properties

## LudoGame: ASP.NET Core Web App
### wwwroot
- **CSS\\**
  - LudoSheet.css
  - site.css
### JS
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
### Controllers
* GameboardController.cs (board ska vara med stort B)
* GamePieceController.cs
### Migrations
### Models
- **Requests\\**
  - GetMoveRequest.cs
* Color.cs
* GameBoard.cs
* GameBoardDTO.cs
* GamePiece.cs
* GamePieceDTO.cs
* GamePlayer.cs
### Repositories
- **Contracts\\** innehåller våra interfaces
   - IGameBoardRepository.cs
   - IGamePieceRepository.cs
   - IGamePlayerRepository.cs
   - IRepository.cs
* GameBoardRepository.cs
* GamePieceRepository.cs
* GamePlayerRepository.cs
* Repository.cs
### Services
* LudoContext.cs
#### appsettings.json
#### Dockerfile.json
#### Program.cs
#### Startup.cs

## TestRestApi: projekt för testing med Xunit
* GameBoardRepositoryTest.cs: ärver av IGameBoardRepository
* GamePieceRepositoryTest.cs: ärver av IGamePieceRepository
* GamePlayerRepositoryTest.cs: ärver av IGamePlayerRepository
* UnitTest.cs: Håller tester för metoder relaterade till requests








