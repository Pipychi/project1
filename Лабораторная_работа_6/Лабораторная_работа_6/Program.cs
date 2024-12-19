using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nВведите номер задания:\n1.Кот \n2.Дроби\n0.Выход из программы");
                Console.Write("\nВаш выбор: ");
                var choice = Console.ReadLine();


                switch (choice)
                {
                    case "1":
                        // 1 пункт
                        Console.WriteLine("1 пункт задания.");
                        Cat cat1 = new Cat("Барсик"); // создаем кота Барсик
                        Console.WriteLine(cat1.ToString());

                        cat1.Meow(); // 1 раз мяукнул
                        cat1.Meow(3); // 3 раза мяукнул

                        // 2 пункт 
                        var animals = new List<IMeowing>(); // создаем список для хранения животных, которые могут издавать звук
                        var soundCounter = new MeowCount<IMeowing>(); // создаем экземпляр для подсчета звуков

                        int animalCount;
                        // Ввод животных от пользователя
                        while (true)
                        {
                            Console.Write("\nВведите количество животных: ");
                            if (int.TryParse(Console.ReadLine(), out animalCount) && animalCount > 0)
                            {
                                break; // Выход из цикла, если ввод корректен
                            }
                            Console.WriteLine("Ошибка, Вам необходимо ввести положительное целое число. Попробуйте снова");
                        }

                        for (int i = 0; i < animalCount; i++)
                        {
                            string type;
                            while (true)
                            {
                                Console.Write("Введите тип животного: кот/попугай: ");
                                type = Console.ReadLine().ToLower();
                                if (type == "кот" || type == "попугай")
                                {
                                    break;
                                }
                                Console.WriteLine("Неизвестный тип животного. Пожалуйста, введите 'кот' или 'попугай'.");
                            }

                            Console.Write("Введите имя животного:");
                            string name = Console.ReadLine();

                            int soundCount;
                            while (true)
                            {
                                Console.Write("Введите количество звуков, которое оно издает: ");
                                if (int.TryParse(Console.ReadLine(), out soundCount) && soundCount >= 0)
                                {
                                    break;
                                }
                                Console.WriteLine("Ошибка: неккоректный ввод количества звуков");
                            }

                            IMeowing animal; // создаем переменную для хранения экземпляра животного
                            if (type == "кот")
                            {
                                animal = new Cat(name);  // создаем кота с указанным именем
                            }
                            else if (type == "попугай")
                            {
                                animal = new Parrot(name);  // создаем попугая с указанным именем
                            }
                            else
                            {
                                Console.WriteLine("Неизвестный тип животного. Пожалуйста, введите 'кот' или 'попугай'.");
                                continue;  // продолжаем цикл, не добавляя животное в список
                            }

                            animals.Add(animal);
                            for (int j = 0; j < soundCount; j++)
                            {
                                animal.SoundMake();
                                soundCounter.CountSound(name); // Учитываем имя животного для подсчета
                            }
                        }

                        Console.WriteLine("\n2 пункт. (Принимает набор объектов способных издавать звук и вызывает его у каждого объекта");
                        // Используем для вызова звуков для всех животных в списке
                        MeowHelper.MakeMeowForEveryone(animals);

                        // Получаем и выводим общее количество звуков для каждого животного
                        Console.WriteLine("\n3 пункт. Подсчет количества звуков");
                        var allCounts = soundCounter.GetAllCounts();
                        Console.WriteLine("\nОбщее количество звуков для каждого животного:");
                        foreach (var entry in allCounts)
                        {
                            Console.WriteLine($"Животное {entry.Key} издало звук {entry.Value} раз(а).");
                        }
                        break;

                    case "2":
                        // 1 ПУНКТ
                        Console.WriteLine("\n1 пункт задания");
                        // создаем несколько экземпляров дробей
                        Fraction f1 = new Fraction(1, 3);
                        Fraction f2 = new Fraction(2, 3);
                        Fraction f3 = new Fraction(4, 5);

                        //использование методов
                        Fraction sum = f1 + f3;
                        Fraction dif = f2 - f1;
                        Fraction mult = f2 * f3;
                        Fraction div = f3 / f1;

                        Fraction sum1 = f1 + 1;
                        Fraction dif1 = f2 - 1;
                        Fraction mult1 = f3 * 2;
                        Fraction div1 = f1 / 3;

                        Fraction res = f1 + f2 / f3 - 5;

                        // вывод результата
                        Console.WriteLine(f1.ToString() + " + " + f3.ToString() + " = " + sum);
                        Console.WriteLine($"{f2} - {f1} = {dif}");
                        Console.WriteLine($"{f2} * {f3} = {mult}");
                        Console.WriteLine($"{f3} : {f1} = {div}");

                        Console.WriteLine($"{f1} + 1 = {sum1}");
                        Console.WriteLine($"{f2} - 1 = {dif1}");
                        Console.WriteLine($"{f3} * 2 = {mult1}");
                        Console.WriteLine($"{f1} : 3 = {div1}");

                        Console.WriteLine($"{f1} + {f2} : {f3} - 5 = {res}");
                        // 2 ПУНКТ
                        Console.WriteLine("\n2 пункт задания. Сравнение дробей");
                        Console.WriteLine("\nСейчас вам необходимо будет ввести значение первой дроби");
                        Fraction userInput1 = Fraction.GetValueFraction(); // получаем значения первой дроби от пользователя
                        Console.WriteLine("\nСейчас вам необходимо будет ввести значение второй дроби");
                        Fraction userInput2 = Fraction.GetValueFraction(); // получаем значения второй дроби от пользователя

                        Console.WriteLine("Равны ли введенные вами дроби? " + userInput1.Equals(userInput2));

                        // 3 ПУНКТ
                        Console.WriteLine("\n3 пункт задания. Клонирование дроби.");
                        Console.WriteLine("\nСейчас вам необходимо будет ввести значение дроби, которую хотите клонировать");
                        Fraction userInput = Fraction.GetValueFraction(); // получаем значение дроби от пользователя
                        Fraction clonFraction = (Fraction)userInput.Clone();  // клонирование дроби
                        Console.WriteLine("Клонированная дробь: " + clonFraction.ToString()); // вывод клонированной дроби


                        // 4 ПУНКТ
                        Console.WriteLine("\n4 пункт задания. Шаблоны");
                        Console.WriteLine("\nСейчас вам необходимо будет ввести значение дроби");
                        Fraction userInput4 = Fraction.GetValueFraction(); // получаем значение дроби от пользователя
                        FractionCache fractionCache = new FractionCache(userInput4);

                        Console.WriteLine("Вещественное значение дроби " + userInput4.ToString() + " = " + fractionCache.GetDoubleCachedValue());

                        Console.WriteLine("Теперь для введенной вами дроби поменяем значение на 1/2");
                        fractionCache.SetFraction(1, 2);
                        Console.WriteLine("Обновленная дробь: " + userInput4.ToString());
                        Console.WriteLine($"Вещественное значение обновленной дроби = " + fractionCache.GetDoubleCachedValue());

                        break;

                    case "0":
                        Console.WriteLine("Вы завершили работу с программой");
                        return;

                    default:
                        Console.WriteLine("Вы ввели несуществующее задание. Попробуйте снова\n");
                        break;
                }
            }

        }
    }
}
