using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_6
{
    // класс, который представляет собой Дробь
    internal class Fraction : ICloneable, IWorkingFaction // Реализация интерфейса ICloneable и IWorkingFaction
    {
        private int numerator; // числитель
        private int denominator; // знаменатель 

        // конструктор, принимающий числитель и знаменатель
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю.");
            }

            // Если знаменатель окажется отрицательным, меняем знаки числителя и знаменателя (т.к знаменатель всегда >0)
            if (denominator < 0)
            {
                this.numerator = (-1) * numerator;
                this.denominator = (-1) * denominator;
            }
            else
            {
                this.numerator = numerator;
                this.denominator = denominator;
            }

            // упрощаем дробь
            Simplified();
        }


        // переопределение метода для вывода дроби в виде ч/з
        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }


        // ПЕРЕГРЗУКИ ДЛЯ ДЕЙСТВИЙ С ДРОБЬЮ
        // перегрузка оператора для сложения дробей
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.numerator * f2.denominator + f1.denominator * f2.numerator, f1.denominator * f2.denominator);
        }
        
        // перегрузка оператора вычитания дробей
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.numerator * f2.denominator - f1.denominator * f2.numerator, f1.denominator * f2.denominator);
        }

        //перегрузка оператора для умножения дробей
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.numerator * f2.numerator, f1.denominator * f2.denominator);
        }

        // перегрузка оператора для деления дробей
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            // если знаменатель у второй дроби равен 0
            if (f2.numerator == 0)
            {
                throw new DivideByZeroException("Деление на ноль.");
            }

            return new Fraction(f1.numerator * f2.denominator, f2.numerator * f1.denominator);
        }

        // ПЕРЕГРЗУКИ ДЛЯ ДЕЙСТВИЙ С ЦЕЛЫМ ЧИСЛОМ
        // перегрузка  оператора сложения с целым числом 
        public static Fraction operator +(Fraction f, int n)
        {
            return new Fraction(f.numerator + n*f.denominator, f.denominator);
        }

        // перегрузка  оператора вычитания с целым числом
        public static Fraction operator -(Fraction f, int n)
        {
            return new Fraction(f.numerator - n * f.denominator, f.denominator);
        }

        //перегрузка оператора умножения с целым числом
        public static Fraction operator *(Fraction f, int n)
        {
            return new Fraction(f.numerator * n, f.denominator);
        }

        //перегрузка оператора деления на целое число
        public static Fraction operator /(Fraction f, int n)
        {
            if (n == 0)
            {
                Console.WriteLine("На ноль делить нельзя");
                throw new DivideByZeroException("Деление на ноль.");
            }
            return new Fraction(f.numerator, f.denominator * n);
        }

        // Приведение дроби к несократимому виду
        private void Simplified()
        {
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;
        }

        // метод дл нахождения наибольшего общего делителя
        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }


        // 2 ПУНКТ
        // Переопределение метода Equals сравнения
        public override bool Equals(object obj)
        {
            if (obj is Fraction other)
            {
                return numerator == other.numerator && denominator == other.denominator;
            }
            return false;
        }

        // метод для вода значений у дроби пользователем
        public static Fraction GetValueFraction()
        {
            int n, d; //переменные для хранения числителя и знаменателя
            while (true)
            {
                try
                {
                    Console.Write("Введите числитель дроби: ");
                    n = Convert.ToInt32(Console.ReadLine()); // вводим числитель
                    Console.Write("Введите знаменатель дроби: ");
                    d = Convert.ToInt32(Console.ReadLine()); // вводим знаменатель

                    // создаем новую дробь
                    return new Fraction(n, d);
                }
                catch(FormatException)
                {
                    Console.WriteLine("Возникла ошибка: Вы ввели не целое число. Попробуйте снова");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Возникла ошибка: {ex.Message}"); // Обработка исключения, если знаменатель нулевой
                }
            }
        }

        // 3 ПУНКТ 
        // метод клонирования
        public object Clone()
        {
            // возвращаем новый объект Дробь с теми же значениями полей
            return new Fraction(this.numerator, this.denominator);
        }


        // 4 ПУНКТ
        // метод для получения вещественного числа
        public double GetDoubleValue()
        {
            return (double)numerator / denominator;
        }

        // метод для установки числителя и знаменателя
        public void SetFraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю.");
            }

            this.numerator = numerator;
            this.denominator = denominator;
            Simplified(); // приводим к упрощенному виду
        }
    }
}
