using chessAPI.models.game;

namespace chessAPI.business.interfaces;

public interface IGameBusiness<TI> 
    where TI : struct, IEquatable<TI>
{
    Task<clsGame<TI>> createGame(clsNewGame<TI> newGame);
    Task<clsGame<TI>>? getGameById(TI id);
    Task<clsGame<TI>>? updateGame(TI id, clsUpdateGame<TI> newGame);
}