namespace chessAPI.dataAccess.queries.postgreSQL;

public sealed class qGame : IQGame
{
    private const string _selectAll = @"
    SELECT id, started, whites, blacks, turn, winner 
    FROM public.game";

    private const string _selectOne = @"
    SELECT id, started, whites, blacks, turn, winner 
    FROM public.game
    WHERE id=@ID";

    private const string _add = @"
    INSERT INTO public.game(whites, blacks, turn, winner)
	VALUES (@ID, NULL, TRUE, NULL) RETURNING id";

    private const string _delete = @"
    DELETE FROM public.game 
    WHERE id = @ID";
    
    private const string _update = @"
    UPDATE public.game
	SET blacks=@BLACKS
	WHERE id=@ID";

    public string SQLGetAll => _selectAll;

    public string SQLDataEntity => _selectOne;

    public string NewDataEntity => _add;

    public string DeleteDataEntity => _delete;

    public string UpdateWholeEntity => _update;

    private const string _teamExists = @"
    SELECT id 
    FROM public.team
    WHERE id=@ID";

    private const string _playerIsValid = @"
    SELECT tp.id
    FROM public.team_player tp
    WHERE tp.team_id = @BLACKS AND EXISTS (
        SELECT tp2.id
        FROM public.team_player tp2
        WHERE tp2.team_id = @WHITES AND tp.player_id = tp2.player_id
    )";

   public string TeamExists => _teamExists;

   public string PlayerIsValid => _playerIsValid;
}