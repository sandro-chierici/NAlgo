using NAlgo.Sorting;

namespace Test
{
    public class TestTopKElements
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Top4Int()
        {
            var arr = new int[] { 1, 6, 8, 9, 10, 87, 3, 3, 4 };

            var top4 = Elements.Top<int>(arr, 4);

            Assert.True(top4.Length == 4);

            Assert.True(top4.Sum() == 114);
        }

        [Test]
        public void Top4IntFromArrayShorter()
        {
            var arr = new int[] { 1, 6, 8 };

            var top4 = Elements.Top<int>(arr, 4);

            Assert.True(top4.Length == 3);

            Assert.True(top4.Sum() == 15);
        }

        [Test]
        public void EmptyArray()
        {
            var arr = new int[] { };

            var top4 = Elements.Top<int>(arr, 4);

            Assert.True(top4.Length == 0);
        }

        [Test]
        public void Top4String()
        {
            var arr = new string[] { "b", "cd", "ciao", "Pippo", "Arrivederci" };

            var top4 = Elements.Top<string>(arr, 4);

            Assert.True(top4.Length == 4);
        }

        [Test]
        public void HighLoadStraight()
        {
            var arr = Enumerable.Range(0, 100000)
                .ToArray();

            var top4 = Elements.Top<int>(arr, 12000);

            Assert.True(top4.Length == 12000);
        }

        [Test]
        public void HighLoadReverse()
        {
            var arr = Enumerable.Range(0, 100000).Reverse()
                .ToArray();

            var top4 = Elements.Top<int>(arr, 12000);

            Assert.True(top4.Length == 12000);
        }

    }
}