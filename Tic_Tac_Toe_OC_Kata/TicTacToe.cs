namespace Tic_Tac_Toe_OC_Kata;

public class TicTacToe
{
    private BoardToken? _lastPlacedToken;

    public PlaceTokenResult PlaceToken(BoardToken boardToken)
    {
        var placeTokenResult = ValidateMove(boardToken);
        
        if (!placeTokenResult.Successful) return placeTokenResult;

        _lastPlacedToken = boardToken;

        return placeTokenResult;
    }

    private PlaceTokenResult ValidateMove(BoardToken boardToken)
    {
        var placeTokenResult = new PlaceTokenResult();

        if (!_lastPlacedToken.HasValue && boardToken == BoardToken.O || boardToken == _lastPlacedToken)
            placeTokenResult.Successful = false;

        return placeTokenResult;
    }
}