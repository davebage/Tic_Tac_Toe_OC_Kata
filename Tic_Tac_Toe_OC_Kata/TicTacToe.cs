namespace Tic_Tac_Toe_OC_Kata;

public class TicTacToe
{
    private string _lastPlacedToken = string.Empty;

    public bool? PlaceToken(string token)
    {
        if (_lastPlacedToken == String.Empty && token == "O") return false;

        if (token == _lastPlacedToken) return false;

        _lastPlacedToken = token;
        return true;
    }
}