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
            Assert.IsTrue(_ticTacToe.PlaceToken("X"));
        }

        [Test]
        public void Not_Allow_O_To_Go_First()
        {
            Assert.IsFalse(_ticTacToe.PlaceToken("O"));
        }

        [Test]
        public void Allow_O_To_Be_Placed_After_X()
        {
            _ticTacToe.PlaceToken("X");
            Assert.IsTrue(_ticTacToe.PlaceToken("O"));
        }

        [Test]
        public void Not_Allow_X_Twice_In_A_Row()
        {
            _ticTacToe.PlaceToken("X");
            Assert.IsFalse(_ticTacToe.PlaceToken("X"));
        }

        [Test]
        public void Not_Allow_O_Twice_In_A_Row()
        {
            _ticTacToe.PlaceToken("X");
            _ticTacToe.PlaceToken("O");
            Assert.IsFalse(_ticTacToe.PlaceToken("O"));
        }
    }
}