using System.Linq;
using System.IO;
using System;

namespace Demo
{
    class DelegateTest
    {
        // 函数委托
        delegate double CommonFunc(double x);
        static double Func1(double a) => a * a;
        static double Func2(double a) => a * a - 2 * a + 1;
        static void funcResult(CommonFunc f)
        {
            for(double x = 0.0;x<1.0;x+=0.2)
            {
                Console.WriteLine($"f({x}) = {f(x)}");
            }
        }
        public void funcTest()
        {
            funcResult(Func1);
            funcResult(Func2);
        }
        
        // 简单函数委托 & 委托多播
        delegate int NumberChanger(int n); // 建立委托类型
        static int num = 10;
        public int addNum(int val)
        {
            num += val;
            return num;
        }
        public int multNum(int val)
        {
            num *= val;
            return num;
        }
        public void numTest()
        {
            // 建立委托实例，并指向要调用的方法
            NumberChanger nc1 = new NumberChanger(addNum);    // 第一种方式，利用委托类的构造方法指定   
            NumberChanger nc2 = multNum;    // 第二种方式，更类似于函数指针
            
            // 利用委托类实例调用所指向的方法
            nc1(10);
            Console.WriteLine($"num={num}");    // 10+10=20
            nc2(2);
            Console.WriteLine($"num={num}");    // 20*2=40

            // 委托的多播
            NumberChanger nc3;
            nc3 = nc1 + nc2;
            nc3(2);
            Console.WriteLine($"num={num}");    // 单独执行 (10+2)*2=24
        }

        // 委托实例1
        static FileStream file;
        static StreamWriter streamWriter;
        public delegate void printString(string s);
        public void writeToScreen(string s)
        {
            Console.WriteLine(s);
        }
        public void writeToFile(string s)
        {
            file = new FileStream("file/delegate_test.txt",FileMode.Append,FileAccess.Write);
            streamWriter = new StreamWriter(file);
            streamWriter.WriteLine(s);
            streamWriter.Flush();
            streamWriter.Close();
            file.Close();
        }
        public void writeStringTest()
        {
            printString p1 = new printString(writeToScreen);
            printString p2 = new printString(writeToFile);
            p1("To Screen: Hello World!");
            p2("To File: Hello World!");
        }

        // 委托实例2
        delegate void Voice();
        public void dogVoice(){ Console.WriteLine("wang!"); }
        public void catVoice(){ Console.WriteLine("miao~"); }
        public void voiceTest()
        {
            Voice v1 = new Voice(dogVoice);
            Voice v2 = new Voice(catVoice);
            v1();
            v2();
        }
    
    }
}