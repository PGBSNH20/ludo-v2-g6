using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestApi.Models;
using RestApi.Repositories.Contracts;

namespace TestRestApi
{
    class GamePieceRepositoryTest : IGamePieceRepository
    {
        private static readonly Guid _playerGuid1 = new("5fcf2bb0-1111-1234-92a4-0359ead79af4");
        private static readonly Guid _playerGuid2 = new("5fcf2bb0-2222-1234-92a4-0359ead79af4");

        private static readonly Guid _boardGuid1 = new("5fcf2bb0-4444-1234-92a4-0359ead79af4");

        private static readonly Guid _pieceGuid1 = new("5fcf2bb0-6666-1234-92a4-0359ead79af4");

        public async Task<bool> UpdatePositionAsync(GameBoard gameBoard, GamePiece gamePiece, int diceRoll)
        {
            await Task.Delay(1);
            if (gamePiece.Id == _pieceGuid1)
                return true;
            return false;
        }

        public GamePiece IsPieceInGoal(GamePiece gamePiece)
        {
            throw new NotImplementedException();
        }

        public GamePiece SendToNest(GameBoard gameBoard, GamePiece gamePiece)
        {
            throw new NotImplementedException();
        }

        public GamePiece GetGamePiece(GameBoard gameBoard, Guid id)
        {
            return new()
            {
                CurrentPosition = 16,
                Id = id,
                IsInGoal = false,
                StartingPosition = 13,
                StepsTaken = 3
            };
        }

        public async Task<List<GamePieceDTO>> GetGamePiecesDtoAsync(Guid gameBoardId)
        {
               await Task.Delay(1);
               if (gameBoardId == _boardGuid1)
               {
                   var list = new List<GamePieceDTO>();

                   list.Add(new GamePieceDTO
                   {
                       CurrentPosition = "21",
                       Color = "red",
                       PieceId = "",
                       GameBoardId = _boardGuid1.ToString(),
                       GamePlayerId = _playerGuid1.ToString()

                   });

                   list.Add(new GamePieceDTO
                   {
                       CurrentPosition = "42",
                       Color = "red",
                       PieceId = "",
                       GameBoardId = _boardGuid1.ToString(),
                       GamePlayerId = _playerGuid2.ToString()

                   });
                   return list;
               }

               return null;
            }
        }
    }


