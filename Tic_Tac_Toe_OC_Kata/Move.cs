namespace Tic_Tac_Toe_OC_Kata;

public class Move
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

    public bool CompareColumn(Move move)
    {
        return _coordinate.EqualsColumn(move._coordinate);
    }
}