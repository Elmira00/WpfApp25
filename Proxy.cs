using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_Task4
{       
    public class CacheProxy
    {
        public List<string> WordsProxy;
        public CacheProxy()
        {
            WordsProxy = new List<string>();
        }

        public List<string> GetValues(string value)
        {
            List<string> values = new List<string>();
            foreach (var word in WordsProxy)
            {
                if (word.ToLower().StartsWith(value))
                {
                    values.Add(word);
                }
            }
            return values;
        }

        public void AddWord(string word)
        {
            WordsProxy.Add(word);
        }

        public void SetWords()
        {
            WordsProxy.Add("apple");
            WordsProxy.Add("animal");
            WordsProxy.Add("anti");
            WordsProxy.Add("blue");
            WordsProxy.Add("black");
            WordsProxy.Add("blend");
            WordsProxy.Add("circlar");
            WordsProxy.Add("circle");
            WordsProxy.Add("cell");
        }
    }
}
