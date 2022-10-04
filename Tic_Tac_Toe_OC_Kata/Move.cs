namespace Tic_Tac_Toe_OC_Kata;

public class Move : IEquatable<Move>
{
    private readonly BoardToken _boardToken;

    private readonly Coordinate _coordinate;

    public Move(BoardToken boardToken, Coordinate coordinate)
    {
        _boardToken = boardToken;
        _coordinate = coordinate;
    }

    public bool CompareCoordinates(Move move)
    {
        return _coordinate.Equals(move._coordinate);
    }

    public bool CompareCoordinates(Coordinate coordinate)
    {
        return _coordinate.Equals(coordinate);
    }

    public bool CompareRow(Move move)
    {
        return _coordinate.EqualsRow(move._coordinate);
    }

    public bool CompareToken(BoardToken token)
    {
        return token == _boardToken;
    }
    public bool CompareToken(Move move)
    {
        return move._boardToken == _boardToken;
    }

    public bool Equals(Move? other)
    {
        if (other == null) return false;

        return (other._boardToken == _boardToken && 
                other._coordinate.Equals(_coordinate));
    }
}