using System.Threading;
using System;

namespace Demo
{
    class EventTest
    {
        public delegate void ProgressDelegate(object sender, int percent);  // object一般用来传递谁触发的事件
        public event ProgressDelegate progress;  // event用来声明实例 把委托链上的委托依次实现 没有委托就不会被调用
        public void eventDo()
        {
            for(int i=0;i<5;i++)
            {
                progress?.Invoke(this,i);   // 连空判断带调用
                Thread.Sleep(500);          // 挂起500ms 模拟计算过程
            }
            progress?.Invoke(this,5);
        }

        // 高层函数定义
        private void oneProgress(object sender, int percent){ Console.WriteLine($"One: {percent}"); }
        private void twoProgress(object sender, int percent){ Console.WriteLine($"Two: {percent}"); }

        // 事件实例
        public void eventTest()
        {
            // 加入两种委托 会依次分别执行 输出：One Two One Two...
            progress += oneProgress;     // 委托加入事件用+= 删除用-=
            progress += twoProgress;
            eventDo();
            Console.WriteLine("End");
        }
    }
}