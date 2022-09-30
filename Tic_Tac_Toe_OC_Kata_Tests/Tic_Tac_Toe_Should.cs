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
            Assert.IsTrue(result.Successful);
        }

        [Test]
        public void Not_Allow_O_To_Go_First()
        {
            var result = _ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 0)));

            Assert.IsFalse(result.Successful);
        }

        [Test]
        public void Allow_O_To_Be_Placed_After_X()
        {
            _ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 0)));
            var result = _ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 1)));

            Assert.IsTrue(result.Successful);
        }

        [Test]
        public void Not_Allow_X_Twice_In_A_Row()
        {
            _ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 0)));
            var result = _ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 1)));

            Assert.IsFalse(result.Successful);
        }

        [Test]
        public void Not_Allow_O_Twice_In_A_Row()
        {
            _ticTacToe.PlaceToken(new Move(BoardToken.X, new Coordinate(0, 0)));
            _ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 1)));

            var result = _ticTacToe.PlaceToken(new Move(BoardToken.O, new Coordinate(0, 2)));

            Assert.IsFalse(result.Successful);
        }
    }
}