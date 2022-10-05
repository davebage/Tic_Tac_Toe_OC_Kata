using NUnit.Framework;
using Tic_Tac_Toe_OC_Kata;

namespace Tic_Tac_Toe_OC_Kata_Tests
{

    [TestFixture]
    public class Tic_Tac_Toe_Should
    {
        TicTacToe _ticTacToe;

        [SetUp]
        public void SetUp()
        {
            _ticTacToe = new TicTacToe();
        }

        [Test]
        public void Allow_X_To_Go_First()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
        }

        [Test]
        public void Not_Allow_O_To_Go_First()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Failure));
        }

        [Test]
        public void Allow_O_To_Be_Placed_After_X()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
        }

        [Test]
        public void Not_Allow_X_Twice_In_A_Row()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Middle)), Is.EqualTo(PlaceTokenResult.Failure));
        }

        [Test]
        public void Not_Allow_O_Twice_In_A_Row()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));


            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Top)), Is.EqualTo(PlaceTokenResult.Failure));
        }

        [Test]
        public void Not_Allow_O_To_Play_On_Played_Position()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Failure));
        }

        [Test]
        public void Check_X_Won_Along_Bottom_Row_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Middle, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Middle, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Right, Row.Bottom)), Is.EqualTo(PlaceTokenResult.GameWon));
        }

        [Test]
        public void Check_X_Won_Along_Middle_Row_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Middle, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Middle, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Right, Row.Middle)), Is.EqualTo(PlaceTokenResult.GameWon));
        }

        [Test]
        public void Check_X_Won_Along_Top_Row_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Top)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Middle, Row.Top)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Middle, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Right, Row.Top)), Is.EqualTo(PlaceTokenResult.GameWon));
        }


        [Test]
        public void Check_O_Won_Along_Bottom_Row_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Middle, Row.Top)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Middle, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Top)), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Right, Row.Bottom)), Is.EqualTo(PlaceTokenResult.GameWon));
        }

        [Test]
        public void Check_O_Won_Along_Middle_Row_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Middle, Row.Top)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Middle, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Top)), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Right, Row.Middle)), Is.EqualTo(PlaceTokenResult.GameWon));
        }

        [Test]
        public void Check_O_Won_Along_Top_Row_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Top)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Middle, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Middle, Row.Top)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Right, Row.Top)), Is.EqualTo(PlaceTokenResult.GameWon));
        }


        [Test]
        public void Check_X_Won_Along_Left_Column_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Middle, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Middle, Row.Top)), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Top)), Is.EqualTo(PlaceTokenResult.GameWon));
        }

        [Test]
        public void Check_X_Won_Along_Middle_Column_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Middle, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Middle, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Top)), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Middle, Row.Top)), Is.EqualTo(PlaceTokenResult.GameWon));
        }

        [Test]
        public void Check_X_Won_Along_Right_Column_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Right, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Right, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Top)), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Right, Row.Top)), Is.EqualTo(PlaceTokenResult.GameWon));
        }

        [Test]
        public void Check_O_Won_Along_Left_Column_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Middle, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Middle, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Right, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Top)), Is.EqualTo(PlaceTokenResult.GameWon));
        }

        [Test]
        public void Check_O_Won_Along_Middle_Column_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Middle, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Middle, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Right, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Middle, Row.Top)), Is.EqualTo(PlaceTokenResult.GameWon));
        }

        [Test]
        public void Check_O_Won_Along_Right_Column_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Right, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Right, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Middle, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Right, Row.Top)), Is.EqualTo(PlaceTokenResult.GameWon));
        }

        [Test]
        public void Check_X_Won_Diagonally_From_Bottom_Left_To_Top_Right_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Middle, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Top)), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Right, Row.Top)), Is.EqualTo(PlaceTokenResult.GameWon));
        }


        [Test]
        public void Check_O_Won_Diagonally_From_Bottom_Left_To_Top_Right_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Middle, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Right, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Middle, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Right, Row.Top)), Is.EqualTo(PlaceTokenResult.GameWon));
        }

        [Test]
        public void Check_X_Won_Diagonally_From_Top_Left_To_Bottom_Right_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Top)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Middle, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Right, Row.Bottom)), Is.EqualTo(PlaceTokenResult.GameWon));
        }

        [Test]
        public void Check_O_Won_Diagonally_From_Top_Left_To_Bottom_Right_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Middle, Row.Bottom)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Left, Row.Top)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Middle, Row.Top)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Middle, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.X, Column.Left, Row.Middle)), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(CreateMove(BoardToken.O, Column.Right, Row.Bottom)), Is.EqualTo(PlaceTokenResult.GameWon));
        }

        private Move CreateMove(BoardToken token, Column column, Row row)
        {
            return new Move(token, new Coordinate(column, row));
        }
    }
}