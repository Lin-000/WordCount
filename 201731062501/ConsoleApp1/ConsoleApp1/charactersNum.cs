using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class GetCharactersNum
    {
        /*  统计字符串中所有字符总数 */
        public static int CharactersNum(string text)     // text为要统计的字符串
        {
            int num = 0;
            num = Regex.Matches(text, @"[\S| ]").Count;
            return num;                                  // 返回字符总个数
        }
    }
}
