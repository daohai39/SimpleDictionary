using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly:
    InternalsVisibleTo("Dictionary.UnitTests")]
namespace Dictionary
{
    public class WordDictionary : ITranslatable
    {
        public WordDictionary()
        {
            Words = new Dictionary<string, string>();
        }

        public WordDictionary(Dictionary<string, string> words)
        {
            Words = words;
        }

        internal Dictionary<string, string> Words { get; }

        public virtual string Translate(string word)
        {
            if (string.IsNullOrWhiteSpace(word)) throw new ArgumentException("Word can not be empty");
            if (Words.Count == 0) throw new ArgumentOutOfRangeException(nameof(Words),"Dictionary does not have this yet!");
            return (Words.TryGetValue(word, out var translation)) ? translation : word;
        }

        public virtual void AddWord(string word, string translation)
        {
            if (string.IsNullOrWhiteSpace(word) || string.IsNullOrWhiteSpace(translation)) throw new ArgumentException("Word can not be empty");
            if (Words.ContainsKey(word)) Words.Remove(word);
            Words.Add(word, translation);
        }

        public virtual bool RemoveWord(string word)                                   
        {
            if (string.IsNullOrWhiteSpace(word)) throw new ArgumentException("Word can not be empty");
            if (Words.Count == 0) throw new ArgumentOutOfRangeException(nameof(Words), "Dictionary does not have this yet!");
            return Words.Remove(word);
        }

    }
}