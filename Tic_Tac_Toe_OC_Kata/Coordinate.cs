namespace Tic_Tac_Toe_OC_Kata;

public class Coordinate : IEquatable<Coordinate>
{
    private readonly int _column;

    private readonly int _row;

    public Coordinate(int column, int row)
    {
        _column = column;
        _row = row;
    }


    public bool Equals(Coordinate? other)
    {
        if (other == null) return false;

        return other._column == _column && 
               other._row == _row;
    }
}