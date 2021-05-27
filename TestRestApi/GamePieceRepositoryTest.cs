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
        private static readonly Guid _boardGuid2 = new Guid("5fcf2bb0-5555-1234-92a4-0359ead79af4");

        private static readonly Guid _pieceGuid1 = new Guid("5fcf2bb0-6666-1234-92a4-0359ead79af4");
        private static readonly Guid _pieceGuid2 = new Guid("5fcf2bb0-7777-1234-92a4-0359ead79af4");

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
            return new GamePiece()
            {
                CurrentPosition = 16,
                Id = id,
                IsInGoal = false,
                StartingPosition = 13,
                StepsTaken = 3
            };
        }

        public Task<List<GamePieceDTO>> GetGamePiecesDtoAsync(Guid gameBoardId)
        {
            throw new NotImplementedException();
        }
    }
}
