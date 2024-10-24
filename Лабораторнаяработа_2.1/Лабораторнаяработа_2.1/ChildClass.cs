using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторнаяработа_2._1
{
    //создаем дочерний класс
    //в данном классе будет новое поле - объем параллепипеда; уже есть высота(z), длина(x), ширина(y) из базового класса. 
    //здесь также будем находить площадь поверхности и обЪем параллелепипеда.
    class ChildClass : Parallelepiped
    {
        // новое поле для хранения объема парал-да
        private double volume;

        // конструктор с параметрами (вызывает конструктор базового класса)
        public ChildClass(double length, double width, double heigth)
            : base(length, width, heigth)
        {
            volume = Length * Width * Heigth;
        }
        // метод, который выводит обЪем парал-да
        public double GetVolume()
        {
            return volume;
        }
        // метод, который высчитываает площадь поверхности парал-да ( по формуле S = 2(ab + bc + ac), где a,b,c- стороны )
        public double CalculatingTheSurfaceArea()
        {
            return (2 * (Length * Width + Width * Heigth + Length * Heigth));
        }
        //метод, который выводит, является ли данный параллелепипед кубом (характеристика)
        public string СheckingCube()
        {
            if (Length == Width && Width == Heigth)
            {
                return "Данный параллелепипед - куб ";
            }
            else
            {
                return "Данный параллелепипед - прямоугольный ";
            }
        }
    }
}
