using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_6
{
    // класс для подсчета издания звуков
    internal class MeowCount<T> where T : IMeowing
    {
        // словарь для хранения количества звуков каждого животного по его имени.
        // ключ - имя животного, значение - количество издаваемых звуков
        private Dictionary<string, int> soundCounts = new Dictionary<string, int>();


        // Метод для подсчета звука, издаваемого животным
        public void CountSound(string animalName)
        {
            // Проверка на null или пустую строку для имени животного
            if (string.IsNullOrEmpty(animalName))
            {
                throw new ArgumentException("Имя животного не может быть пустым или null.", nameof(animalName));
            }

            try
            {
                // Попытка получить значение счетчика, если животное уже есть в словаре
                soundCounts.TryGetValue(animalName, out int count);
                soundCounts[animalName] = count + 1;
            }
            catch (Exception ex)
            {
                throw new Exception($"Произошла ошибка при подсчете звука для животного '{animalName}'.", ex);
            }
        }


        // Метод для получения всех подсчитанных звуков
        public Dictionary<string, int> GetAllCounts()
        {
            try
            {
                // Возвращаем копию словаря с подсчетами
                return new Dictionary<string, int>(soundCounts);
            }
            catch (Exception ex)
            { 
                throw new Exception("Возникла ошибка при получении счетчиков звуков.", ex); 
            }
        }
    }
}
