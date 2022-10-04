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
        if (_moves.Count(x => x.CompareToken(move) &&
                              (x.CompareCoordinates(new Coordinate(0, 0)) ||
                              x.CompareCoordinates(new Coordinate(1, 1)) ||
                              x.CompareCoordinates(new Coordinate(2, 2)))) == 3)
            return GameWonStatus.GameWon;


        if (_moves.Count(x => x.CompareToken(move) &&
                              (x.CompareCoordinates(new Coordinate(0, 2)) ||
                              x.CompareCoordinates(new Coordinate(1, 1)) ||
                              x.CompareCoordinates(new Coordinate(2, 0)))) == 3)
            return GameWonStatus.GameWon;

        var loopCounter = 0;
        var tokenCount = 0;
        while (loopCounter < 3 && tokenCount < 3)
        {
            tokenCount = _moves.Count(x => x.CompareToken(move) &&
                                               (x.CompareCoordinates(new Coordinate(0, loopCounter)) ||
                                                x.CompareCoordinates(new Coordinate(1, loopCounter)) ||
                                                x.CompareCoordinates(new Coordinate(2, loopCounter))));

            loopCounter++;
        }

        for (int columnIndex = 0; columnIndex < 3; columnIndex++)
        {
            if (_moves.Count(x => x.CompareToken(move) &&
                                  (x.CompareCoordinates(new Coordinate(columnIndex, 0)) ||
                                  x.CompareCoordinates(new Coordinate(columnIndex, 1)) ||
                                  x.CompareCoordinates(new Coordinate(columnIndex, 2)))) == 3)
                return GameWonStatus.GameWon;
        }

        if(tokenCount == 3) return GameWonStatus.GameWon;

        return GameWonStatus.GameNotWon;
    }

    private GameWonStatus IsDiagonalWin(BoardToken token)
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

    private GameWonStatus IsHorizontalWin(BoardToken token)
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

    private GameWonStatus IsVerticalWin(BoardToken token)
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