using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторнаяработа_2._1
{
    // создаем базовый класс 
    internal class Parallelepiped
    {
        // вещественные поля
        private double length; /*длина*/
        private double width; /*ширина*/
        private double heigth; /*высота*/

        //конструктор c параметрами
        public Parallelepiped(double length, double width, double heigth)
        {
            this.length = length;
            this.width = width;
            this.heigth = heigth;
        }

        //свойства для доступа к полям
        public double Length
        {                          
            get { return length; }
            set { length = value; }
        }

        public double Width
        {                        
            get { return width; }
            set { width = value; }
        }

        public double Heigth
        {                         
            get { return heigth; }
            set { heigth = value; }
        }

        //конструктор копирования
        public Parallelepiped(Parallelepiped other)
        {
            this.length = other.Length;
            this.width = other.Width;
            this.heigth = other.Heigth;
        }

        //метод, который приводит поля к целому типу
        public void ConverToInt()
        {
            Length = Math.Round(Length);
            Width = Math.Round(Width);
            Heigth = Math.Round(Heigth);
        }
        //перегрузка метода ToString  
        public override string ToString()
        {
            return " Длина = " + Length + "\n Ширина = " + Width + "\n Высота = " + Heigth;
        }
    }
}
