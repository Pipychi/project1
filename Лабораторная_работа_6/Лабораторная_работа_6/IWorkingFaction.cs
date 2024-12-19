using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_6
{
    // интерфейс для работы с дробью
    internal interface IWorkingFaction
    {
        double GetDoubleValue(); // метод для получения вещественного значения 
        void SetFraction(int numerator, int denominator); // метод для установки числителя и знаменателя
    }
}
