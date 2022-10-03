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

        if(HasPlacedTokenWon(move) == GameWonStatus.GameWon) return PlaceTokenResult.GameWon;


        return PlaceTokenResult.Success;

    }

    private GameWonStatus HasPlacedTokenWon(Move move)
    {
        BoardToken token = move.CompareToken(BoardToken.O) ? BoardToken.O : BoardToken.X;

        if (IsHorizontalWin(token, move) == GameWonStatus.GameWon) return IsHorizontalWin(token, move);
        if (IsVerticalWin(token, move) == GameWonStatus.GameWon) return IsVerticalWin(token, move);
        if (IsDiagonalWin(token, move) == GameWonStatus.GameWon) return IsDiagonalWin(token, move);

        return GameWonStatus.GameNotWon;
    }

    private GameWonStatus IsDiagonalWin(BoardToken token, Move move)
    {
        if (_moves.Any(x => x.Equals(new Move(token, new Coordinate(0, 0)))) &&
            _moves.Any(x => x.Equals(new Move(token, new Coordinate(1, 1)))) &&
            _moves.Any(x => x.Equals(new Move(token, new Coordinate(2, 2)))))
            return GameWonStatus.GameWon;

        if (_moves.Any(x => x.Equals(new Move(token, new Coordinate(0, 2)))) &&
            _moves.Any(x => x.Equals(new Move(token, new Coordinate(1, 1)))) &&
            _moves.Any(x => x.Equals(new Move(token, new Coordinate(2, 0)))))
            return GameWonStatus.GameWon;

        return GameWonStatus.GameNotWon;
    }

    private GameWonStatus IsHorizontalWin(BoardToken token, Move move)
    {
        for (int rowIndex = 0; rowIndex < 3; rowIndex++)
        {
            if(_moves.Any(x => x.Equals(new Move(token, new Coordinate(0, rowIndex)))) &&
                    _moves.Any(x => x.Equals(new Move(token, new Coordinate(1, rowIndex)))) &&
                    _moves.Any(x => x.Equals(new Move(token, new Coordinate(2, rowIndex)))))
                return GameWonStatus.GameWon;
        }

        return GameWonStatus.GameNotWon;
    }

    private GameWonStatus IsVerticalWin(BoardToken token, Move move)
    {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++)
        {
            if (_moves.Any(x => x.Equals(new Move(token, new Coordinate(columnIndex, 0)))) &&
                _moves.Any(x => x.Equals(new Move(token, new Coordinate(columnIndex, 1)))) &&
                _moves.Any(x => x.Equals(new Move(token, new Coordinate(columnIndex, 2)))))
                return GameWonStatus.GameWon;
        }

        return GameWonStatus.GameNotWon;
    }

}