using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    //按指定长度输出词组 
    public  class CountPhrase
    {
        // wordList 为已经筛选后的四个字母以上的单词集合，wordGroupNum为长度
        public static Dictionary<string, int> WordsGroups(List<string> wordList, int wordGroupNum)
        {
            // 创建字典用于保存 -m 功能的字符数组
            Dictionary<string, int> wordsGroup = new Dictionary<string, int>();
   
            int i;
            int j = 0;
            // 循环判断 -m 后输入的数字，截取对应长度的词组
            for (i = 0; i <= wordList.Count - wordGroupNum; i++)
            {
                // str 用来临时存储当前单词个数为 wordGroupNum 的词组
                string str = "";
                for (j = i; j < wordGroupNum + i; j++)
                {
                    str += wordList[j];
                }
                // 对词组频率进行统计
                if (wordsGroup.ContainsKey(str))
                {
                    // 如果词组已经存在，则频率 +1
                    wordsGroup[str] += 1;
                }
                else
                {
                    // 否则加入新的字典中
                    wordsGroup.Add(str, 1);
                }
             

            }
            return wordsGroup;
        }
      
         

}
}
