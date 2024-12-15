using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Cells;

namespace Лабораторная_работа_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // путь к файлу для протокола действий
            string protocolFilePath = "protocol.txt";

            string protocolChoice;
            // запрос на необходимость создания нового файла для протокола
            do
            {
                Console.WriteLine("Необходимо ли создать новый файл для протокола? (да/нет)");
                protocolChoice = Console.ReadLine().ToLower();
            } 
            while (protocolChoice != "да" && protocolChoice != "нет");


            bool isNewProtocol = (protocolChoice == "да");

            // Инициализация файла
            using (StreamWriter procWriter = new StreamWriter(protocolFilePath, !isNewProtocol))
            {
                procWriter.WriteLine($"{DateTime.Now}: Начало сеанса."); // Запись начала сеанса

                try
                {
                    // Создание объекта Hotel для работы с бд
                    Hotel hotel = new Hotel();

                    // Основное меню
                    while (true)
                    {
                        Console.WriteLine("\nВыберите действие:");
                        Console.WriteLine("1. Чтение базы данных из Excel файла");
                        Console.WriteLine("2. Просмотр базы данных");
                        Console.WriteLine("3. Удаление элемента по ключу");
                        Console.WriteLine("4. Корректировка элементов (по ключу)");
                        Console.WriteLine("5. Добавление элементов. ");
                        Console.WriteLine("6. Определить среднюю стоимость проживания за сутки у гостиниц категории - N");
                        Console.WriteLine("7. Вывести перечень клиентов, заселившихся 05.06.20019 ");
                        Console.WriteLine("8. Вывести перечень клиентов, которые проживали в гостинице 3 категории с 01.07.2019 по 15.07.2019 ");
                        Console.WriteLine("9. Определить общую стоимость проживания за сутки в номерах категории 5, забронированных клиентами из г. Уфа раньше 15 июня.");
                        Console.WriteLine("0. Выход");
                        Console.WriteLine("\nВНИМАНИЕ: перед выполнением 2-9 пункта необходимо прочитать БД (выполнить действие 1)\n");

                        Console.Write("Ваш выбор: ");
                        var choice = Console.ReadLine();
                        procWriter.WriteLine($"{DateTime.Now}: Выбор действия - {choice}"); // протоколирование выбора действия 

                        switch (choice)
                        {
                            case "1":
                                hotel.ReadDatabase(procWriter);
                                break;
                            case "2":
                                hotel.ViewingDatabase(procWriter);
                                break;
                            case "3":
                                hotel.DeleteElement(procWriter);
                                break;
                            case "4":
                                hotel.AdjustingAnElement(procWriter);
                                break;
                            case "5":
                                hotel.AddElement(procWriter);
                                break;
                            case "6":
                                while (true)
                                {
                                    Console.Write("Введите категорию гостиницы: ");
                                    if (int.TryParse(Console.ReadLine(), out int N))
                                    {
                                        hotel.Zapros1(procWriter, N);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректный ввод категории. Попробуйте снова.");
                                    }
                                }
                                break;
                            case "7":
                                hotel.Zapros2(procWriter);
                                break;
                            case "8":
                                hotel.Zapros3(procWriter);
                                break;
                            case "9":
                                hotel.Zapros4(procWriter);
                                break;
                            case "0":
                                procWriter.WriteLine($"{DateTime.Now}: Завершение сеанса.");
                                Console.WriteLine("Вы завершили работу с программой");
                                return;
                            default:
                                Console.WriteLine("Данного действия не существет. Попробуйте снова."); // Обработка неверного выбора
                                break;
                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    procWriter.WriteLine($"{DateTime.Now}: Возникла ошибка. Файла Excel по указанному пути не существует.");
                    Console.WriteLine($"Возникла ошибка. Файла Excel по указанному пути не существует");
                    Console.Write("Нажмите enter, чтобы выйти их программы");
                    Console.ReadLine();
                }
            }
        }
    }
}
