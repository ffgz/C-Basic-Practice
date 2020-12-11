using System.Text.RegularExpressions;
using System.Text;
using System;
using System.IO;

namespace Demo
{
    class RegexTest
    {
        public void regexDemo()
        {
            string str = "1851 1999 1950 1905 2003";
            // (?<=19)匹配19后的字符串 \d{2}匹配十进制数字的前2个 \b匹配边界（空格的位置）
            string pattern = @"(?<=19)\d{2}\b";    
            // string pattern1 = @"\bS\S*";    // 匹配以S开头的单词
            // string pattern2 = @"\bm\S*e\b"; // 匹配以m开头以e结尾的单词
            foreach(Match match in Regex.Matches(str,pattern))
                Console.WriteLine(match.Value);
        }
        public void replaceDemo()
        {
            // 正则表达式实例 替换多余的空格
            string str = "Hello   World ";
            string pattern = "\\s+";
            Regex regex = new Regex(pattern);  // Regex类用于表示一个正则表达式
            Console.WriteLine(str);
            Console.WriteLine(regex.Replace(str," "));
        }
        public void fileDemo(string path)
        {
            // 查找文本中的IP地址
            StreamReader sr = new StreamReader(path,Encoding.Default);
            string content;
            string pattern = @"(\d{1,3})\.(\d{1,3})\.(\d{1,3})";
            while((content = sr.ReadLine()) != null){
                // Console.WriteLine(content.ToString());
                foreach(Match match in Regex.Matches(content,pattern))
                    Console.WriteLine(match.Value);
            }
        }

        public void showMatch(Match match)
        {
            // 整体提取
            if(match.Success){ 
                Console.WriteLine($"匹配结果: {match.Value}"); 
            }

            // 局部提取
            foreach(Group group in match.Groups){ 
                Console.WriteLine($"    Group: {group.Value}");
            }
        }
        public void findallDemo()
        {
            Console.WriteLine("输入测试文本:");
            string text = Console.ReadLine();
            Console.WriteLine("请输入正则表达式:");
            string pattern = Console.ReadLine();
            Regex regex = new Regex(pattern);

            if(!regex.IsMatch(text)){ Console.WriteLine("检测不通过!"); }
            else{
                Console.WriteLine("检测通过!");
                Console.WriteLine("显示首个匹配");
                showMatch(regex.Match(text));

                Console.WriteLine("显示全部匹配");
                MatchCollection matches = regex.Matches(text);
                foreach(Match match in matches){
                    showMatch(match);
                }
            }
        }
    }
}