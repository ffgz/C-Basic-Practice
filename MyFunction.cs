using System;

namespace Demo
{
    class MyFunction
    {
        static double a,b,c;
        public MyFunction(double num1,double num2,double num3){ a=num1;b=num2;c=num3; }
        delegate double Func(double x,double y);
        static double F1(double x,double y) => a*x*x+b*y*y+a*b*x*y+c;
        static double calculate(Func f,double x,double y)
        {
            double res = f(x,y);
            return res;
        }
        public void calRes(double x,double y,out double res)
        {
            res = calculate(F1,x,y);
            Console.WriteLine($"{a}*{x}*{x} + {b}*{y}*{y} + {a}*{b}*{x}*{y} + {c} = {res}");
        }
    }
}