using System.Data.SqlTypes;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class ListMerge
    {
        public ArrayList list = new ArrayList();
        public ListMerge(ArrayList l){ list = l;  }
        public void show()
        {
            foreach(int data in this.list){ Console.Write($"{data} "); }
            Console.WriteLine();
        }
        public void merge(ListMerge L, bool isRepeat)
        {
            int index = 0;  // 记录插入位置
            ArrayList arr = new ArrayList();
            foreach(int elem in L.list)
            {
                index = 0;  // 每次将插入位置归0
                foreach(int data in list)
                {
                    Console.WriteLine($"Now index:{index} elem:{elem} data:{data}");
                    if(data < elem){
                        index++;    // 插入元素比当前数小，插入位置+1
                        // 比list中最大值大的数存储到arr中
                        if(index == list.Count){ arr.Add(elem); }
                        else continue;
                    }
                    else{
                        if(data == elem){
                            // 是否课插入重复元素
                            if(isRepeat){ list.Insert(index,elem); }
                            break;
                        }
                        list.Insert(index,elem);    // 插入其他元素
                        break;
                    }
                }
                foreach(int e in this.list){ Console.Write($"{e} "); }
                Console.WriteLine();
            }
            foreach(int elem in arr){ list.Add(elem); } // 将arr中的值添加到list尾部
        }
    }

    class Program
    {
        public void classTest()
        {
            // 属性&字段
            // Rectangle rectangle = new Rectangle { length = 2, width = 3 };
            // Console.WriteLine(rectangle.ToString());
            // Console.WriteLine(rectangle.area);

            // 运算符重载
            // Rectangle r1 = new Rectangle {length = 1, width = 2};
            // Rectangle r2 = new Rectangle {length = 3, width = 4};
            // Rectangle r3 = new Rectangle();
            // r3 = r1 + r2;
            // Console.WriteLine(r3.ToString());
            // Console.WriteLine($"r1==r2: {r1==r2}");
            // Console.WriteLine($"r1!=r2: {r1!=r2}");
            // Console.WriteLine($"r1>r2: {r1>r2}");
            // Console.WriteLine($"r1<r2: {r1<r2}");
            // r1++;
            // Console.WriteLine(r1.ToString());

            // 继承
            // Tabletop tabletop = new Tabletop(2.0,2.0);
            // Console.WriteLine(tabletop.getArea());

            // 动态多态性 —— 抽象类 & 虚方法
            // Dog dog = new Dog("puppy");
            // dog.create();
            // dog.voice();
            
        }
        public void interfaceTest()
        {
            Student student = new Student("Matt","0000");
            student.name = "John";
            student.studentid = "0001";
            // 隐式实现接口
            IPerson p = student;
            p.showInfo(student.name);
            IStudent s = student;
            s.showStuId(student.studentid);
        }
        public void boardTest()
        {
            double Func(double a) => a + 1;
            DrawBoard draw = new DrawBoard(0,10,0,10,20,20);
            draw.Draw(Func,true);
            draw.Print();
        }
        public void basicTest()
        {
            Basic basic = new Basic();
            // basic.structTest();
            // basic.enumTest();
            // basic.stringDemo();
            // basic.datetime();
            // basic.baseConversion();
            // basic.array_foreachTest();
            

            // 参数数组
            // int sum1 = basic.array_getSum(1,2,3,4,5);
            // Console.WriteLine($"sum1 = {sum1}");
            // int[] arr = new int[5]{6,7,8,9,10};
            // int sum2 = basic.array_getSum(arr);
            // Console.WriteLine($"sum2 = {sum2}");

            // 按引用传递参数
            // int a = 10, b = 20;
            // Console.writeline($"a={a} b={b}");
            // basic.swap(ref a, ref b);
            // Console.writeline($"a={a} b={b}");

            // 按输出传递参数
            // int a = 10;
            // Console.WriteLine($"未调用 a={a}");
            // basic.getInsertValue(out a);
            // Console.WriteLine($"已调用 a={a}");

            // 可空数据类型
            // basic.nulldataType();

            // 函数重载
            // basic.add(1,2);
            // basic.add(2.5,3.6);

            // 文件操作
            // string path = @"C:\Users\13263\Desktop\软件设计实践\task";
            // basic.showCatalog(path);

            // 异常捕捉
            // basic.errorTest();
        }
        public void delegateTest()
        {
            DelegateTest delegateTest = new DelegateTest();
            // delegateTest.funcTest();
            // delegateTest.numTest();
            // delegateTest.writeStringTest();
            delegateTest.voiceTest();
        }
        public void eventTest()
        {
            EventTest eventTest = new EventTest();
            eventTest.eventTest();
        }
        public void myfunctionTest()
        {
            MyFunction myFunction = new MyFunction(1,2,3);
            double funRes = 0.0;
            myFunction.calRes(1,1,out funRes);
        }
        public void genericTest()
        {
            GenericTest genericTest = new GenericTest();
            
            // genericTest.arrayTest();
            // genericTest.arraylistTest();
            // genericTest.bitarrayTest();

            // genericTest.listTest();
            // genericTest.linkedlistTest();
            // genericTest.sortedlistTest();

            // genericTest.hashtableTest();
            // genericTest.dictionaryTest();
            // genericTest.hashsetTest();

            // genericTest.queueTest();
            // genericTest.stackTest();

        }
        public void mergelistTest()
        {
            ArrayList l1 = new ArrayList(){1,3,5,7};
            ArrayList l2 = new ArrayList(){1,5,9,11};
            ListMerge L1 = new ListMerge(l1);
            ListMerge L2 = new ListMerge(l2);

            L1.show();
            L1.merge(L2,true);
            L1.show();
            
        }
        public void regexExpressionTest()
        {
            RegexTest r = new RegexTest();
            r.regexDemo();
            r.replaceDemo();
            r.fileDemo("file/regular_test.txt");
            // r.findallDemo();
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            // 类应用
            // program.classTest();

            // 接口应用
            // program.interfaceTest();

            // 画板
            // program.boardTest();

            // C#基础应用
            // program.basicTest();

            // 函数委托
            // program.delegateTest();

            // 事件
            // program.eventTest();

            // 公式计算
            // program.myfunctionTest();

            // 泛型 & 容器
            // program.genericTest();
            // Console.ReadKey();

            // 有序表合并
            // program.mergelistTest();

            // 正则表达式
            // program.regexExpressionTest();
        }
    }
}
