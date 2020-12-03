using System;

namespace Demo
{
    // 函数委托
    delegate double DrawFunction(double x);
    class DrawBoard
    {
        public DrawBoard(double x0,double x1,double y0,double y1,int rows,int cols)
        {
            _x0 = x0;
            _x1 = x1;
            _y0 = y0;
            _y1 = y1;
            _rows = rows;
            _cols = cols;
            pixels = new int[rows, cols];
        }

        private double _x0,_x1,_y0,_y1;
        private int _rows, _cols;
        private int[,] pixels;

        public void Clear(bool isClear)
        {
            if(isClear)
            {
                for (int i = 0; i < pixels.GetLength(0); i++)
                {
                    for (int j = 0; j < pixels.GetLength(1); j++)
                    {
                        pixels[i, j] = 0;
                    }
                }
            }
        }

        public void Draw(DrawFunction f,bool isClear)
        {
            // 面板初始化
            Clear(isClear);

            double dx = (_x1 - _x0) / (_cols - 1);  // 计算间隔点
            double x = _x0;
            for(int i=0;i<_cols;i++)
            {
                double y = f(x);
                int j = (int)((_y1 - y) / (_y1 - _y0) * (_rows - 1));
                if(j<_rows && j>=0) pixels[j, i] = 1;
                x += dx;
            }
        }

        public void Print()
        {
            for (int i = 0; i < pixels.GetLength(0); i++)
            {
                for (int j = 0; j < pixels.GetLength(1); j++)
                {
                    if(pixels[i,j]==1) Console.Write("*");
                    else Console.Write("·");
                }
                Console.WriteLine();
            }
        }
    }
}
