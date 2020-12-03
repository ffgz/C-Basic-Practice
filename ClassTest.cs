using System;

namespace Demo
{
    class Shape
    {
        protected double width;
        protected double height;
        public Shape(){}
        public Shape(double w, double h)
        {
            width = w;
            height = h;
        }
        public double getArea()
        {
            return width * height;
        }
    }

    // 继承自Shape
    class Tabletop: Shape
    {
        // 默认调用父类的无参构造函数
        public Tabletop(double w, double h):base(w,h)   
        { }
        public double getCost()
        {
            return getArea() * 20;
        }
    }
    
    class Rectangle
    {
        // 属性 get表示可读 set表示可写 用于保护私有变量
        private double _length;
        public double length
        {
            get => _length;
            set
            {
                if (value < 0) return;
                _length = value;
            }
        }
        private double _width;
        public double width
        {
            get { return _width; }
            set
            {
                if (value < 0) return;
                _width = value;
            }
        }
        // 只读简化写法
        public string detail => $"Length:{_length} Width:{_width} Area:{getArea()}";
        public override string ToString() => detail;
        public double area => getArea();
        public double cost{ get { return getArea()*20;} }
        public Rectangle()  // 构造函数
        {
            _length = 1.0;
            _width = 1.0;
        }
        
        ~Rectangle()    // 析构函数
        {
            Console.WriteLine("对象已删除");
        }
        
        public void setSize(double l, double w)
        {
            _length = l;
            _width = w;
        }
        public double getArea()
        {
            return length * width;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // 运算符重载
        public static Rectangle operator + (Rectangle r1, Rectangle r2)
        {
            Rectangle r = new Rectangle();
            r.length = r1.length + r2.length;
            r.width = r1.width + r2.width;
            return r;
        }      
        public static bool operator == (Rectangle r1, Rectangle r2)
        {
            bool status = false;
            if(r1.length == r2.length && r1.width == r2.width) status = true;
            return status;
        }
        public static bool operator != (Rectangle r1, Rectangle r2)
        {
            bool status = false;
            if(r1.length != r2.length || r1.width != r2.width) status = true;
            return status;
        }
        public static bool operator < (Rectangle r1, Rectangle r2)
        {
            bool status = false;
            if(r1.length < r2.length && r1.width < r2.width) status=true;
            return status;
        }
        public static bool operator > (Rectangle r1, Rectangle r2)
        {
            bool status = false;
            if(r1.length > r2.length && r1.width > r2.width) status=true;
            return status;
        }
        public static Rectangle operator ++ (Rectangle r)
        {
            r.length += 1;
            r.width += 1;
            return r; 
        }
    }

    // 动态多态性 —— 抽象类 & 虚方法
    abstract class Animal
    {
        public virtual void create(){ Console.WriteLine("Create an animal"); }
        abstract public void voice();
    }
    class Dog: Animal
    {
        private string name;
        public Dog(string n){ name = n;}
        public override void create()
        {
            Console.WriteLine("Create a dog");
            base.create();
        }
        public override void voice()
        {
            Console.WriteLine("wang wang wang");
            // throw new NotImplementedException();
        }   
    }

    // class Student
    // {
    //     private string _id;

    //     private string _name;
    //     public string name{
    //         get => _name;
    //         set{ _name = value; }
    //     }
    // }
}   

