using NumbersGame;

namespace NumbersGameTests
{
    public class GameTests
    {
        private const int Low = 1;
        private const int High = 20;
        private const int MaxTries = 5;
        private readonly Game _game = new();

        [Fact]
        public void CheckRandomNumber_InRange_ReturnTrue()
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

        [Fact]
        public void TriesRemain_LessThanZero_ReturnFalse()
        {
            for (int i = 0; i <= MaxTries; i++)
            {
                _game.CheckGuess(_game.Number + 1);
            }
            Assert.False(_game.TriesRemain());
        }
    }
}