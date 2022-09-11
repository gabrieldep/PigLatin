using KisTechTest;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string word = "Hey you, you shot 1, but not 2, bullet at my eye!";
            string translation = "Eyhay youyay, youyay otshay 1, utbay otnay 2, ulletbay atay ymay eyeyay!";
            Assert.Equal(translation, word);
        }

        [Fact]
        public void Test2()
        {
            string word = "";
            string translation = "";
            Assert.Equal(word, translation);
        }

        [Fact]
        public void Test3()
        {
            string word = "";
            string translation = "";
            Assert.Equal(word, translation);
        }

        [Fact]
        public void Test4()
        {
            string word = "";
            string translation = "";
            Assert.Equal(word, translation);
        }

        [Fact]
        public void Test5()
        {
            string word = "";
            string translation = "";
            Assert.Equal(word, translation);
        }

        [Fact]
        public void Test6()
        {
            string word = "";
            string translation = "";
            Assert.Equal(word, translation);
        }

        [Fact]
        public void Test7()
        {
            string word = "";
            string translation = "";
            Assert.Equal(word, translation);
        }
    }
}