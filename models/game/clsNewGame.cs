namespace chessAPI.models.game;

public sealed class clsNewGame<TI>
    where TI : struct, IEquatable<TI>
{
    public clsNewGame()
    {
        whites = default(TI);
    }

    public TI whites { get; set; }
}