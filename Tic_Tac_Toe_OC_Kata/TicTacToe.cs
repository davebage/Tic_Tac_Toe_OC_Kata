namespace Tic_Tac_Toe_OC_Kata;

public class TicTacToe
{
    private readonly MoveHistory _moveHistory = new MoveHistory();

    public PlaceTokenResult PlaceToken(Move move)
    {
        return _moveHistory.AddMove(move);
    }
}