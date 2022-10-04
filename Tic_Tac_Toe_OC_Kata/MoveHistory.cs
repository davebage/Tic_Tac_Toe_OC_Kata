﻿namespace Tic_Tac_Toe_OC_Kata;

public class MoveHistory
{
    private readonly List<Move> _moves = new List<Move>();
    private const int WINNING_TOKEN_AMOUNT = 3;

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
        var loopCounter = 0;
        var isTokenMatching = true;

        while (loopCounter < 3 && isTokenMatching)
        {
            isTokenMatching = _moves.Any(x => x.CompareToken(move) &&
                                              x.CompareCoordinates(new Coordinate(loopCounter, loopCounter)));
            loopCounter++;
        }

        if (isTokenMatching) return GameWonStatus.GameWon;

        loopCounter = 0;
        isTokenMatching = true;
        while (loopCounter < 3 && isTokenMatching)
        {
            isTokenMatching = _moves.Any(x => x.CompareToken(move) &&
                                              x.CompareCoordinates(new Coordinate(loopCounter, 2 - loopCounter)));
            loopCounter++;
        }

        if (isTokenMatching) return GameWonStatus.GameWon;


        if (_moves.Count(x => x.CompareToken(move) && x.CompareRow(move)) == WINNING_TOKEN_AMOUNT) 
            return GameWonStatus.GameWon;

        if(_moves.Count(x => x.CompareToken(move) && x.CompareColumn(move)) == WINNING_TOKEN_AMOUNT) 
            return GameWonStatus.GameWon;

        return GameWonStatus.GameNotWon;
    }


}