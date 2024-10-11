using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int choice;
            Program p = new Program();
            Console.WriteLine("Выберите модуль задач ");
            choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    Console.WriteLine(" 1.1. 'Дробная часть' Введите вещественное число X ");
                    double x = Convert.ToDouble(Console.ReadLine());
                    double res1 = p.fraction(x);
                    Console.WriteLine("Результат: дробная часть = " + res1);

                    Console.WriteLine("\n 1.3.'Букву в число' Введите символ (0-9) ");
                    char y = Console.ReadKey().KeyChar;
                    int res3 = p.charToNum(y);
                    Console.WriteLine();
                    Console.WriteLine("Результат:" + res3);

                    Console.WriteLine("\n 1.5 'Проверка на двузначность' Введите число");
                    int z;
                    z = int.Parse(Console.ReadLine());
                    bool res5 = p.is2Digits(z);
                    Console.WriteLine("Результат:" + res5);

                    Console.WriteLine(" \n 1.7 'Диапазон' ");
                    int a, b, num;
                    Console.WriteLine("Введите левую границу диапазона - a ");
                    a = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите правую границу диапазона - b ");
                    b = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите число num ");
                    num = Convert.ToInt32(Console.ReadLine());
                    bool res7 = p.isInRange(a, b, num);
                    Console.WriteLine("Вычисляем, лежит ли num в указанном Вами диапазоне");
                    Console.WriteLine("Результат: " + res7);


                    Console.WriteLine("\n 1.9 'Равенство'");
                    int a1, b1, c;
                    Console.WriteLine("Введите первое число");
                    a1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите второе число");
                    b1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите третье число");
                    c = Convert.ToInt32(Console.ReadLine());
                    bool res9 = p.isEqual(a1, b1, c);
                    Console.WriteLine("Равны ли веденные числа? " + res9);
                    break;  
                    
                case 2:
                    
                    Console.WriteLine(" 2.1. 'Модуль' Введите целое число ");
                    int m;
                    m = Convert.ToInt32(Console.ReadLine());
                    int result1 = p.abs(m);
                    Console.WriteLine("Модуль введенного числа = " + result1);

                    Console.WriteLine(" \n 2.2 'Тридцать пять' Делится ли введенное число на 3 ИЛИ 5?");
                    int n;
                    n = Convert.ToInt32(Console.ReadLine());
                    bool result3 = p.is35(n);
                    Console.WriteLine("Результат: " + result3);

                    Console.WriteLine(" \n 2.5 Тройной максимум ");
                    int x1, y1, z1;
                    Console.WriteLine("Введите число Х ");
                    x1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите число Y ");
                    y1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите число Z ");
                    z1 = Convert.ToInt32(Console.ReadLine());
                    int result5 = p.max3(x1, y1, z1);
                    Console.WriteLine("Результат: max = " + result5);

                    Console.WriteLine("\n 2.7 'Двойная сумма' Вычисляем сумму двух чисел");
                    int v, w;
                    Console.WriteLine("Введите первое число ");
                    v = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите второе число");
                    w = Convert.ToInt32(Console.ReadLine());
                    int result7 = p.sum2(v, w);
                    Console.WriteLine("Результат:" + result7);

                    Console.WriteLine(" \n 2.9 'Дни недели' Введите число недели");
                    int g;
                    g = Convert.ToInt32(Console.ReadLine());
                    string result9 = p.day(g);
                    Console.WriteLine("результат: "+ result9);
                    break;

                case 3:

                    Console.WriteLine("3.1 'Числа подряд' Введите целое число X");
                    int o;
                    o = Convert.ToInt32(Console.ReadLine());
                    string rez1 = p.listNums(o);
                    Console.WriteLine("Результат: " + rez1);

                    Console.WriteLine("\n 3.3 'Четные числа' Введите целое число X");
                    int q;
                    q = Convert.ToInt32(Console.ReadLine());
                    string rez3 = p.chet(q);
                    Console.WriteLine("Результат: " + rez3);

                    Console.WriteLine("\n 3.5 'Длина числа' Введите целое число");
                    long r;
                    r = long.Parse(Console.ReadLine());
                    int rez5 = p.numLen(r);
                    Console.WriteLine("Результат: " + rez5);

                    Console.WriteLine("\n 3.7 'Квадрат' Введите число Х (это будет размер квадрата)");
                    int f;
                    f = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Результат: ");
                    p.square(f);

                    Console.WriteLine(" \n 3.9 'Правый треугольник' Введите число Х (это будет размер треугольника)");
                    int l;
                    l = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Результат: ");
                    p.rightTriangle(l);
                    break;

                case 4:

                    Console.WriteLine("4.1 'Поиск первого значения' ");
                    Console.Write("Введите количество элементов массива: ");
                    int len;
                    len = Convert.ToInt32(Console.ReadLine());
                    int[] arr = new int[len];
                    for (int i = 0; i < len; i++)
                    {
                        Console.Write("Введите элемент: ");
                        arr[i] = int.Parse(Console.ReadLine());
                    }
                    Console.Write("Введите число Х, вхождение в массив которого вы хотите найти: ");
                    int x4;
                    x4 = Convert.ToInt32(Console.ReadLine());
                    int index = p.findFirst(arr, x4);
                    Console.WriteLine("Результат: " + index);


                    Console.WriteLine("\n 4.3 'Поиск максимального' ");
                    Console.Write("Введите количество элементов массива: ");
                    int size;
                    size = Convert.ToInt32(Console.ReadLine());
                    int[] arr1 = new int[size];
                    for (int i = 0; i < size; i++)
                    {
                        Console.Write("Введите элемент: ");
                        arr1[i] = int.Parse(Console.ReadLine());  
                    }
                    int modl = p.maxAbs(arr1);
                    Console.WriteLine("Результат: " + modl);


                    Console.WriteLine("\n 4.5 'Добавление массива в массив' ");
                    Console.Write("Введите количество элементов первого массива: ");
                    int len1;
                    len1 = Convert.ToInt32(Console.ReadLine());
                    int[] arr11 = new int[len1];
                    for (int i = 0; i < len1; i++)
                    {
                        Console.Write("Введите элемент: ");
                        arr11[i] = int.Parse(Console.ReadLine());
                    }
                    Console.Write("Введите количество элементов второго массива: ");
                    int len2;
                    len2 = Convert.ToInt32(Console.ReadLine());
                    int[] ins = new int[len2];
                    for (int i = 0; i < len2; i++)
                    {
                        Console.Write("Введите элемент: ");
                        ins[i] = int.Parse(Console.ReadLine());
                    }
                    Console.Write("Введите номер позиции в 1-ом массиве, куда хотите вставить 2-ой массив: ");
                    int pos;
                    pos = Convert.ToInt32(Console.ReadLine());
                    int[] resul = p.add(arr11, ins, pos);
                    Console.Write("Результат: ");
                    foreach (int element in resul)
                    {
                        Console.Write(element + " ");
                    }


                    Console.WriteLine();
                    Console.WriteLine("\n 4.7 'Возвратный реверс' ");
                    Console.Write("Введите количество элементов массива: ");
                    int size1;
                    size1 = Convert.ToInt32(Console.ReadLine());
                    int[] arr2 = new int[size1];
                    for (int i = 0; i < size1; i++)
                    {
                        Console.Write("Введите элемент: ");
                        arr2[i] = int.Parse(Console.ReadLine());
                    }
                    int[] rever = p.reverseBack(arr2);
                    Console.WriteLine("Результат: " );
                    foreach (int element in rever)
                    {
                        Console.Write(element + " ");
                    }

                    Console.WriteLine();
                    Console.WriteLine("\n 4.9 'Все вхождения' ");
                    Console.Write("Введите количество элементов массива: ");
                    int size2;
                    size2 = Convert.ToInt32(Console.ReadLine());
                    int[] arr3 = new int[size2];
                    for (int i = 0; i < size2; i++)
                    {
                        Console.Write("Введите элемент: ");
                        arr3[i] = int.Parse(Console.ReadLine());
                    }
                    Console.Write("Введите значение числа, вхождения в массив которого вы хотите найти: ");
                    int k;
                    k = Convert.ToInt32(Console.ReadLine());
                    int[] mas = p.findAll(arr3, k);
                    Console.Write("Индексы вхождения числа в массив: ");
                    foreach (int element in mas)
                    {
                        Console.Write(element + " ");
                    }
                    Console.WriteLine();
                    break;

            }
            

        }
        public double fraction(double x)
        {
            return x - (int)x;
        }


        public int charToNum(char x)
        {
            return (int)x - 48;            
        }   
        

        public bool is2Digits(int x)
        {
            return (x >= 10 && x <= 99) || (x <= -10 && x >= -99);
        }


        public bool isInRange(int a, int b, int num)
        {
            if ((num>=b && num <= a)||(num>=a && num<=b))
                {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool isEqual(int a, int b, int c)
        {
            return a == b && b == c;
        }

        public int abs(int x)
        {
            if (x<0)
            {
                return x*(-1);
            }
            else
            {
                return x;
            }
        }


        public bool is35(int x)
        {
            if (x % 3 == 0 && x % 5 == 0)
            {
                return false;
            }
            if ((x % 3 == 0) || (x % 5 == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public int max3(int x, int y, int z)
        {
            if ((x >= y && y >= z) || (x >= z && z >= y))
            {
                return x;
            }
            if ((y >= x && x >= z) || (y >= z && z >= x))
            {
                return y;
            }
            else
            {
                return z;
            }
        }


        public int sum2(int x, int y)
        {
            if (x+y > 10 && x+y <= 19)
            {
                return 20;
            }
            else
            {
                return x + y;
            }
        }


        public String day(int x)
        {
            
            switch(x)
            {
                case 1: return "понедельник"; break;
                case 2: return "вторник"; break;
                case 3: return "среда"; break;
                case 4: return "четверг"; break;
                case 5: return "пятница"; break;
                case 6: return "суббота"; break;
                case 7: return "воскресенье"; break;
                default: return "дня недели с таким номером не существует"; break;

            }
        }


        public String listNums(int x)
        {
            string result = "";
            for (int i = 0; i<=x; i++)
            {
                result += i + " ";
            }
            return result;  
        }


        public String chet(int x)
        {
            string result = "";
            for (int i = 0; i<=x; i+=2)
            {
                result += i + " ";
            }
            return result;
        }


        public int numLen(long x)
        {
            int count = 0;
            if (x<0)
            {
                x = x * (-1);
            }
            if (x==0)
            {
                return 1;
            }

            while (x > 0)
            {
                count++;
                x = x / 10;
            }
            return count;
        }


        public void square(int x)
        {
            for (int i = 0; i < x; i++) 
            {
                for (int j = 0; j < x; j++) 
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }


        public void rightTriangle(int x)
        {
            for (int i = 1; i <= x; i++) 
            {
                for (int j = 1; j <= x - i; j++) 
                {
                    Console.Write(" ");
                }
                for (int e = 1; e <= i; e++) 
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }


        public int findFirst(int[] arr, int x)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == x)
                { return i; }
            }
            return -1;
        }


        public int maxAbs(int[] arr)
        {
            int maxValue = arr[0];
            int maxAbsValue = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int current;
                if (arr[i] < 0)
                {
                    current = arr[i] * (-1);
                }
                else
                {
                    current = arr[i];
                }
                if (current > maxAbsValue)
                {
                    maxAbsValue = current;
                    maxValue = arr[i];
                }
            }
            return maxValue;
        }


        public int[] add(int[] arr, int[] ins, int pos)
        {
            int[] res = new int[arr.Length + ins.Length];
            for (int i = 0; i < pos; i++)
            {
                res[i] = arr[i];
            }
            for (int i = 0; i < ins.Length; i++)
            {
                res[pos + i] = ins[i];
            }
            for (int i = pos; i < arr.Length; i++)
            {
                res[i + ins.Length] = arr[i];
            }
            return res;
        }


        public int[] reverseBack(int[] arr)
        {
            int[] reversearr = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                reversearr[i] = arr[arr.Length - 1 - i];
            }
            return reversearr;
        }


        public int[] findAll(int[] arr, int x)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == x)
                {
                    count += 1;
                }
            }
            if (count == 0)
            {
                return new int[0];
            }
            int index = 0;
            int[] mas = new int[count];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == x)
                {
                    mas[index] = i;
                    index += 1;
                }
            }
            return mas;
        }
    }
}

