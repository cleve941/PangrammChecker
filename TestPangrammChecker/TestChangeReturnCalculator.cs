using Pangramm;
using NUnit.Framework;

namespace TestPangrammChecker
{
    public class TestPangrammChecker
    {
        private PangrammChecker checker;
        [SetUp]
        public void Setup()
        {
            checker = new PangrammChecker();
        }

        [Test]
        public void CheckForMultipleLetters()
        {
            checker.setInputString("The quick brown fox jumps over the lazy dog");

            Assert.AreEqual(checker.containsAllAlphabetLettersMoreThanOnce, true);
            Assert.AreEqual(checker.doesNotContainAllAlphabetLettersOnce, false);
            Assert.AreEqual(checker.containsAllLettersExactlyOnce, false);

        }

        [Test]
        public void CheckForNumbersAndOtherLetters()
        {
            checker.setInputString("The quick brown fox jumps over the lazy dogÄÖ213");

            Assert.AreEqual(checker.containsAllAlphabetLettersMoreThanOnce, true);
            Assert.AreEqual(checker.doesNotContainAllAlphabetLettersOnce, false);
            Assert.AreEqual(checker.containsAllLettersExactlyOnce, false);

        }

        [Test]
        public void CheckForExactlyOnce()
        {

            checker.setInputString("abcdefghijklmnopqrstuvwxyz12ÄüÖ");

            Assert.AreEqual(checker.containsAllAlphabetLettersMoreThanOnce, false);
            Assert.AreEqual(checker.doesNotContainAllAlphabetLettersOnce, false);
            Assert.AreEqual(checker.containsAllLettersExactlyOnce, true);

        }
        [Test]
        public void CheckForNotAllLetters()
        {
            // y is missing
            checker.setInputString("The quick brown fox jumps over the laz dogÄÖ213");

            Assert.AreEqual(checker.containsAllAlphabetLettersMoreThanOnce, false);
            Assert.AreEqual(checker.doesNotContainAllAlphabetLettersOnce, true);
            Assert.AreEqual(checker.containsAllLettersExactlyOnce, false);

        }
    }
}