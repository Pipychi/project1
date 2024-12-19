using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_6
{
    // класс, который отвечает за кэширование вещественного значения дроби
    internal class FractionCache
    {
        private Fraction fraction; // Экземпляр дроби
        private double? cachedValue; // Кэшированное значение

        // конструктор 
        public FractionCache(Fraction fraction)
        {
            this.fraction = fraction;
            cachedValue = null; // изначально кэш не инициализирован
        }

        //метод, который возвращает кэшированное вещественное значение дроби
        public double GetDoubleCachedValue()
        {
            if (!cachedValue.HasValue) // Если кэш не инициализирован
            {
                cachedValue = fraction.GetDoubleValue(); // вычисляем значение
            }
            return cachedValue.Value; // возвращаем кэшированное значение
        }

        // метод, который устанавливает новые значения для числителя и знаменателя дроби
        public void SetFraction(int numerator, int denominator)
        {
            fraction.SetFraction(numerator, denominator);
            // сбрасываем кэшированное значение, так как дробь была изменена
            cachedValue = null; 
        }
    }
}
