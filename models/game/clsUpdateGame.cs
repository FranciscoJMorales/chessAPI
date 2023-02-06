namespace chessAPI.models.game;

public sealed class clsUpdateGame<TI>
    where TI : struct, IEquatable<TI>
{
    public clsUpdateGame()
    {
        blacks = default(TI);
    }

    public TI blacks { get; set; }
}