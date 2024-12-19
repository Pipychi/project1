using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_6
{
    // класс, который представляет Попугая
    internal class Parrot: IMeowing
    {
        private string name; // имя попугая


        // свойство для доступа к полю
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        // конструктор с параметрами
        public Parrot(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Имя попугая не должно быть пустым.");
            }
            this.Name = name;
        }

        // переопределение метода для вывода информации о попугае
        public override string ToString()
        {
            return $"попугай: {Name}";
        }

        // метод для издавания звука попугаем
        public void SoundMake()
        {
            Console.WriteLine($"{Name}: чирик");
        }
    }
}
