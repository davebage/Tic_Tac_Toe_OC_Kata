namespace Tic_Tac_Toe_OC_Kata;

public class TicTacToe
{
    private readonly List<Move> _moves = new List<Move>();

    public PlaceTokenResult PlaceToken(Move move)
    {
        if (!_moves.Any() && move.CompareToken(BoardToken.O))
            return PlaceTokenResult.Failure;

        if (_moves.Any() && move.CompareToken(_moves.Last()))
            return PlaceTokenResult.Failure;

        if (_moves.Any(x => x.CompareCoordinates(move)))
            return PlaceTokenResult.Failure;

        _moves.Add(move);

        return PlaceTokenResult.Success;
    }
}