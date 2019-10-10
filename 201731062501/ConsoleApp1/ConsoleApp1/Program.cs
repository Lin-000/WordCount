using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class Program
    {
        /*  统计字符串中文本行数 */
        public static int LinesNum(string text)
        {
            int line = 0;
            line = Regex.Matches(text, @"\r").Count + 1;  // 默认从0开始故需要+1
            return line;                                  
        }

        /*  统计一个集合中单词出现的频率  */
        public static Dictionary<string, int> WordFrequence ( List<string> wordList )
        { 
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (string word in wordList)            // 遍历集合中每个单词
            {
                int value;
                if (dictionary.TryGetValue(word, out value))
                {
                    // 存在则将频率值 +1
                    dictionary[word] += 1;
                }
                else
                {
                    // 不存在，则添加到集合中
                    dictionary.Add(word, 1);
                }
            }
            return dictionary;
        }

 

        /*  将字符串写入文件  */
        public static void FileWrite(string path, string str)
        {                                              
            // path为指定路径的文件 str为要写入文件的字符串
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(str);
            sw.Close();
            fs.Close();
        }
        static void Main(string[] args)
        {
            string inputPath = @"D:\test\WordCount\201731062501\ConsoleApp1\ConsoleApp1\input.txt";    // 输入文件的路径
            string outputPath = @"D:\test\WordCount\201731062501\ConsoleApp1\ConsoleApp1\output.txt";  // 输出文件的路径
            int m = 0;                                                                                 // 单词(至少以4个英文字母开头)个数
            int n = 10;                                                                                // 统计10个最高频率单词
            if (args.Length == 4)                                                                
            {   // 当命令行参数只有 -i 与 -o 参数时     
                inputPath = args[1];
                outputPath = args[3];
            }
            else                                                                                
            {   // 命令行参数不止有-i与-o参数时    
                for (int i = 0; i < args.Length; i++)
                {
                    if (string.Equals(args[i], "-i"))                                  
                        inputPath = args[i + 1];
                    if (string.Equals(args[i], "-o"))                                
                        outputPath = args[i + 1];
                    if (string.Equals(args[i], "-m"))                              
                        m = int.Parse(args[i + 1]);
                    if (string.Equals(args[i], "-n"))                               
                        n = int.Parse(args[i + 1]);
                }
            }
            string text = File.ReadAllText(inputPath).ToLower();                                          // 读取文本内容并全部转成小写字母
            int ch_num = GetCharactersNum.CharactersNum(text);                                                             // 所有字符总数
            List<string> wordList = GetWordsNum.WordsNum(text);                                                       // 字符串中所有单词集合（包括重复的单词）
            Dictionary<string, int> d = GetMaxFrequence.MaxFrequence(WordFrequence(wordList), n);                         // 最高频率的10个单词及其出现频率
            int word = wordList.Count;                                                                    // 所有单词的总数
            int nr = LinesNum(text);                                                                      // 行数
            string str = String.Format("characters:{0}\r\nwords:{1}\r\nlines:{2}\r\n", ch_num, word, nr); // 构造要输出的信息字符串
            StringBuilder sb = new StringBuilder();
            foreach (string s in d.Keys)
            {
                sb.Append(string.Format("{0}，频率：{1}\r\n", s, d[s]));
            }
            str += sb.ToString();
            FileWrite(outputPath, str);  // 将输出的信息字符串写入指定路径的文件
        }
    }
}
