namespace Tic_Tac_Toe_OC_Kata;

public class TicTacToe
{
    private readonly List<Move> _moves = new List<Move>();

    public PlaceTokenResult PlaceToken(Move move)
    {
        var placeTokenResult = new PlaceTokenResult();

        if(!_moves.Any() && move.CompareToken(BoardToken.O))
            placeTokenResult.Successful = false;

        if (_moves.Any() && move.CompareToken(_moves.Last()))
            placeTokenResult.Successful = false;

        if(_moves.Any(x => x.CompareCoordinates(move)))
            placeTokenResult.Successful = false;

        if (!placeTokenResult.Successful) return placeTokenResult;

        _moves.Add(move);

        return placeTokenResult;
    }
}