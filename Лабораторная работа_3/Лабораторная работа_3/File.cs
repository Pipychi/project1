using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Лабораторная_работа_3
{

    // Структура для хранения информации об игрушке (задание 5)
    [Serializable] // Помечаем структуру как сериализуемую
    public struct Toy //oпределяет свойства игрушки
    {
        public string Name;    //название игрушки
        public decimal Price; //ее стоимость 
        public int MinAge;    // Минимальный возраст
        public int MaxAge;   //макс.возраст
    }

    internal class File
    {
        // Константы для хранения путей к файлам
        private const string InputFile = "numbers.bin"; // путь к исходному файлу
        public const string OutputFile = "filtred_numbers.bin"; // путь к файлу, который получится на выходе
                                                                
        private const string ToyFile = "toys.xml"; // путь к файлу с игрушками

        public const string File1 = "numbers6.txt"; // путь к текстовому файлу с числами задания 6

        public const string File2 = "numbers7.txt"; //путь к текстовому файлу с числами задания 7

        private const string TextFile1 = "text.txt"; // путь к исходному файлу с текстом для задания 8
        public const string TextFile2 = "newtext.txt"; // путь к новому текстовому файлу



        //метод, который будет заполнять бинарный файл случайными данными от 1 до максим.значения (ДЛЯ ЗАДАНИЯ 4)
        private static void FillingTheFileRandom(int count, int maxValue)
        {
            // Создаем объект Random для генерации случайных чисел
            Random random = new Random();
            // для автоматического закрытия потоков используем блочную конструкцию 
            using (FileStream fs = new FileStream(InputFile, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                for (int i = 0; i < count; i++)
                {
                    int number = random.Next(1, maxValue);
                    writer.Write(number);
                }
            }
        }

        //метод для фильтрации чисел (сохраняем те, которые некратны k) (ДЛЯ ЗАДАНИЯ 4)
        public static void FilterFile(int k)
        {
            FillingTheFileRandom(10, 100);  //заполняем файл 10 рандомными числами (макс - 100)
            using (FileStream fsIn = new FileStream(InputFile, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fsIn))
            using (FileStream fsOut = new FileStream(OutputFile, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fsOut))
            {
                // Читаем числа из файла "InputFile" до конца файла
                while (fsIn.Position < fsIn.Length)
                {
                    int number = reader.ReadInt32();
                    if (number % k != 0) // фильтруем числа, кратные k
                    {
                        writer.Write(number);
                    }
                }
            }
        }

        //// Метод для проверки существования файла.
        //public static bool FileExists(string filePath)
        //{
        //    // возвращаем true, если файл существует, иначе false.
        //    return File.Exists(filePath);
        //}


        // метод, который будет выводить содержимое файла на экран
        public static void PrintFile(string filepath) // Принимает путь к файлу (filepath)
        {
            using (FileStream fs = new FileStream(filepath, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                Console.WriteLine("Содержимое отфильтрованного файла:");
                while (fs.Position < fs.Length)
                {
                    int number = reader.ReadInt32();
                    Console.WriteLine(number);
                }
            }
        }

        // метод для заполнения файла с игрушками и сериализации их в XML (ДЛЯ ЗАДАНИЯ 5)
        public static void FillToyFile()
        {
            // Создаем список игрушек (Toy)
            List<Toy> toys = new List<Toy>
        {
            new Toy { Name = "Конструктор большой - Пирамиды", Price = 750, MinAge = 3, MaxAge = 12 },
            new Toy { Name = "Пупс Никита", Price = 1000, MinAge = 3, MaxAge = 6 },
            new Toy { Name = "Пупс Нина", Price = 1000, MinAge = 3, MaxAge = 6 },
            new Toy { Name = "Попрыгун", Price = 50, MinAge = 1, MaxAge = 14 },
            new Toy { Name = "Набор мебели - кухня", Price = 3000, MinAge = 3, MaxAge = 14 },
            new Toy { Name = "Мозаика", Price = 500, MinAge = 6, MaxAge = 12 },
            new Toy { Name = "Мяч", Price = 150, MinAge = 1, MaxAge = 12 },
            new Toy { Name = "Робот-трансформер", Price = 2500, MinAge = 6, MaxAge = 14 },
        };

            // Создаем сериализатор для списка игрушек
            XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));

            // Открываем файл ToyFile в режиме создания (FileMode.Create). Если файл существует, он будет перезаписан.
            using (FileStream stream = new FileStream(ToyFile, FileMode.Create))
            {
                // Сериализуем список игрушек в XML-формат и записываем в файл
                serializer.Serialize(stream, toys);
            }
        }

        // Метод для проверки, подходит ли игрушка для трехлетнего ребенка (кроме мяча) (ЗАДАНИЕ 5)
        public static void СheckingToysForThreeYearOld()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));

            // Загружаем игрушки из файла
            List<Toy> toys;
            using (FileStream stream = new FileStream(ToyFile, FileMode.Open))
            {
                toys = (List<Toy>)serializer.Deserialize(stream);
            }

            Console.WriteLine("Подходящие игрушки для трехлетнего ребенка:");
            foreach (var toy in toys)
            {
                // Проверяем возрастные границы и исключаем игрушки, которые являются мячами
                if (toy.MinAge <= 3 && toy.MaxAge >= 3 && toy.Name != "Мяч")
                {
                    Console.WriteLine($"- {toy.Name}, стоимость: {toy.Price} рублей");
                }
            }
        }

        // метод для заполнения текстового файла случайными цифрами от 1 до максим.значения (ДЛЯ ЗАДАНИЯ 6)
        public static void FillingTextFile1Randomly(int count, int maxValue)
        {
            // Создаем объект Random для генерации случайных чисел
            Random random = new Random();
            // для автоматического закрытия потоков используем блочную конструкцию 
            using (StreamWriter writer = new StreamWriter(File1)) // открываем файл в режиме записи для перезаписи существующего файла или создания нового
            {
                // цикл для записи случайных цифр
                for (int i = 0; i < count; i++)
                {
                    int number = random.Next(1, maxValue + 1); //генерируем случайное число
                    writer.WriteLine(number);  //записываем число в файл
                }
            }
        }

        //метод для поиска суммы максимального и минимального элементов в файле
        public static int SearchSumMinAndMax(string filepath)
        {
            //// проверка на существование файла
            //if (!FileExists(filepath))
            //{
            //    Console.WriteLine("Файл не найден.");
            //    return 0; // Возвращаем 0, если файл не найден.
            //}

            //переменные для хранения макс и мин чисел.
            int min = int.MaxValue;
            int max = int.MinValue;

            // открываем файл для чтения
            using (StreamReader reader = new StreamReader(filepath))
            {
                // читаем числа из файла построчно
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (int.TryParse(line, out int number)) // преобразуем строку в целое число
                    {
                        // обновляем значения мин и макс значения
                        min = Math.Min(min, number);
                        max = Math.Max(max, number);
                    }
                }
            }
            return min + max; // возвращаем сумму макс и мин чисел в файле
        }

        //метод, который выводит содержимое текстового файла на экран
        public static void PrintTextFile(string filePath)
        {
            //// Проверяем, существует ли файл.
            //if (!FileExists(filePath))
            //{
            //    Console.WriteLine($"Файл {filePath} не найден.");
            //    return; // выходим из метода, если файл не найден.
            //}

            // Открываем файл для чтения.
            using (StreamReader reader = new StreamReader(filePath))
            {
                Console.WriteLine($"Содержимое файла {filePath}:");
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        // метод для заполнения текстового файла случайными цифрами от 1 до максим.значения (ДЛЯ ЗАДАНИЯ 7)
        public static void FillingTextFile2Randomly(int count, int maxValue)
        {
            // Создаем объект Random для генерации случайных чисел
            Random random = new Random();
            // для автоматического закрытия потоков используем блочную конструкцию 
            using (StreamWriter writer = new StreamWriter(File2)) // открываем файл в режиме записи
            {
                // цикл для записи случайных цифр
                for (int i = 0; i < count; i++)
                {
                    int number = random.Next(1, maxValue + 1); //генерируем случайное число
                    writer.WriteLine(number);  //записываем число в файл
                }
            }
        }

        // Метод для вычисления суммы четных элементов в файле.
        public static int FindSumEvenElements(string filePath)
        {
            // переменная для хранения суммы четных чисел
            int sum = 0;

            using (StreamReader reader = new StreamReader(filePath))  // открываем файл для чтения
            {
                string line;          
                while ((line = reader.ReadLine()) != null)   // читаем числа из файла построчно
                {
                    // разделяем строку на числа
                    string[] numbers = line.Split(' ');

                    // проходим по каждому числу в строке
                    foreach (string elem in numbers)
                    {
                        // преобразуем строку в целое число
                        if (int.TryParse(elem, out int number))
                        {
                            if (number % 2 == 0)  //проверяем четность числа
                            {
                                sum += number;
                            }
                        }
                    }
                }
            }
            return sum;
        }

        // метод для создания нового файла с первыми символами строк исходного файла
        public static void CreateNewFile()
        {
            // открываем исходный файл для чтения
            using (StreamReader reader = new StreamReader(TextFile1))
            {
                // октрываем новый файл для записи 
                using (StreamWriter writer = new StreamWriter(TextFile2))
                {
                    //читаем строки из исходного файла 
                    string line; 
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Length > 0) // проверяем, не пустая ли строка
                        {
                            writer.WriteLine(line[0]); // записываем первый символ в файл
                        }
                    }
                }
            }
        }
    }
}

