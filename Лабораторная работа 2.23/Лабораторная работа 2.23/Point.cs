using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_2._23
{
    internal class Point
    {
        //поля(координаты точки)
        private double x;
        private double y;

        //свойства
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        //конструктор
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        //метод, который вычисляет расстояние от точки до начала координат ( по формуле √(x² + y²))
        public double Distance()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        //перегрузка метода ToString для вывода полей
        public override string ToString()
        {
            return $"Координаты точки: ( {X} ; {Y})";
        }

        //ПЕРЕГРУЗКИ ОПЕРАТОРОВ
        //1. Унарная операция: уменьшает координаты x и y на 1
        public static Point operator --(Point p)   /* -- префиксный оператор декремента*/
        {
            p.X = p.X - 1;
            p.Y = p.Y - 1;
            return p;
        }
        //унарная операция: поменять местами координаты x и y
        public static Point operator ~ (Point p)
        {
            double z = p.X;
            p.X = p.Y;
            p.Y = z;
            return p;
        }

        //2. Операции приведения типа
        //int(неявная) - результатом является целая часть координаты x
        public static implicit operator int (Point p)
        {
            return (int) p.X; /*возвращаем целую часть x*/
        }
        //double(явная) - результатом является координата y
        public static explicit operator double (Point p)
            { return  p.Y; }

        //3. Бинарные операции
        //левосторонняя операция, уменьшается координата х
        public static Point operator - (Point p, int value)
        {
            p.X -= value;
            return p ;
        }
        //правосторонняя операция, уменьшается координата y
        public static Point operator -(int value, Point p)
        {
            p.Y -= value;
            return p ;  
        }
        //вычисляется расстояние до точки p ( по формуле Пифагора: r =√((a-x)² + (b - y)²), где (x;y) p = (a;b))
        public static double operator - (Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
    }
}
