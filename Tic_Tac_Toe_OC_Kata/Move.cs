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

    public bool CompareToken(BoardToken other)
    {
        return other == _boardToken;
    }

    public BoardToken GetToken()
    {
        return _boardToken;
    }
}