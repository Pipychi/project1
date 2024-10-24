using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторнаяработа_2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x;
            double y;
            double z;

            // Ввод данных с проверкой корректность ввода + проверка на положительность числа
            Console.WriteLine("'Параллелепипед'.\nВам необходимо ввести неотрицательные значения сторон данной фигуры.\nТогда вы сможете узнать объем, площадь поверхности и характеристику данной фигуры.  ");

            while (true)
            {
                Console.Write("Введите длину: ");
                if ((double.TryParse(Console.ReadLine(), out x)) && x >= 0) /*проверяем, можно ли получить число типа  double из строки */
                    break;
                else
                {
                    Console.WriteLine("Ошибка (было введено или не числовое значение, или отрицательное число). Заново введите числовое значение длины.");
                }

            }

            while (true)
            {
                Console.Write("Введите ширину: ");
                if ((double.TryParse(Console.ReadLine(), out y)) && y >= 0 ) /*проверяем, можно ли получить число типа  double из строки */
                    break;
                else
                {
                    Console.WriteLine("Ошибка (было введено или не числовое значение, или отрицательное число). Заново введите числовое значение ширины.");
                }
            }

            while (true)
            {
                Console.Write("Введите высоту: ");
                if ((double.TryParse(Console.ReadLine(), out z)) && z >= 0) /*проверяем, можно ли получить число типа  double из строки */
                    break;
                else
                {
                    Console.WriteLine("Ошибка (было введено или не числовое значение, или отрицательное число). Заново введите числовое значение высоты.");
                }
            }

            //создание объекта Parallelepiped
            Parallelepiped parall = new Parallelepiped(x, y, z);
            //вывод информации об объекте
            Console.WriteLine(parall.ToString());

            //вывод копии значений
            Parallelepiped parallCopy = new Parallelepiped(parall);
            Console.WriteLine("Копия:");
            Console.WriteLine(parallCopy.ToString());

            //выводим значения, приведенные к целому типу
            parall.ConverToInt();
            Console.WriteLine("Приводим данные к целому значению: ");
            Console.WriteLine(parall.ToString());

            //создаем объект дочернего класса
            ChildClass child = new ChildClass(x, y, z); 
            Console.WriteLine("Данные дочернего класса:\n" + child.ToString());

            //вывод объема параллелепипеда из дочернего класса
            Console.WriteLine("Объем параллелепипеда = " + child.GetVolume());

            //вывод площади поверхности парал-да
            Console.WriteLine("Площадь поверхности = " + child.CalculatingTheSurfaceArea());

            //вывод характеристики о параллелепипеде 
            Console.WriteLine(child.СheckingCube());
        }
    }
}
