using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;


namespace Лабораторная_работа_3
{
    internal class Program
    {
        static void Main()
        {
            int n;
            int m;
            int n2;
            int n3;
            int p1, p2;
            int a1, a2, b1, b2, c1, c2;

            //ЗАДАНИЕ 1
            //ввод значений для первого массива m*n и проверка на корректность ввода
            Console.WriteLine(" Задание 1");
            while (true)
            {
                Console.Write("Введите количество строк n в первом массиве: ");
                if (int.TryParse(Console.ReadLine(), out n) && n >= 0)
                     break;
                else
                {
                    Console.WriteLine("Ошибка: было введено не целое(или отрицательное) число. Попробуйте заново.");
                }
            }

            while (true)
            {
                Console.Write("Введите количество столбцов m в первом массиве: ");
                if (int.TryParse(Console.ReadLine(), out m) && m >= 0)
                    break;
                else
                {
                    Console.WriteLine("Ошибка: было введено не целое(или отрицательное) число. Попробуйте заново.");
                }
            }

            //реализуем первый массив размером nxm
            Array array1 = new Array(n, m);
            array1.FillInputData();

            //вывод первого массива на экран
            Console.WriteLine("Первый массив: ");
            array1.PrintArray();


            //ввод значений для второго массива n*n и проверка на корректность ввода
            while (true)
            {
                Console.Write("Введите значение количества строк и столбцов во втором массиве: ");
                if (int.TryParse(Console.ReadLine(), out n2) && n2 >= 0)
                    break;
                else
                {
                    Console.WriteLine("Ошибка: было введено не целое(или отрицательное) число. Попробуйте заново.");
                }
            }
            
            //реализуем второй массив размером n*n
            Array array2 = new Array(n2, n2);
            array2.FillInputDataChessOrder();
            //вывод второго массива на экран
            Console.WriteLine("Второй массив: ");
            array2.PrintArray();

            //ввод значений для третьего массива n*n и проверка на корректность ввода
            while (true)
            {
                Console.Write("Введите значение количества строк и столбцов в третьем массиве: ");
                if (int.TryParse(Console.ReadLine(), out n3) && n3 >= 0)
                    break;
                else
                {
                    Console.WriteLine("Ошибка: было введено не целое(или отрицательное) число. Попробуйте заново.");
                }
            }
            //реализуем третий массив размером n*n
            Array array3 = new Array(n3, n3);
            array3.FillInputDataTruegolniki();
            //вывод третьего массива на экран
            Console.WriteLine("Третий массив: ");
            array3.PrintArray();




            //ЗАДАНИЕ 2
            Console.WriteLine("\n \n Задание 2\nСоздаем массив:");
            //ввод значений для массива из 2 задания m*n и проверка на корректность ввода
            while (true)
            {
                Console.Write("Введите количество строк в массиве: ");
                if (int.TryParse(Console.ReadLine(), out p1) && p1 >= 0)
                    break;
                else
                {
                    Console.WriteLine("Ошибка: было введено не целое(или отрицательное) число. Попробуйте заново.");
                }
            }

            while (true)
            {
                Console.Write("Введите количество столбцов в массиве: ");
                if (int.TryParse(Console.ReadLine(), out p2) && p2 >= 0)
                    break;
                else
                {
                    Console.WriteLine("Ошибка: было введено не целое(или отрицательное) число. Попробуйте заново.");
                }
            }
            //реализуем первый массив размером nxm
            Array array4 = new Array(p1, p2);
            array4.FillInputData();
            //вывод первого массива на экран
            Console.WriteLine("Введенный массив: ");
            array4.PrintArray();
            //вычисляем макс.сумму элементов
            Console.WriteLine("Максимальная сумма элементов среди сумм, найденных по правилу:\nсумма элементов первого столбца без одного последнего элемента,\nсумма элементов второго столбца без двух последних,\nсумма третьего столбца без трехпоследних и т.д.\nПоследний столбец не обрабатывается");
            int rez;
            rez = array4.CalculateMaxColumnSum();
            Console.WriteLine("равна = " + rez);





            // ЗАДАНИЕ 3
            // запрашиваем размерность матрицы А
            Console.WriteLine("\n\n Задание 3\nВведите размерность матрицы A");
            while (true)
            {
                Console.Write("количество строк в А - ");
                if (int.TryParse(Console.ReadLine(), out a1) && a1 >= 0)
                    break;
                else
                {
                    Console.WriteLine("Ошибка: было введено не целое(или отрицательное) число. Попробуйте заново.");
                }
            }
            while (true)
            {
                Console.Write("количество столбцов в А - ");
                if (int.TryParse(Console.ReadLine(), out a2) && a2 >= 0)
                    break;
                else
                {
                    Console.WriteLine("Ошибка: было введено не целое(или отрицательное) число. Попробуйте заново.");
                }
            }
            //реализуем матрицу А
            Array arrayA = new Array(a1, a2);
            arrayA.FillInputData();
            //вывод матрицу А
            Console.WriteLine("Введена матрица: ");
            Console.WriteLine(arrayA.ToString());

            // запрашиваем размерность матрицы B
            Console.WriteLine("\nВведите размерность матрицы B (заметьте, что размерность данной матрицы должна совпадать с A)");
            while (true)
            {
                Console.Write("количество строк в B - ");
                if (int.TryParse(Console.ReadLine(), out b1) && b1 >= 0)
                    break;
                else
                {
                    Console.WriteLine("Ошибка: было введено не целое(или отрицательное) число. Попробуйте заново.");
                }
            }
            while (true)
            {
                Console.Write("количество столбцов в B - ");
                if (int.TryParse(Console.ReadLine(), out b2) && b2 >= 0)
                    break;
                else
                {
                    Console.WriteLine("Ошибка: было введено не целое(или отрицательное) число. Попробуйте заново.");
                }
            }
            //реализуем матрицу B
            Array arrayB = new Array(b1, b2);
            arrayB.FillInputData();
            //вывод матрицу B
            Console.WriteLine("Введена матрица: ");
            Console.WriteLine(arrayB.ToString());

            // запрашиваем размерность матрицы C
            Console.WriteLine("\nВведите размерность матрицы C");
            while (true)
            {
                Console.Write("количество строк в C - ");
                if (int.TryParse(Console.ReadLine(), out c1) && c1 >= 0)
                    break;
                else
                {
                    Console.WriteLine("Ошибка: было введено не целое(или отрицательное) число. Попробуйте заново.");
                }
            }
            while (true)
            {
                Console.Write("количество столбцов в C - ");
                if (int.TryParse(Console.ReadLine(), out c2) && c2 >= 0)
                    break;
                else
                {
                    Console.WriteLine("Ошибка: было введено не целое(или отрицательное) число. Попробуйте заново.");
                }
            }
            //реализуем матрицу C
            Array arrayC = new Array(c1, c2);
            arrayC.FillInputData();
            //вывод матрицу C
            Console.WriteLine("Введена матрица: ");
            Console.WriteLine(arrayC.ToString());

            // вычисляем выражение: (А+4*В)-Ст
            Array result = (arrayA + (4 * arrayB)) - (arrayC.Transpose());
            // выводим результат на экран
            Console.WriteLine("В результате вычисления выражения (А+4*В)-Ст была получена матрица");
            Console.WriteLine(result.ToString());




            //ЗАДАНИЕ 4
            Console.WriteLine("\n\n Задание 4");
            Console.Write("Введите значение k для фильтрации чисел: ");
            int k = int.Parse(Console.ReadLine());
            // выполняем фильтрацию
            File.FilterFile(k);
            Console.WriteLine($"Фильтрация выполнена. Результаты записаны в файл: {File.OutputFile}");
            //вывод содержимого файла на экран
            File.PrintFile(File.OutputFile);



            // ЗАДАНИЕ 5
            Console.WriteLine("\n\n Задание 5");
            // заполняем файл игрушками
            File.FillToyFile();
            // выводим подходящие игрушки
            File.СheckingToysForThreeYearOld();
            


            // ЗАДАНИЕ 6
            Console.WriteLine("\n\n Задание 6");
            // заполняем файл случайными десятью числами от 1 до 100
            File.FillingTextFile1Randomly(10, 100);
            // выводим содержимое файла на экран
            File.PrintTextFile(File.File1);
            //вычисляем  макс+мин элемента в файле
            int sum = File.SearchSumMinAndMax(File.File1);
            Console.WriteLine("Сумма максимального и минимального числа из файла равна " + sum);



            // ЗАДАНИЕ 7
            Console.WriteLine("\n\n Задание 7");
            // заполняем файл случайными десятью числами от 1 до 100
            File.FillingTextFile2Randomly(10, 100);
            // выводим содержимое файла на экран
            File.PrintTextFile(File.File2);
            // вычисляем сумму четных элементов в файле
            int summ = File.FindSumEvenElements(File.File2);
            Console.WriteLine("Сумма четных элементов в файле равна " + summ);



            // ЗАДАНИЕ 8
            Console.WriteLine("\n\n Задание 8");
            // создаем новый файл с первыми символами строк
            File.CreateNewFile();
            Console.WriteLine("Новый файл с первыми символами строк исходного файла был создан");
            // выводим содержимое файла на экран
            File.PrintTextFile(File.TextFile2);

            // выход из программы
            Console.WriteLine("\nНажмите enter для выхода из программы");
            Console.ReadLine();

        }

    }
}
