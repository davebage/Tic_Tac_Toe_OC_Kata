namespace Tic_Tac_Toe_OC_Kata;

    public enum Column
    {
        Left = 0,
        Middle = 1,
        Right = 2
    }

    public enum Row
    {
        Bottom = 0,
        Middle = 1,
        Top = 2
    }

public class Coordinate : IEquatable<Coordinate>
{
    private readonly Column _column;

    private readonly Row _row;

    public Coordinate(Column column, Row row)
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

    public bool EqualsRow(Coordinate coordinate)
    {
        return coordinate._row == _row;
    }

    public bool EqualsColumn(Coordinate coordinate)
    {
        return coordinate._column == _column;
    }
}