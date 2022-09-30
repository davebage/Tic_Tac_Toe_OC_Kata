namespace Tic_Tac_Toe_OC_Kata;

public class Coordinate
{
    public int Column;

    public int Row;
}

public class Move
{
    public BoardToken boardToken;

    public Coordinate coordinate;
}

public class TicTacToe
{
    private BoardToken? _lastPlacedToken;

    public PlaceTokenResult PlaceToken(Move move)
    {
        var placeTokenResult = new PlaceTokenResult();

        if (!_lastPlacedToken.HasValue && move.boardToken == BoardToken.O || move.boardToken == _lastPlacedToken)
            placeTokenResult.Successful = false;
        
        if (!placeTokenResult.Successful) return placeTokenResult;

        _lastPlacedToken = move.boardToken;

        return placeTokenResult;
    }
}