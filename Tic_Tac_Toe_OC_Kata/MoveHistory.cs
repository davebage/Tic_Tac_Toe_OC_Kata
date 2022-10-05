namespace Tic_Tac_Toe_OC_Kata;

public class MoveHistory
{
    private readonly List<Move> _moves = new List<Move>();
    private const int WINNING_TOKEN_COUNT = 3;
    private const int MINIMUM_NUMBER_OF_MOVES_FOR_WIN = 5;

    public PlaceTokenResult AddMove(Move move)
    {
        if (!_moves.Any() && move.CompareToken(BoardToken.O))
            return PlaceTokenResult.Failure;

        if (_moves.Any() && move.CompareToken(_moves.Last()))
            return PlaceTokenResult.Failure;

        if (_moves.Any(x => x.CompareCoordinates(move)))
            return PlaceTokenResult.Failure;

        _moves.Add(move);

        if (HasPlacedTokenWon(move) == GameWonStatus.GameWon) return PlaceTokenResult.GameWon;

        return PlaceTokenResult.Success;
    }

    private GameWonStatus HasPlacedTokenWon(Move move)
    {
        if (_moves.Count < MINIMUM_NUMBER_OF_MOVES_FOR_WIN)
            return GameWonStatus.GameNotWon;

        var loopCounter = 0;
        var primaryDiagonalCount = 0;
        var secondaryDiagonalCount = 0;

        while (loopCounter < WINNING_TOKEN_COUNT)
        {
            primaryDiagonalCount += _moves.Count(x => x.CompareToken(move) && x.CompareCoordinates(new Coordinate((Column)loopCounter,
                (Row)loopCounter)));
            secondaryDiagonalCount += _moves.Count(x => x.CompareToken(move) && x.CompareCoordinates(new Coordinate((Column)loopCounter, 
                (Row)(WINNING_TOKEN_COUNT - 1) - loopCounter)));
            loopCounter++;
        }

        if (primaryDiagonalCount == WINNING_TOKEN_COUNT || secondaryDiagonalCount == WINNING_TOKEN_COUNT)
            return GameWonStatus.GameWon;

        if (_moves.Count(x => x.CompareToken(move) && x.CompareRow(move)) == WINNING_TOKEN_COUNT)
            return GameWonStatus.GameWon;

        if (_moves.Count(x => x.CompareToken(move) && x.CompareColumn(move)) == WINNING_TOKEN_COUNT)
            return GameWonStatus.GameWon;

        return GameWonStatus.GameNotWon;
    }
}