using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]

        /*任意输入一个字符串，获取其长度Length保存至一个变量中
         * 调用统计字符串中所有字符总数函数CharactersNumTest()
         * 该返回值应与输入的字符串长度相等
         */
        public void CharactersNumTest()
        {
            string stringTest = "abcdefg 1234141";
            int result = stringTest.Length;
            int testResult = GetCharactersNum.CharactersNum(stringTest);
            Assert.AreEqual(result, testResult);
        }

        [TestMethod()]
        public void WordsNumTest()
        {
            /*上述输入的字符串中每个单词都满足至少4个英文字母开头的要求
              * 故统计结果应与上述字符串中单词总数相等
              */
            string wordsTest = "hello,world nice beautiful";
            List<string> wordList = GetWordsNum.WordsNum(wordsTest);
            Assert.AreEqual(4, wordList.Count);

            /*上述输入的字符串中不是每个单词都满足至少4个英文字母开头的要求
             * 故统计结果应与上述字符串中单词总数不相等
             */
            string wordsTest2 = "hello,world nice beautiful you hat";
            List<string> wordList2 = GetWordsNum.WordsNum(wordsTest2);
            Assert.AreNotEqual(6, wordList2.Count);
            //Assert.Fail();


        }

        [TestMethod()]
        public void LinesNumTest()
        {
            string linesTest = "";
            int testResult = Program.LinesNum(linesTest);
            Assert.AreEqual(1, testResult);
        }

        [TestMethod()]
        public void WordFrequenceTest()
        {
            string wordFrequenceTest = File.ReadAllText(@"D:\test\WordCount\201731062501\ConsoleApp1\ConsoleApp1\bin\Debug\test.txt");
            List<string> wordList = GetWordsNum.WordsNum(wordFrequenceTest);
            Dictionary<string, int> dictionary = Program.WordFrequence(wordList);
            foreach (KeyValuePair<string, int> kvp in dictionary)
            {
                Console.WriteLine("word：{0},frenquency：{1}", kvp.Key, kvp.Value);
            }
        }

        [TestMethod()]
        public void MaxFrequenceTest()
        {
            string wordFrequenceTest = File.ReadAllText(@"D:\test\WordCount\201731062501\ConsoleApp1\ConsoleApp1\bin\Debug\test.txt");
            List<string> wordList = GetWordsNum.WordsNum(wordFrequenceTest);
            Dictionary<string, int> dictionary = GetMaxFrequence.MaxFrequence(Program.WordFrequence(wordList), 10);
            foreach (KeyValuePair<string, int> kvp in dictionary)
            {
                Console.WriteLine("word：{0},frenquency：{1}", kvp.Key, kvp.Value);
            }

        }


    }
}
 