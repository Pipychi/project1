using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_2._23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x, y;
          
            // Ввод данных с проверкой корректность ввода 
            Console.WriteLine("Вам необходимо ввести координаты точки (они могут принимать дробное значение)");

            while (true)
            {
                Console.Write("Введите X: ");
                if (double.TryParse(Console.ReadLine(), out x)) /*проверяем, можно ли получить число типа  double из строки */
                    break;
                else
                {
                    Console.WriteLine("Ошибка ввода. Заново введите числовое значение X.");
                }
                
            }

            while (true)
            {
                Console.Write("Введите Y: ");
                if (double.TryParse(Console.ReadLine(), out y)) /*проверяем, можно ли получить число типа  double из строки */
                    break;
                else
                {
                    Console.WriteLine("Ошибка ввода. Заново введите числовое значение Y.");
                }
            }

            //создание объекта Point
            Point point = new Point(x, y);
            // Вывод информации о точке
            Console.WriteLine(point.ToString());

            // Вычисление расстояния до начала координат
            double distance = point.Distance();
            //вывод результата на экран 
            Console.WriteLine("Расстояние от точки до начала координат:" + distance);

            //ТЕСТИРОВАНИЕ УНАРНЫХ ОПЕРАЦИЙ 
            Console.WriteLine("\nПерегруженные операции.\n 'Унарные операции'");
            //уменьшение координат на 1
            point--;
            Console.WriteLine("Уменьшение координат на 1: " + point.ToString());

            //перестановка координат между друг другом
            point = ~point;
            Console.WriteLine("Перестановка координат: " + point.ToString());

            //ТЕСТИРОВАНИЕ ОПЕРАЦИЙ ПРИВЕДЕНИЯ ТИПА
            Console.WriteLine("\n 'Операции приведения типа'");
            int xInt = point;  /*неявное приведение*/
            Console.WriteLine("Целая часть x = " + xInt);

            double yDouble = (double)point; /*явное приведение*/
            Console.WriteLine("Координата y = " + yDouble);

            //ТЕСТИРОВАНИЕ БИНАРНЫХ ОПЕРАЦИЙ
            Console.WriteLine("\n 'Бинарные операции'");
            int a;
            Console.Write("Введите число, на которое хотите уменьшить x: ");
            a = int.Parse(Console.ReadLine());
            point = point - a;
            Console.WriteLine("" + point);

            int b;
            Console.Write("Введите число, на которое хотите уменьшить y: ");
            b = int.Parse(Console.ReadLine());
            point = b - point;
            Console.WriteLine("" + point);

            Console.WriteLine("Вычисление расстояния от координаты до точки p = (3;3) ");
            //берем в пример координату p = (3;3)
            Point p = new Point(3, 3);
            double distancP = point - p;
            Console.WriteLine("Расстояние между точками = " + distancP);


        }
    }
}
