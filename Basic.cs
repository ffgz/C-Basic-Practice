using System.Text.RegularExpressions;
using System;
using System.IO;

namespace Demo
{
    struct Book
    {
        private string _title;
        public string title
        {
            get => _title;
            set{
                _title = value;
            }
        }
        public string author;
        public string subject;
        public int book_id;

        public void setValue(string t, string a, string s, int id)
        {
            _title = t;
            author = a;
            subject = s;
            book_id = id;
        }
        public void showInfo()
        {
            Console.WriteLine($"title: {_title}\nauthor: {author}\n" + 
                $"subject: {subject}\nbook_id: {book_id}\n");
        }
        
    };

    enum Day {Sun,Mon,Tue,Wed,Thu,Fri,Sat};

    class Basic
    {
        // 结构体
        public void structTest()
        {
            Book book1 = new Book();
            book1.title = "C Programming";
            book1.author = "Nuha Ali";
            book1.subject = "C Programming Tutorial";
            book1.book_id = 6495407;
            book1.showInfo();

            Book book2 = new Book();
            book2.setValue("Telecom Billing","Zara Ali","Telecom Billing Tutorial",6495700);
            book2.showInfo();
            
        }

        // 枚举
        public void enumTest()
        {
            int x = (int)Day.Sun;
            Console.WriteLine($"Sun = {x}");
        }

        // 字符串处理
        public void stringDemo()
        {
            // @逐字字符串 可将转义字符\当作普通字符 换行也可保存
            String str = @"\hello world!";
            Console.WriteLine(str + " " + str.Length);

            // 常用的数值格式化命令
            Console.WriteLine(String.Format("{0:C}",9));    // ￥9.00
            Console.WriteLine(String.Format("{0:X}",10));   // A
            Console.WriteLine(String.Format("{0:P}",0.1234));  // 12.34%
            Console.WriteLine(String.Format("{0:E}",1234)); // 1.234000E+003
            
            // 带格式字符串 {}内可进行运算
            Console.WriteLine($"{str}");

            // string构造函数
            char[] letters = {'H','e','l','l','o'};
            string greetings = new string(letters);
            Console.WriteLine($"greetings: {greetings}");

            // Join
            string[] sentences = {"Hello","World","!"};
            string message = String.Join(" ",sentences);
            Console.WriteLine($"message: {message}");

            // 格式化转换时间
            DateTime t = new DateTime(2020,11,23,21,53,35);
            string time = String.Format("Now is {0:t} on {0:d}",t);
            Console.WriteLine(time);

            // 正则表达式
            string str1 = "1851 1999 1950 1905 2003";
            // (?<=19)匹配19后的字符串 \d{2}匹配十进制数字的前2个 \b匹配边界（空格的位置）
            string pattern1 = @"(?<=19)\d{2}\b";    
            // string pattern2 = @"\bS\S*";    // 匹配以S开头的单词
            // string pattern3 = @"\bm\S*e\b"; // 匹配以m开头以e结尾的单词
            foreach(Match match in Regex.Matches(str1,pattern1))
                Console.WriteLine(match.Value);
            
            // 正则表达式实例 替换多余的空格
            string str2 = "Hello   World ";
            string pattern4 = "\\s+";
            Regex regex = new Regex(pattern4);  // Regex类用于表示一个正则表达式
            Console.WriteLine(str2);
            Console.WriteLine(regex.Replace(str2," "));
        }
        
        // 时间表示
        public void datetime()
        {
            // 日期时间处理应用
            DateTime.Now.ToShortTimeString();
            DateTime dt = DateTime.Now;
            Console.WriteLine(dt.ToString());   // xxxx/xx/xx xx:xx:xx 
        }
        
        // 进制转换
        public void baseConversion()
        {
            int a = 0b10;   // 2进制
            int b = 0x4b;   // 16进制
            Console.WriteLine(a + " " + b);
            // 进制转换 Convert.ToString(num,base)
            Console.WriteLine("75的8进制:" + Convert.ToString(75, 8));
            Console.WriteLine("0b10的10进制:" + Convert.ToString(0b10,10));
        }
        
        // 数组&循环
        public void array_foreachTest()
        {
            // 一维数组
            // int[] array1 = new int[10];
            // int[] array2 = {1,2,3};
            // int[] array3 = new int[5] {1,2,3,4,5};
            // int[] array4 = array3;
            int[] fibarray = new int[] { 0, 1, 1, 2, 3, 5, 8, 13 };
            // 排序可用Array.Sort
            //Array.Sort(fibarray);

            foreach (int element in fibarray)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine();
            // foreach类似如下for循环
            //for(int i=0 ; i<fibarray.Length ; i++)
            //{
            //    Console.Write(fibarray[i] + " ");
            //}

            // 多维数组
            // string[,] names;    // 二维
            // int[,,] m;       // 三维
            int[,] matrix = new int[3,4]{
                {0,1,2,3},
                {4,5,6,7},
                {8,9,10,11}
            };
            for(int i=0;i<3;i++)
            {
                for(int j=0;j<4;j++)
                {
                    Console.WriteLine($"matrix[{i},{j}] = {matrix[i,j]}");
                }
            }

            // 交错数组
            // int [][] scores1;   // 声明数组 不会在内存中创建
            // int [][] scores2 = new int[5][];    // 创建数组
            // for(int i=0 ; i<scores2.Length ; i++)
            // {
            //     scores2[i] = new int[4];
            // }
            int[][] scores3 = new int[2][]{new int[]{0,1,2}, new int[]{3,4,5,6}};
            for(int i =0 ; i<scores3.Length ; i++)
            {
                for(int j=0 ; j<scores3[i].Length ; j++)
                {
                    Console.WriteLine($"scores3[{i}][{j}] = {scores3[i][j]}");
                }
            }
        }
        
        // 参数数组
        public int array_getSum(params int[] arr)
        {
            // params关键字 在调用数组时可以传递数组实参，也可以传递一组数组元素
            int sum=0;
            foreach(int val in arr)
            {
                sum += val;
            }
            return sum;
        }

        // 按引用传递参数
        public void swap(ref int a, ref int b)
        {
            // 用ref可改变交换的值
            int temp;
            temp = a;
            a = b;
            b = temp;
        }
        
        // 按输出传递参数
        public void getInsertValue(out int val)
        {
            Console.Write("Please enter a number: ");
            val = Convert.ToInt32(Console.ReadLine());
        }

        // 可空数据类型
        public void nulldataType()
        {
            int? num1 = null;
            int? num2 = 45;
            double? num3 = new double?();
            double? num4 = 3.1415;
            bool? boolval1 = new bool?();
            bool? boolval2 = true;

            Console.WriteLine($"num1:{num1} num2:{num2} num3:{num3} num4:{num4}");
            Console.WriteLine($"boolval1:{boolval1} boolval2:{boolval2}");

            int? num5 = num1 ?? 5;   // num1为空则返回5 不空则返回num1
            int? num6 = num2 ?? 5;
            Console.WriteLine($"num5:{num5} num6:{num6}");
        }

        // 静态多态性 —— 函数重载
        public void add(int a, int b)
        {
            Console.WriteLine($"a + b = {a+b}");
        }
        public void add(double a, double b)
        {
            Console.WriteLine($"a + b = {a+b}");
        }

        // 文件系统操作 —— 读取目录
        public void showCatalog(string path)
        {
            DirectoryInfo mydir = new DirectoryInfo(path);
            FileInfo[] file = mydir.GetFiles(); // 获取目录中的文件
            foreach(FileInfo f in file)
            {
                Console.WriteLine(f.Name);
            }
        }

        // 异常捕捉
        public string getTest()
        {
            StreamReader stream = new StreamReader(@"1.txt");
            string text = stream.ReadLine();
            stream.Close();
            return text;
        }
        public void errorTest()
        {
            try
            {
                Console.WriteLine("文件不存在");
                string result = getTest();
                Console.WriteLine(result);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Console.WriteLine("执行完毕");
            }
        }
        
        
    }
}
