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
            var result = _ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 0)));
            Assert.That(result, Is.EqualTo(PlaceTokenResult.Success));
        }

        [Test]
        public void Not_Allow_O_To_Go_First()
        {
            var result = _ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 0)));

            Assert.That(result, Is.EqualTo(PlaceTokenResult.Failure));
        }

        [Test]
        public void Allow_O_To_Be_Placed_After_X()
        {
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 0))), Is.EqualTo(PlaceTokenResult.Success));
            var result = _ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 1)));

            Assert.That(result, Is.EqualTo(PlaceTokenResult.Success));
        }

        [Test]
        public void Not_Allow_X_Twice_In_A_Row()
        {
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 0))), Is.EqualTo(PlaceTokenResult.Success));
            var result = _ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 1)));

            Assert.That(result, Is.EqualTo(PlaceTokenResult.Failure));
        }

        [Test]
        public void Not_Allow_O_Twice_In_A_Row()
        {
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 0))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 1))), Is.EqualTo(PlaceTokenResult.Success));

            var result = _ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 2)));

            Assert.That(result, Is.EqualTo(PlaceTokenResult.Failure));
        }

        [Test]
        public void Not_Allow_O_To_Play_On_Played_Position()
        {
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 0))), Is.EqualTo(PlaceTokenResult.Success));

            var result = _ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 0)));

            Assert.That(result, Is.EqualTo(PlaceTokenResult.Failure));
        }

        [Test]
        public void Check_X_Won_Along_Bottom_Row_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 0))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 1))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(1, 0))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(1, 1))), Is.EqualTo(PlaceTokenResult.Success));
            var result = _ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(2, 0)));
            Assert.That(result, Is.EqualTo(PlaceTokenResult.GameWon));
        }

        [Test]
        public void Check_X_Won_Along_Middle_Row_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 1))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 0))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(1, 1))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(1, 0))), Is.EqualTo(PlaceTokenResult.Success));
            var result = _ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(2, 1)));
            Assert.That(result, Is.EqualTo(PlaceTokenResult.GameWon));
        }

        [Test]
        public void Check_X_Won_Along_Top_Row_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 2))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 0))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(1, 2))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(1, 0))), Is.EqualTo(PlaceTokenResult.Success));
            var result = _ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(2, 2)));
            Assert.That(result, Is.EqualTo(PlaceTokenResult.GameWon));
        }


        [Test]
        public void Check_O_Won_Along_Bottom_Row_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 1))), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 0))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(1, 2))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(1, 0))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 3))), Is.EqualTo(PlaceTokenResult.Success));
            var result = _ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(2, 0)));
            Assert.That(result, Is.EqualTo(PlaceTokenResult.GameWon));
        }

        [Test]
        public void Check_O_Won_Along_Middle_Row_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 0))), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 1))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(1, 2))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(1, 1))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 3))), Is.EqualTo(PlaceTokenResult.Success));
            var result = _ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(2, 1)));
            Assert.That(result, Is.EqualTo(PlaceTokenResult.GameWon));
        }

        [Test]
        public void Check_O_Won_Along_Top_Row_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 0))), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 2))), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(1, 1))), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(1, 2))), Is.EqualTo(PlaceTokenResult.Success));

            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 1))), Is.EqualTo(PlaceTokenResult.Success));
            var result = _ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(2, 2)));
            Assert.That(result, Is.EqualTo(PlaceTokenResult.GameWon));
        }


        [Test]
        public void Check_X_Won_Along_Left_Column_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 0))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(1, 1))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 1))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(1, 2))), Is.EqualTo(PlaceTokenResult.Success));
            var result = _ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 2)));
            Assert.That(result, Is.EqualTo(PlaceTokenResult.GameWon));
        }

        [Test]
        public void Check_X_Won_Along_Middle_Column_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(1, 0))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 1))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(1, 1))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 2))), Is.EqualTo(PlaceTokenResult.Success));
            var result = _ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(1, 2)));
            Assert.That(result, Is.EqualTo(PlaceTokenResult.GameWon));
        }

        [Test]
        public void Check_X_Won_Along_Right_Column_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(2, 0))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 1))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(2, 1))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 2))), Is.EqualTo(PlaceTokenResult.Success));
            var result = _ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(2, 2)));
            Assert.That(result, Is.EqualTo(PlaceTokenResult.GameWon));
        }

        [Test]
        public void Check_O_Won_Along_Left_Column_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(1, 0))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 0))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(1, 1))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 1))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(2, 1))), Is.EqualTo(PlaceTokenResult.Success));
            var result = _ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 2)));
            Assert.That(result, Is.EqualTo(PlaceTokenResult.GameWon));
        }

        [Test]
        public void Check_O_Won_Along_Middle_Column_After_Three_Plays()
        {
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 0))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(1, 0))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 1))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(1, 1))), Is.EqualTo(PlaceTokenResult.Success));
            Assert.That(_ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(2, 1))), Is.EqualTo(PlaceTokenResult.Success));
            var result = _ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(1, 2)));
            Assert.That(result, Is.EqualTo(PlaceTokenResult.GameWon));
        }


    }


}