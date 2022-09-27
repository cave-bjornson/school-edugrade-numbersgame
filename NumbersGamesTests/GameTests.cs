using Microsoft.VisualStudio.TestPlatform.TestHost;
using NumbersGame;

namespace NumbersGameTests
{
    public class GameTests
    {
        private const int Low = 1;
        private const int High = 20;
        private readonly Game _game = new ();

        [Fact]
        private void CheckRandomNumber_InRange_ReturnTrue()
        {
            Assert.InRange(_game.Number, Low, High);
        }

        [Fact]
        public void CheckGuess_SameInput_ReturnTrue()
        {
            var result = _game.CheckGuess(_game.Number);
            Assert.True(result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1)]
        public void CheckGuess_LowerHigherInput_ReturnFalse(int value)
        {
            var result = _game.CheckGuess(_game.Number + value);
            Assert.False(result);
        }
    }
}