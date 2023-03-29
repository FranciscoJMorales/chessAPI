using chessAPI.dataAccess.models;
using chessAPI.models.piece;
using MongoDB.Bson;
using MongoDB.Driver;

namespace chessAPI.dataAccess.repositores;

public sealed class clsPieceRepository : IPieceRepository
{
    private readonly IMongoCollection<clsPieceEntityModel> pieceCollection;

    public clsPieceRepository(IMongoCollection<clsPieceEntityModel> pieceCollection)
    {
        this.pieceCollection = pieceCollection;
    }

    private async Task<long> getLastPiece()
    {
        //Empty document tells the driver to count all the documents in the collection
        return await pieceCollection.CountDocumentsAsync(new BsonDocument());
    }

    public async Task addPiece(clsNewPiece newPiece)
    {
        var newId = await getLastPiece().ConfigureAwait(false) + 1;
        await pieceCollection.InsertOneAsync(new clsPieceEntityModel(newPiece, newId)).ConfigureAwait(false);
    }

    public async Task<clsPieceEntityModel?> getPiece(long id)
    {
        var filter = Builders<clsPieceEntityModel>.Filter.Eq(r => r.id, id);
        return await pieceCollection.Find(filter).FirstOrDefaultAsync().ConfigureAwait(false);
    }
}
