using System;
using NUnit.Framework;

namespace Dictionary.UnitTests
{
    [TestFixture]
    public class DictionaryAppTests
    {
        [TestCase("home", "nhà")]
        [TestCase("house", "house")]
        public void Translate_ByDefault_ReturnsAString(string inputWord, string expectedOutput)
        {
            var dictionaryApp = MakeDictionary();

            var result = dictionaryApp.Translate(inputWord);

            Assert.That(result, Is.EqualTo(expectedOutput).IgnoreCase);
        }

        [TestCase("")]
        public void Translate_InvalidWord_ThrowsException(string invalidWord)
        {
            var dictionaryApp = MakeDictionary();

            var result = Assert.Throws<ArgumentException>(() => dictionaryApp.Translate(invalidWord));

            Assert.That(result.Message, Does.Contain("Word can not be empty").IgnoreCase);
        }

        private DictionaryApp MakeDictionary()
        {
            return new DictionaryApp(new FakeWordDictionary());
        }

        private  class FakeWordDictionary : WordDictionary
        {
            public override string Translate(string word)
            {
                if (word.Equals("home", StringComparison.CurrentCultureIgnoreCase))
                    return "nhà";
                return word;
            }

            public override void AddWord(string word, string translation)
            {
                throw new System.NotImplementedException();
            }

            public override bool RemoveWord(string word)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
