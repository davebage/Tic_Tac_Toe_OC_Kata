namespace Tic_Tac_Toe_OC_Kata;

public class TicTacToe
{
    private BoardToken _lastPlacedToken = BoardToken.O;

    public PlaceTokenResult PlaceToken(Move move)
    {
        var placeTokenResult = new PlaceTokenResult();

        if (move.CompareToken(_lastPlacedToken))
            placeTokenResult.Successful = false;
        
        if (!placeTokenResult.Successful) return placeTokenResult;

        _lastPlacedToken = move.GetToken();

        return placeTokenResult;
    }
}