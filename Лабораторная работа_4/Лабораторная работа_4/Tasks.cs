using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Лабораторная_работа_4
{
    [Serializable]
    internal class Tasks

    {
        // ЗАДАНИЕ 1: List
        // метод, который переворачивает список
        public static void ReverseList<T1>(List<T1> list)
        {
            // проверка на список
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), "Список не должен быть null");
            }

            list.Reverse();
        }


        // метод, который выводит содержимое списка на экран
        public static void PrintList<T1>(List<T1> list)
        {
            if (list == null || list.Count == 0)
            {
                Console.WriteLine("Ваш список пуст.");
                return;
            }

            foreach (var i in list)
            {
                Console.WriteLine(i + "");
            }
            Console.WriteLine();
        }




        // ЗАДАНИЕ 2: LinkedList
        // метод, который вставляет элемент F справа и слева от элемента E 
        public static void InsertElement<T2>(LinkedList<T2> list, T2 E, T2 F)
        {
            // проверка, что список не пустой
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), "Список не должен быть null");
            }
            // ищем в списке элемент E
            LinkedListNode<T2> currentnode = list.Find(E);
            while (currentnode != null)
            {
                // если текущий элемент равен Е
                if (currentnode.Value.Equals(E))
                {
                    // вставляем элемент F слева (before) и справа (after)
                    list.AddBefore(currentnode, F);
                    list.AddAfter(currentnode, F);
                    // переходим к следущему элементу 
                    currentnode = currentnode.Next;
                }
                else
                {
                    // переходим к следущему элементу 
                    currentnode = currentnode.Next;
                }
            }

        }

        // метод, который выводит содержимое списка на экран
        public static void PrintLinkedList<T2>(LinkedList<T2> list)
        {
            if (list == null || list.Count == 0)
            {
                Console.WriteLine("Ваш список пуст.");
                return;
            }
            Console.WriteLine(string.Join("; ", list));

        }




        // Задание 3. HashSet
        // метод для определения перечня дискотек, куда ходили все студенты
        public static HashSet<string> FindDiscosVisitAllStudents(List<List<string>> studentDiscos)
        {
            // Проверка на null или пустой список
            if (studentDiscos == null || studentDiscos.Count == 0)
            {
                //нет студентов, возвращаем пустой список
                Console.WriteLine("Ваш список пуст.");
                return new HashSet<string>();
            }

            // перебор начинаем с набора дискотек, посещенных первым студентом
            HashSet<string> allVisit = new HashSet<string>(studentDiscos[0]);
            // перебираем оставшихся студентов
            foreach (var disc in studentDiscos)
            {
                allVisit.IntersectWith(disc);
            }
            // возвращаем набор дискотек, которые посетили все студенты
            return allVisit;
        }


        // метод для определения перечня дискотек, которые посетили некоторые студенты
        public static HashSet<string> FindDiscosVisitSomeStudents(List<List<string>> studentDiscos)
        {
            // Проверка на null или пустой список
            if (studentDiscos == null || studentDiscos.Count == 0)
            {
                //нет студентов, возвращаем пустой список
                Console.WriteLine("Ваш список пуст.");
                return new HashSet<string>();
            }
            // создаем пустой набор для хранение дискотек
            HashSet<string> someVisit = new HashSet<string>();
            // перебираем дискотеки студентов
            foreach (var disc in studentDiscos)
            {
                // добавляем дискотеки каждого студента
                someVisit.UnionWith(disc);
            }
            // возвращаем набор дискотек, которые посетили некоторые студенты (причем набор уникальных значений)
            return someVisit;
        }


        // метод для определения перечня дискотек, которые не посетил ни один студент
        public static HashSet<string> FindDiscosVisitNobodyStudents(List<List<string>> studentDiscos, HashSet<string> allDiscos)
        {
            // Проверка на null или пустой список, а также на null для allDiscos
            if (studentDiscos == null || studentDiscos.Count == 0 || allDiscos == null)
            {
                // Если да, возвращаем все дискотеки, которые были переданы
                if (allDiscos == null)
                {
                    Console.WriteLine("Ваш список пуст.");
                    return new HashSet<string>();
                }
                else
                {
                    return new HashSet<string>(allDiscos);
                }
            }
            // cначала получим набор дискотек, посещенных хотя бы одним студентом
            HashSet<string> visitsome = FindDiscosVisitSomeStudents(studentDiscos);
            // Создаем набор из всех дискотек и удаляем те, что были посещены студентами
            HashSet<string> notVisit = new HashSet<string>(allDiscos);
            notVisit.ExceptWith(visitsome);

            // возвращаем набор дискотек, на которых никто не был
             return notVisit;
        }

       


        // Задание 4. HashSet
        // метод, который извлекает уникальные символы из слов текста с четными номерами (вспомогательный метод)
        private static HashSet<char> GetEvenCharacters(string text)
        {
            // инициализируем HashSet для хранения уникальных символов
            HashSet<char> characters = new HashSet<char>();

            // создаем новый список строк для хранения слов (размер результата неизвестен заранее)
            List<string> words = new List<string>();
            // разделяем текст на слова, используя пробел, табуляцию, символы перевода строки в качестве разделителей
            // и перебираем все слова, полученные в результате разбиения текста
            foreach (string word in text.Split(new[] { ' ', '\n', '\t', '\r' }))
            {
                // проверка, является ли слово непустой строкой
                if (!string.IsNullOrEmpty(word))
                {
                    // если слово непустое, добавляем его в список слов
                    words.Add(word);
                }
            }
            // проходимся по словам с четными номерами
            for (int i = 1; i < words.Count; i++)
            {
                // преобразуем символ в нижний регистр для случая регистра
                foreach (char c in words[i].ToLowerInvariant())
                {
                    // если текущий символ является буквой
                    if (char.IsLetter(c))
                    {
                        // добавляем ее
                        characters.Add(c);
                    }
                }
            }
            return characters;
        }

        // метод, который сортирует символы в алфавитном порядке и выводит их на экран (вспомогательный метод)
        private static void PrintSortedCharacters(HashSet<char> characters)
        {
            // случай, когда множество символов пустое
            if (characters.Count == 0)
            {
                Console.WriteLine("В словах с четными номерами отсутсвуют символы");
                return;
            }
            // сортируем символы
            List<char> charList = characters.ToList();    // преобразуем HashSet в List
            charList.Sort(); // сортируем List
            // выводим отсортированный список экран
            Console.WriteLine("Символы, которые встречаются хотя бы однажды в словах с чётными номерами, в алфавитном порядке:");
            Console.WriteLine(string.Join(", ", charList));
        }


        // метод, который принимает путь к файлу и выводит отсортированный список на экран (основной метод)
        public static void FinalPrintSortedCharacters(string filepath)
        {
            // проверка на сущестование файла.  Если файл не существует
            if (!File.Exists(filepath))
            {
                // выводится сообщение об ошибке и метод завершается
                Console.WriteLine($"Ошибка: Файл '{filepath}' не найден.");
                return;
            }

            // Блок для обработки возможных исключений при работе с файлом
            try
            {
                // читаем весь текст из файла
                string text = File.ReadAllText(filepath);

                // извлекаем символы из слов с четными номерами
                HashSet<char> evenWord = GetEvenCharacters(text);

                // сортируем и выводим символы
                PrintSortedCharacters(evenWord);
            }
            catch (Exception ex)
            {
                // выводим сообщение об ошибке, если она возникла при работе с файлом
                Console.WriteLine($"Ошибка при обработке файла: {ex.Message}");
            }
        }




        // Задание 5.SortedList
        // константы для хранения минимальных баллов для допуска
        private const int MinScoreSubject = 30;
        private const int MinTotalScore = 140;
        private const string ApplicantFile = "applicants.xml"; // путь к файлу с абитуриентами


        // метод для заполнения Xml файла данными
        private static void FillingtheData(string filepath)
        {
            // Создаем список абитуриентов с данными
            List<Applicant> data = new List<Applicant>
            {
                new Applicant("Романов", "Вельямин", new[] { 48, 39, 55 }),
                new Applicant("Ишманов", "Захар", new[] { 60, 80, 77 }),
                new Applicant("Пашкович", "Валерия", new[] { 70, 82, 67 }),
                new Applicant("Темных", "Савелий", new[] { 68, 70, 60 }),
                new Applicant("Андреева", "Ольга", new[] { 31, 50, 48 }),
                new Applicant("Моисеев", "Вадим", new[] { 31, 80, 28 }),
                new Applicant("Кропоткина", "Анна", new[] { 51, 50, 52 }),
                new Applicant("Живых", "Святослав", new[] { 71, 20, 38 }),
                new Applicant("Пичеркина", "Наталья", new[] { 31, 30, 38 }),
                new Applicant("Сушкин", "Максим", new[] { 61, 34, 18 })
            };

            // Сериализация данных в XML файл
            // Создаем сериализатор для списка абитуриентов
            XmlSerializer serializer = new XmlSerializer(typeof(List<Applicant>));
            // открываем файл в режиме создания. Если файл существует, он будет перезаписан.
            using (FileStream file = new FileStream(filepath, FileMode.Create))
            {
                // Сериализуем список абитуриентов в XML-формат и записываем в файл
                serializer.Serialize(file, data);
            }
        }


        // метод, который загружает данные из XML файла (вспомогательный метод)
        private static List<Applicant> DownloadingDataFromFile(string filepath)
        {
            // Если файл не существует, заполняем его данными
            if (!File.Exists(filepath))
            {
                // Обрабатываем ошибки при создании файла и записи данных
                try
                {
                    FillingtheData(filepath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Возникла ошибка при записи данных в файл. {ex.Message}");
                    return new List<Applicant>();
                }
            }

            // Десериализация данных из XML файла
            XmlSerializer serializer = new XmlSerializer(typeof(List<Applicant>));
            using (FileStream file = new FileStream(filepath, FileMode.Open))   //открываем файл для чтения
            {
                return (List<Applicant>)serializer.Deserialize(file);
            }
        }


        // метод для получения абитуриентов, допущенных к экзаменам в первом потоке
        private static SortedList<string, Applicant> GetAdmittedApplicants(List<Applicant> applicants)
        {
            // создаем отсортированный список допущенных абитуриентов 
            SortedList<string, Applicant> admittedApplicants = new SortedList<string, Applicant>();

            // проверка каждого абитуриента
            foreach (var applicant in applicants)
            {
                // если абитуриент допущен, добавляем его в список
                if (IsAdmitted(applicant))
                {
                    string fullName = applicant.LastName + " " + applicant.FirstName; // полное имя абитуриента
                    admittedApplicants.Add(fullName, applicant); // добавляем в отсортированный список
                }
            }
            return admittedApplicants; // возвращаем список допущенных абитуриентов
        }


        // метод для проверки, соответствует ли абитуриент критериям допуска (вспомогательный метод)
        private static bool IsAdmitted(Applicant applicant)
        {
            int totalScore = 0; // создаем переменную для хранения общей суммы баллов

            // проверяем баллы по каждому предмету
            for (int i = 0; i < applicant.Scores.Length; i++)
            {
                // если балл меньше минимального, возвращаем false
                if (applicant.Scores[i] < MinScoreSubject)
                {
                    return false;
                }
                // добавляем балл к общей сумме
                totalScore += applicant.Scores[i];
            }
            // проверяем, удовлетворяет ли общая сумма баллов минимальному требованию по сумме баллов (больше 140 должна быть)
            return totalScore >= MinTotalScore;
        }

        // метод для вывода допущенных абитуриентов на экран (вспомогательный метод)
        private static void PrintAdmittedApplicants(SortedList<string, Applicant> qualifiedApplicants)
        {
            Console.WriteLine("Допущенные к экзаменам в первом потоке:"); 
            foreach (var applicant in qualifiedApplicants)
            {
                Console.WriteLine(applicant.Key); // выводим полное имя абитуриента
            }
        }


        // метод для вывода абитуриентов, допущенных к сдаче экзаменов в первом потоке (основной метод)
        public static void Task5()
        {
            try
            {
                // Загружаем абитуриентов из XML файла
                List<Applicant> applicants = DownloadingDataFromFile(ApplicantFile);

                // проверяем, что данные были загружены
                if (applicants.Count == 0)
                {
                    Console.WriteLine("Ошибка: Список абитуриентов пуст.");
                    return;
                }

                // Получаем список допущенных абитуриентов
                SortedList<string, Applicant> admittedApplicants = GetAdmittedApplicants(applicants);

                // вывод списка всех абитуриентов
                PrintApplicants(applicants);

                // Выводим допущенных абитуриентов
                PrintAdmittedApplicants(admittedApplicants);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникла ошибка. {ex.Message}");
                return;
            }
        }

        // Метод для вывода полного списка абитуриентов (вспомогательный метод)
        private static void PrintApplicants(List<Applicant> outputdata)
        {
            Console.WriteLine("Список всех абитуриентов:");

            foreach (var applicant in outputdata)
            {
                Console.WriteLine($"{applicant.LastName} {applicant.FirstName}");
            }
            Console.WriteLine(" ");
        }
    }
}

