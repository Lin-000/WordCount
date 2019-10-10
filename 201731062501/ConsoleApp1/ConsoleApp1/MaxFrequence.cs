using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class GetMaxFrequence
    {

        /* 找出单词字典中出现频率最高的n个单词  */
        public static Dictionary<string, int> MaxFrequence(Dictionary<string, int> dic, int n)
        {
            // dic储存单词及出现频率的字典 n为需要输出单词个数
            Dictionary<string, int> d = new Dictionary<string, int>();
            int x = 0;
            // 判断需要的单词个数是否超出总单词个数
            if (n <= dic.Count)
            {
                x = n;
            }
            else
            {
                x = dic.Count;
            }
            while (d.Count < x)
            {
                List<string> l = new List<string>();    // 多个单词有相同频率时储存至这个临时集合中按字典顺序排序
                int maxValue = dic.Values.Max(); ;      // 单词的最高频率
                foreach (string s in dic.Keys)
                {
                    if (dic[s] == maxValue)             // 获取拥有最高频率的单词
                    {
                        l.Add(s);                       // 添加到临时集合中
                    }
                }
                foreach (string s in l)                 // 将单词从原来的字典中删除 准备下一次查找
                {
                    dic.Remove(s);
                }
                l.Sort(string.CompareOrdinal);
                foreach (string s in l)
                {
                    d.Add(s, maxValue);
                    if (d.Count >= x)                   // 获取到10个单词后就退出
                        break;
                }
            }
            return d;
        }

        /*  将字符串写入文件  */
    }
}
