using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
namespace ConsoleApp1
{
   public class GetWordsNum
    {
        /*  统计字符串中所有单词的总数 */
        public static List<string> WordsNum(string text)
        {
            List<string> words = new List<string>();
            MatchCollection matches = Regex.Matches(text, @"[A-Za-z]{4}[A-Za-z0-9]*(\W|$)"); // 利用正则实现匹配
            foreach (Match match in matches)
            {
                words.Add(match.Value);
            }
            return words;                                // 返回一个储存了所有单词的集合(包括重复的单词)
        }

    }
}
