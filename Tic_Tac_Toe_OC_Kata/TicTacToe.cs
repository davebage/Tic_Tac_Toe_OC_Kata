namespace Tic_Tac_Toe_OC_Kata;

public class MoveHistory
{
    private readonly List<Move> _moves = new List<Move>();

    public PlaceTokenResult AddMove(Move move)
    {
        if (!_moves.Any() && move.CompareToken(BoardToken.O))
            return PlaceTokenResult.Failure;

        if (_moves.Any() && move.CompareToken(_moves.Last()))
            return PlaceTokenResult.Failure;

        if (_moves.Any(x => x.CompareCoordinates(move)))
            return PlaceTokenResult.Failure;

        _moves.Add(move);

        for (int rowIndex = 0; rowIndex < 3; rowIndex++)
        {
            if (_moves.Any(x => x.Equals(new Move(BoardToken.X, new Coordinate(0, rowIndex)))) &&
                _moves.Any(x => x.Equals(new Move(BoardToken.X, new Coordinate(1, rowIndex)))) &&
                _moves.Any(x => x.Equals(new Move(BoardToken.X, new Coordinate(2, rowIndex)))))
                return PlaceTokenResult.GameWon;
        }

        for (int rowIndex = 0; rowIndex < 3; rowIndex++)
        {
            if (_moves.Any(x => x.Equals(new Move(BoardToken.O, new Coordinate(0, rowIndex)))) &&
                _moves.Any(x => x.Equals(new Move(BoardToken.O, new Coordinate(1, rowIndex)))) &&
                _moves.Any(x => x.Equals(new Move(BoardToken.O, new Coordinate(2, rowIndex)))))
                return PlaceTokenResult.GameWon;
        }

        return PlaceTokenResult.Success;

    }


}


public class TicTacToe
{
    private readonly MoveHistory _moveHistory = new MoveHistory();

    public PlaceTokenResult PlaceToken(Move move)
    {
        return _moveHistory.AddMove(move);
    }
}