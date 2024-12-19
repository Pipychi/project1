using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_6
{
    // сущность Кот 
    public class Cat: IMeowing
    {
        private string name; // имя кота


        // свойство для доступа к полю
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        // конструктор с параметрами
        public Cat(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя кота не должно быть пустым.");
            }
            this.Name = name; 
        }

        // переопределение метода для вывода информации о котике
        public override string ToString()
        {
            return $"кот: {Name}";
        }


        // мяуканье без параметров
        public void Meow()
        {
            Console.WriteLine($"{Name}: мяу");
        }


        // мяуканье с параметром 
        public void Meow(int N)
        {
            if (N <= 0)
            {
                Console.WriteLine($"Кот {Name} не мяукал"); // обрабатываем случай, если введенное число меньше 0
                return;
            }

            string meowString = ""; // переменная для хранения строки с мяу 
            for (int i = 0; i < N; i++)
            {
                meowString += "мяу";
                if (i < N - 1)      // добавление дефиса между "мяу", кроме последнего
                {
                    meowString += "-";
                }
            }
            Console.WriteLine($"{Name}: {meowString}");
        }

        // метод для издавания звука котом ( реализация метода интерфейса)
        public void SoundMake()
        {
            Meow();
        }
    }
}
