using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Repositories.Contracts
{
    public interface IGamePlayerRepository
    {
        Task<List<GamePiece>> GetGamePiecesAsync(Guid id);
        Task<bool> IsGamePlayerValidAsync(Guid id);
        bool IsMoveOutPossible(GameBoard gameBoard, Guid id);
    }
}
