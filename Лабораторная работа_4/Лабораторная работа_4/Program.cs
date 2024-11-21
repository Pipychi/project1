using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("  Задание 1");
            // создаем список, где будем хранить данные 
            List<string> zad1 = new List<string>();

            string x;
            Console.WriteLine("Вам необходимо ввести элементы списка\n(чтобы завершить ввод, введите 'end')");

            // ввод данных от пользователя
            while (true)
            {
                x = Console.ReadLine();
                if (x.ToLower() == "end")
                {
                    break;
                }
                zad1.Add(x);
            }

            // переворачиваем список и выводим его на экран
            Tasks.ReverseList(zad1);
            Console.WriteLine("\nПеревернутый список:");
            Tasks.PrintList(zad1);


            Console.WriteLine("\n  Задание 2");
            //создаем список, где будем хранить данные
            LinkedList<string> zad2 = new LinkedList<string>();

            string y;
            Console.WriteLine("Вам необходимо ввести элементы списка\n(чтобы завершить ввод, введите 'end')");
            // ввод данных от пользователя
            while (true)
            {
                y = Console.ReadLine();
                if (y.ToLower() == "end")
                {
                    break;
                }
                zad2.AddLast(y);
            }

            Console.Write("Введите элемент, который хотите вставить: ");
            string f = Console.ReadLine();

            Console.Write("Введите элемент, справа и слева от которого хотите вставить новый элемент: ");
            string e = Console.ReadLine();

            Tasks.InsertElement(zad2, e, f);
            Console.WriteLine("Список после вставки нового элемента:");
            Tasks.PrintLinkedList(zad2);



            Console.WriteLine("\n  Задание 3");
            // перечень всех дискотек
            HashSet<string> allDiscos = new HashSet<string>
            {"Дискотека 1", "Дискотека 2", "Дискотека 3", "Дискотека 4", "Дискотека 5", "Дискотека 6"};

            // список дискотек, которые посетили студенты 
            List<List<string>> studentDiscos = new List<List<string>>
            {
                new List<string> {"Дискотека 1", "Дискотека 2", "Дискотека 4", "Дискотека 6" }, // Студент 1
                new List<string> { "Дискотека 1", "Дискотека 5" },                             // Студент 2
                new List<string> { "Дискотека 1" },                                           // Студент 3
                new List<string> { "Дискотека 2", "Дискотека 6", "Дискотека 1"}              // Студент 4
            };

            // находим дискотеки, которые посетили все студенты
            HashSet<string> visitAllDiscos = Tasks.FindDiscosVisitAllStudents(studentDiscos);
            Console.WriteLine(" - Список дискотек, которые посетили все студенты:");
            foreach (string disco in  visitAllDiscos)
            {
                Console.WriteLine(disco);
            }

            // находим список дискотек, которые посетили некоторые студенты
            HashSet<string> visitSomeDiscos = Tasks.FindDiscosVisitSomeStudents(studentDiscos);
            Console.WriteLine(" \n- Список дискотек, которые посетили некоторые студенты:");
            foreach (string disco in visitSomeDiscos)
            { 
                Console.WriteLine(disco); 
            }

            // находим список дискотек, которые не посетил ни один студент
            HashSet<string> visitNobodyDiscos = Tasks.FindDiscosVisitNobodyStudents(studentDiscos, allDiscos);
            Console.WriteLine(" \n- Список дискотек, которые не посетил ни один студент:");
            foreach (string disco in visitNobodyDiscos)
            {
                Console.WriteLine(disco);
            }

            //// случай, если список пуст
            //Console.WriteLine("\nСлучай, если список пуст");
            //List<List<string>> zeroStudentDiscos = new List<List<string>>();
            //HashSet<string> discosVisitZero = Tasks.FindDiscosVisitAllStudents(zeroStudentDiscos);
            //Console.WriteLine("Дискотеки, посещенные всеми студентами (eсли пустой список):");
            //foreach (string disco in discosVisitZero)
            //{
            //    Console.WriteLine(disco); // не будет ничего, так как список пуст
            //}

            Console.WriteLine("\n  Задание 4");
            string filepath = "example.txt"; // путь к входному файлу.
            Tasks.FinalPrintSortedCharacters(filepath);


            Console.WriteLine("\n  Задание 5");
            Tasks.Task5();


            Console.WriteLine("\nНажмите enter, чтобы завершить программу");
            Console.ReadLine();
        }
    }
}
