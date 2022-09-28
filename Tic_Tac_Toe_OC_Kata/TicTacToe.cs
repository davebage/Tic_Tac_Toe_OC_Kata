namespace Tic_Tac_Toe_OC_Kata;

public class TicTacToe
{
    private string _lastPlacedToken = string.Empty;

    public bool? PlaceToken(string token)
    {
        if (token == "O" && _lastPlacedToken == "X")
        {
            _lastPlacedToken = "O";
            return true;
        }

        if (token == "O") return false;

        _lastPlacedToken = token;

        return true;
    }
}