using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Dictionary.UnitTests
{
    [TestFixture]
    public class WordDictionaryTests
    {
        [TestCase("home", "nhà")]
        [TestCase("dog", "chó")]
        public void Translate_ByDefault_ReturnsAValueStringAssociatedWithTheKey(string inputWord, string expectedTranslation)
        {
            var testDictionary = new Dictionary<string, string>();
            testDictionary.Add(inputWord, expectedTranslation);
            var dictionary = new WordDictionary(testDictionary);

            var result = dictionary.Translate(inputWord);

            Assert.That(result, Is.EqualTo(expectedTranslation).IgnoreCase);
        }

        [TestCase("")]
        public void Translate_InvalidWord_ThrowsException(string invalidWord)
        {
            var dictionary = new WordDictionary();

            var result = Assert.Throws<ArgumentException>(() => dictionary.Translate(invalidWord));

            Assert.That(result.Message, Does.Contain("Word can not be empty").IgnoreCase);
        }

        [Test]
        public void Translate_ListIsEmpty_ThrowsException()
        {
            var dictionary = new WordDictionary();
            var word = "Any words";

            var result = Assert.Throws<ArgumentOutOfRangeException>(() => dictionary.Translate(word));

            Assert.That(result.Message, Does.Contain("Dictionary does not have this yet!").IgnoreCase);
        }

        [Test]
        public void Translate_UnknownWord_ReturnInputWord()
        {
            var wordList = new Dictionary<string, string> { { "give", "cho" } };
            var dictionary = new WordDictionary(wordList);
            var unknownWord = "home";

            var result = dictionary.Translate(unknownWord);

            Assert.That(result, Is.EqualTo(result));
        }

        [TestCase("home", "nhà")]
        public void AddWord_ByDefault_AddANewPairOfKeyAndValueToList(string word, string translation)
        {
            var dictionary = new WordDictionary();
            var expectedWordList = new Dictionary<string, string> { { word, translation } };

            dictionary.AddWord(word, translation);

            Assert.That(dictionary.Words, Is.EquivalentTo(expectedWordList));
        }

        [TestCase("", "Ok")]
        [TestCase("Ok", "")]
        [TestCase("", "")]
        public void AddWord_InvalidWord_ThrowsException(string invalidWord, string invalidTranslation)
        {
            var dictionary = new WordDictionary();

            var result = Assert.Throws<ArgumentException>(() => dictionary.AddWord(invalidWord, invalidTranslation));

            Assert.That(result.Message, Does.Contain("Word can not be empty").IgnoreCase);
        }

        [Test]
        public void AddWord_ListAlreadyHasWord_ReplaceTranslation()
        {
            var oldTranslation = "nhà";
            var newTranslation = "ngôi nhà";
            var wordList = new Dictionary<string, string> { { "home", oldTranslation } };
            var dictionary = new WordDictionary(wordList);

            dictionary.AddWord("home", newTranslation);

            Assert.That(dictionary.Words.ContainsValue(newTranslation), Is.True);
            Assert.That(dictionary.Words.ContainsValue(oldTranslation), Is.False);
        }

        [TestCase("home", "nhà")]
        public void RemoveWord_ByDefault_RemoveAPairOfKeyAndValueFromListAndReturnsTrue(string word, string translation)
        {
            var wordList = new Dictionary<string, string> { { word, translation } };
            var dictionary = new WordDictionary(wordList);

            var result = dictionary.RemoveWord(word);

            Assert.That(result, Is.True);
            Assert.That(dictionary.Words, Does.Not.ContainKey(word));
        }

        [TestCase("")]
        public void RemoveWord_InvalidWord_ThrowsException(string invalidWord)
        {
            var dictionary = new WordDictionary();

            var result = Assert.Throws<ArgumentException>(() => dictionary.RemoveWord(invalidWord));

            Assert.That(result.Message, Does.Contain("Word can not be empty").IgnoreCase);
        }

        [Test]
        public void RemoveWord_WordIsUnknow_ReturnFalse()
        {
            var wordList = new Dictionary<string, string> { { "give", "cho" } };
            var dictionary = new WordDictionary(wordList);
            var unknownWord = "uknown word";

            var result = dictionary.RemoveWord(unknownWord);

            Assert.That(result, Is.False);

        }

        [Test]
        public void RemoveWord_ListIsEmpty_ThrowsException()
        {
            var dictionary = new WordDictionary();

            var result = Assert.Throws<ArgumentOutOfRangeException>(() => dictionary.RemoveWord("any word"));

            Assert.That(result.Message, Does.Contain("Dictionary does not have this yet!").IgnoreCase);
        }

        private WordDictionary MakeDictionary()
        {
            return new WordDictionary();
        }
    }
}

