﻿namespace Tic_Tac_Toe_OC_Kata;

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

        if (IsHorizontalWin(move) == GameWonStatus.GameWon) return PlaceTokenResult.GameWon;

        if (_moves.Any(x => x.Equals(new Move(BoardToken.X, new Coordinate(0, 0)))) &&
            _moves.Any(x => x.Equals(new Move(BoardToken.X, new Coordinate(0, 1)))) &&
            _moves.Any(x => x.Equals(new Move(BoardToken.X, new Coordinate(0, 2)))))


            return PlaceTokenResult.Success;

    }

    private GameWonStatus IsHorizontalWin(Move move)
    {
        BoardToken token = move.CompareToken(BoardToken.O) ? BoardToken.O : BoardToken.X;

        for (int rowIndex = 0; rowIndex < 3; rowIndex++)
        {
            if(_moves.Any(x => x.Equals(new Move(token, new Coordinate(0, rowIndex)))) &&
                    _moves.Any(x => x.Equals(new Move(token, new Coordinate(1, rowIndex)))) &&
                    _moves.Any(x => x.Equals(new Move(token, new Coordinate(2, rowIndex)))))
                return GameWonStatus.GameWon;
        }

        return GameWonStatus.GameNotWon;
    }
}