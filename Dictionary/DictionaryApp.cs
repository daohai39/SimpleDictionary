using System;

namespace Dictionary
{
    public class DictionaryApp
    {
        public DictionaryApp(WordDictionary dictionary)
        {
            Dictionary = dictionary;
        }

        private WordDictionary Dictionary { get; } 

        public string Translate(string inputWord)
        {
            if(string.IsNullOrWhiteSpace(inputWord)) throw new ArgumentException("Word can not be empty");
            return Dictionary.Translate(inputWord);
        }

    }
}