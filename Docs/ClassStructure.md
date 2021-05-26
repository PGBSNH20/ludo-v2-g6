
# docker-compose
* .dockerignore
* docker-compose.yml: Innehåller våra docker-compose properties

# LudoGame: ASP.NET Core Web App
## wwwroot
### CSS
* LudoSheet.css
* site.css
### JS
* site.js
## Pages
#### Forms
* Player.cshtml: innehåller HTML för spelbrädan 
  - Player.cshtml.cs : innehåller c# koden för att hämta gameboard, gameplayers och gamepiece
#### Shared
* -ViewImports.cshtml
* -ViewStart.cshtml
* History.cshtml
  - History.cshtml.cs
* Index.cshtml
  - Index.cshtml.cs
#### appsettings.json
#### Program.cs
#### Startup.cs

# RestApi: ASP.NET Core Web API
## Controllers
* GameboardController.cs (board ska vara med stort B)
* GamePieceController.cs
## Migrations
## Models
### Requests
  - GetMoveRequest.cs
* Color.cs
* Dice.cs (de ska bort)
* GameBoard.cs
* GameBoardDTO.cs
* GamePiece.cs
* GamePieceDTO.cs
* GamePlayer.cs
## Repositories
#### Contracts: innehåller våra interfaces
   - IGameBoardRepository.cs
   - IGamePieceRepository.cs
   - IGamePlayerRepository.cs
   - IRepository.cs
* GameBoardRepository.cs
* GamePieceRepository.cs
* GamePlayerRepository.cs
* Repository.cs
## Services
#### appsettings.json
#### Dockerfile
#### Program.cs
#### Startup.cs

# TestRestApi: Projekt för testing med Xunit, innehåller testklasser med stub för våra repon
* GameBoardRepositoryTest.cs: ärver av IGameBoardRepository
* GamePieceRepositoryTest.cs: ärver av IGamePieceRepository
* GamePlayerRepositoryTest.cs: ärver av IGamePlayerRepository
* UnitTest.cs: Håller tester för metoder relaterade till requests








