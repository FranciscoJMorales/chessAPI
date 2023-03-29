using chessAPI.dataAccess.repositores;
using chessAPI.models.piece;
using chessAPI.business.interfaces;

namespace chessAPI.business.impl;

public sealed class clsPieceBusiness : IPieceBusiness
{
    internal readonly IPieceRepository pieceRepository;

    public clsPieceBusiness(IPieceRepository pieceRepository) => this.pieceRepository = pieceRepository;

    public async Task createPiece(clsNewPiece newPiece) => await pieceRepository.addPiece(newPiece).ConfigureAwait(false);

    public async Task<clsPiece?> getPiece(long id)
    {
        var x = await pieceRepository.getPiece(id).ConfigureAwait(false);
        return x != null ? (clsPiece)x : null;
    }
}
