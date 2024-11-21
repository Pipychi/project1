using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_4
{
    // класс, который представляет аббитуриента
    public class Applicant
    {
        public string LastName { get; set; } // Фамилия 
        public string FirstName { get; set; } // Имя 
        public int[] Scores { get; set; } // Баллы по предметам

        // Пустой конструктор для сериализации
        public Applicant() { }

        // Конструктор с параметрами
        public Applicant(string lastName, string firstName, int[] scores)
        {
            LastName = lastName;
            FirstName = firstName;
            Scores = scores;
        }
    }
}
