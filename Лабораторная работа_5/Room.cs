using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_5
{
    // класс для представления номера
    public class Room
    {
        private int roomCode; // код номера
        private int floor; // этаж
        private int capacity; // число мест
        private int price; // стоимость проживания за сутки
        private int category; // категория гостиницы

        // Свойства для доступа к приватным полям
        public int RoomCode
        {
            get { return roomCode; }
            set { roomCode = value; }
        }
        public int Floor
        {
            get { return floor; }
            set { floor = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public int Category
        {
            get { return category; }
            set { category = value; }
        }

        // Конструктор с параметрами
        public Room(int roomCode, int floor, int capacity, int price, int category)
        {
            this.RoomCode = roomCode;
            this.Floor = floor;
            this.Capacity = capacity;
            this.Price = price;
            this.Category = category;
        }

        // пустой конструктор
        public Room()
        { }

        // Переопределение метода ToString для удобного отображения информации о номере
        public override string ToString()
        {
            return $"Номер:{RoomCode}, Этаж:{Floor}, Число мест:{Capacity}, Цена:{Price} р , Категория:{Category}";
        }
    }
}
