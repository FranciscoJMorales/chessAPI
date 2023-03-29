using chessAPI.models.piece;

namespace chessAPI.business.interfaces;

public interface IPieceBusiness
{
    Task<clsPiece?> getPiece(long id);
    Task createPiece(clsNewPiece newPiece);
}
