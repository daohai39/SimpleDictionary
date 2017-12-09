using System.Collections.Generic;

namespace Dictionary
{
    public class EnToVnWordDictionary : WordDictionary
    {
        public EnToVnWordDictionary()
            : base()
        {   
        }

        public EnToVnWordDictionary(Dictionary<string, string> words)
            : base(words)
        { 
        }
    }
}