using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class CountPhraseTests
    {
        [TestMethod()]
        public void WordsGroupsTest()

        {
            string wordFrequenceTest = File.ReadAllText(@"D:\test\WordCount\201731062501\ConsoleApp1\ConsoleApp1\bin\Debug\test.txt");
            List<string> wordList = GetWordsNum.WordsNum(wordFrequenceTest);
            Dictionary<string, int> wordsGroup = CountPhrase.WordsGroups(wordList,3);
            foreach (KeyValuePair<string, int> kvp in wordsGroup)
            {
                Console.WriteLine("词组：{0},出现的频率：{1}", kvp.Key, kvp.Value);
            }
           
        }
    }
}