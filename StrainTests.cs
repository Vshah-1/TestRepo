using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StrainExercise;

namespace Strain
{
    internal class StrainTests
    {
        [Test]
        public void Empty_keep()
        {
            Assert.AreEqual(new LinkedList<int>(), new LinkedList<int>().Keep(x => x < 10));
        }
        [Test]
        public void Keep_everything()
        {
            Assert.AreEqual(new HashSet<int> { 1, 2, 3 }, new HashSet<int> { 1, 2, 3 }.Keep(x => x < 10));
        }
        [Test]
        public void Keep_first_and_last()
        {
            Assert.AreEqual(new[] { 1, 3 }, new[] { 1, 2, 3 }.Keep(x => x % 2 != 0));
        }
        [Test]
        public void Keep_neither_first_nor_last()
        {
            Assert.AreEqual(new List<int> { 2, 4 }, new List<int> { 1, 2, 3, 4, 5 }.Keep(x => x % 2 == 0));
        }
        [Test]
        public void Keep_strings()
        {
            var words = "apple zebra banana zombies cherimoya zelot".Split(' ');
            Assert.AreEqual("zebra zombies zelot".Split(' '), words.Keep(x => x.StartsWith("z")));
        }
        [Test]
        public void Keep_arrays()
        {
            var actual = new[]
                {
            new[] { 1, 2, 3 },
            new[] { 5, 5, 5 },
            new[] { 5, 1, 2 },
            new[] { 2, 1, 2 },
            new[] { 1, 5, 2 },
            new[] { 2, 2, 1 },
            new[] { 1, 2, 5 }
        };
            var expected = new[] { new[] { 5, 5, 5 }, new[] { 5, 1, 2 }, new[] { 1, 5, 2 }, new[] { 1, 2, 5 } };
            Assert.AreEqual(expected, actual.Keep(x => x.Contains(5)));
        }
        [Test]
        public void Empty_discard()
        {
            Assert.AreEqual(new LinkedList<int>(), new LinkedList<int>().Discard(x => x < 10));
        }
        [Test]
        public void Discard_nothing()
        {
            Assert.AreEqual(new HashSet<int> { 1, 2, 3 }, new HashSet<int> { 1, 2, 3 }.Discard(x => x > 10));
        }
        [Test]
        public void Discard_first_and_last()
        {
            Assert.AreEqual(new[] { 2 }, new[] { 1, 2, 3 }.Discard(x => x % 2 != 0));
        }
        [Test]
        public void Discard_neither_first_nor_last()
        {
            Assert.AreEqual(new List<int> { 1, 3, 5 }, new List<int> { 1, 2, 3, 4, 5 }.Discard(x => x % 2 == 0));
        }
        [Test]
        public void Discard_strings()
        {
            var words = "apple zebra banana zombies cherimoya zelot".Split(' ');
            Assert.AreEqual("apple banana cherimoya".Split(' '), words.Discard(x => x.StartsWith("z")));
        }
        [Test]
        public void Discard_arrays()
        {
            var actual = new[]
                {
            new[] { 1, 2, 3 },
            new[] { 5, 5, 5 },
            new[] { 5, 1, 2 },
            new[] { 2, 1, 2 },
            new[] { 1, 5, 2 },
            new[] { 2, 2, 1 },
            new[] { 1, 2, 5 }
        };
            var expected = new[] { new[] { 1, 2, 3 }, new[] { 2, 1, 2 }, new[] { 2, 2, 1 } };
            Assert.AreEqual(expected, actual.Discard(x => x.Contains(5)));
        }
    }
}
