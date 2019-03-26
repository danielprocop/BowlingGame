using BowlingGame;
using System;
using Xunit;

namespace BowlingGameTest
{
    public class BowlingGameTest:IDisposable
    {
        private Game g;
        public BowlingGameTest()
        {
            g = new Game();
        }
        public void Dispose()
        {
            g = null;
        }
        [Fact]
        public void TestGutterGame()
        {
            RollMany(20, 0);
            Assert.Equal(0, g.Score());
        }
        private void RollMany(int n,int pins)
        {
            for (int i = 0; i < n; i++)
            {
                g.Roll(pins);
            }
        }
        [Fact]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.Equal(20, g.Score());
        }

        [Fact]
        public void TestOneSpare()
        {
            RollSpare();
            g.Roll(3);
            RollMany(17, 0);

            Assert.Equal(16, g.Score());
        }

        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }

        [Fact]
        public void TestOneStrike()
        {
            RollStrike();
            g.Roll(4);
            g.Roll(3);
            RollMany(16, 0);

            Assert.Equal(24, g.Score());
        }
        private void RollStrike()
        {
            g.Roll(10);
        }

        [Fact]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.Equal(300, g.Score());
        }
    }
}


//var exception = Record.Exception(() =>

//          );

//Assert.NotNull(exception);
//            Assert.IsType<ArgumentNullException>(exception);