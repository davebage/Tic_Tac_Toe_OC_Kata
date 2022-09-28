using NUnit.Framework;
using Tic_Tac_Toe_OC_Kata;

namespace Tic_Tac_Toe_OC_Kata_Tests
{
    [TestFixture]
    public class Tic_Tac_Toe_Should
    {
        [Test]
        public void Allow_X_To_Go_First()
        {
            TicTacToe ticTacToe = new TicTacToe();
            Assert.IsTrue(ticTacToe.PlaceToken("X"));
        }

        [Test]
        public void Not_Allow_O_To_Go_First()
        {
            TicTacToe ticTacToe = new TicTacToe();
            Assert.IsFalse(ticTacToe.PlaceToken("O"));
        }

        [Test]
        public void Allow_O_To_Be_Placed_After_X()
        {
            TicTacToe ticTacToe = new TicTacToe();
            ticTacToe.PlaceToken("X");
            Assert.IsTrue(ticTacToe.PlaceToken("O"));
        }
    }
}