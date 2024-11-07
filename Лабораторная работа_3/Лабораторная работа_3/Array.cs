using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_3
{
    //создаем класс, в котором будут храниться массивы (задания 1-3)
    internal class Array
    {
        //создаем поле - массив
        private int[,] array;

        //конструктор для инициализации массива заданного размера
        public Array(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentException("Размеры массива не должны быть отрицательными (меньше нуля)");
            }
            array = new int[rows, columns];
        }


        //метод для заполнения массива размером (m x n) вводимыми пользователем числами 
        public void FillInputData()
        {
            Console.WriteLine("Заполнение массива: ");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"Введите элемент [{i}, {j}]: ");
                    array[i, j] = CheckInput(); 
                }
            }
        }


        // Доп.метод для проверки корректности ввода числа
        private int CheckInput()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                Console.WriteLine("Некорректный ввод. Введите число.");
            }
        }


        //метод для заполнения второго массива размером nxn ( в шахматном порядке заполняется)
        public void FillInputDataChessOrder()
        {
            // Создаем объект Random для генерации случайных чисел
            Random random = new Random();
            for (int i = 0;i < array.GetLength(0);i++)
            {
                for (int j = 0;j < array.GetLength(1);j++)
                {
                    int number = random.Next(0, 101); /*берем случайные числа от 0 до 100*/
                    if ((i+j) % 2 == 0) //черные клетки на шахмотной доске 
                    {
                        if (number % 2 == 0) //четные числа
                        {
                            array[i, j] = number;
                        }
                        else
                        {
                            array[i, j] = number + 1; //если нечетное, то берем следующее четное
                        }
                    }
                    else  // белые клетки
                    {
                        if (number % 2 != 0) // нечетные числа
                        {
                            array[i,j] = number;
                        }
                        else
                        {
                            array[i, j] = number + 1; //если четное, то берем следующее нечетное
                        }
                    }
                }
            }
        }


        //метод для заполнения третьего массива n=5 по образцу из задания (была дана треугольная матрица, нули сверху)
        public void FillInputDataTruegolniki()
        {
            int count = 0;
            int n = array.GetLength(0);
            for (int i = n - 1; i >= 0; i--) 
            {
                for (int j = 0; n-i > j; j++)
                {
                    array[i + j, j] = ++count;
                }
            }
        }


        //метод для вывода массива на экран 
        public void PrintArray()
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + "\t"); /* \t - это escape-последовательность, которая представляет символ табуляции*/
                }
                Console.WriteLine();
            }
        }


        //метод, который вычисляет макс. сумму элементов в массиве  (ЗАДАНИЕ 2)
        public int CalculateMaxColumnSum()
        {
            int maxSum = int.MinValue; // сохраняем сюда макс.сумму
            int rowCount = array.GetLength(0);
            int colCount = array.GetLength(1);

            // прохождение по всем столбцам, кроме последнего
            for (int col = 0; col < colCount - 1; col++)
            {
                int sum = 0;

                // суммируются элементы в текущем столбце, исключая последние элементы
                for (int row = 0; row < rowCount - (col + 1); row++)
                {
                    sum += array[row, col];
                }

                // Проверяем, является ли текущая сумма максимальной
                if (sum > maxSum)
                {
                    maxSum = sum;
                }
            }

            return maxSum;
        }


        // перегрузка оператора сложения для матриц (ЗАДАНИЕ 3)
        public static Array operator +(Array a, Array b)
        {
            // проверяем сооответсвие размерности матриц
            if (a.array.GetLength(0) != b.array.GetLength(0) || a.array.GetLength(1) != b.array.GetLength(1))
            {
                throw new ArgumentException("Для операции сложения размеры матриц должны совпадать!!!");
            }
            // Получаем количество строк и столбцов матриц
            int rows = a.array.GetLength(0);
            int colums = a.array.GetLength(1);
            Array result = new Array(rows, colums);
            // Суммируем элементы матриц попарно
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    result.array[i, j] = a.array[i, j] + b. array[i, j];
                }
            }
            return result;
        }


        // перегрузка оператора умножения матрицы на число 
        public static Array operator *(int number, Array a)
        {
            // Получаем количество строк и столбцов матриц
            int rows = a.array.GetLength(0);
            int colums = a.array.GetLength(1);
            Array result = new Array(rows, colums);
            // Умножаем каждый элемент матрицы на число
            for ( int i = 0; i < rows; i++ )
            {
                for ( int j = 0; j < colums; j++)
                {
                    result.array[i, j] = (a.array[i, j] * number);
                }
            }
            return result;
        }


        // перегрузка оператора вычитания матриц
        public static Array operator -(Array a, Array b)
        {
            // проверяем сооответсвие размерности матриц
            if (a.array.GetLength(0) != b.array.GetLength(0) || a.array.GetLength(1) != b.array.GetLength(1))
            {
                throw new ArgumentException("Для операции сложения размеры матриц должны совпадать!!!");
            }
            // Получаем количество строк и столбцов матриц
            int rows = a.array.GetLength(0);
            int colums = a.array.GetLength(1);
            Array result = new Array(rows, colums);
            // Вычитаем элементы матриц попарно
            for ( int i = 0; i < rows; i++ )
            {
                for ( int j = 0; j < colums; j++)
                {
                    result.array[i,j] = (a.array[i,j] - b.array[i,j]);
                }
            }
            return result;
        }


        // метод, который транспонирует матрицу (строки становятся столбцами) 
        public Array Transpose()
        {
            // Получаем количество строк и столбцов матриц
            int rows = array.GetLength(0);
            int colums = array.GetLength(1);
            Array result = new Array(colums, rows);
            // Переставляем элементы матрицы (строки становятся столбцами)
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    result.array[j, i] = array[i, j]; // перестановка индексов
                }
            }

            return result;
        }


        // Перегрузка метода ToString() для отображения матриц в виде таблицы
        public override string ToString()
        {
            // Создаем объект StringBuilder для формирования строки с представлением матрицы
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    // Добавляем значение элемента матрицы в StringBuilder
                    sb.Append(array[i, j] + "\t");
                }
                // После обработки строки добавляем символ перехода на новую строку
                sb.AppendLine();
            }
            return sb.ToString();
        }


    }
}
