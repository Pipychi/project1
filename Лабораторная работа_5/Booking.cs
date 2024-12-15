using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_5
{
    // класс для представления бронирования
    public class Booking
    {
        private int bookingCode;   // код бронирования
        private int clientCode; // код клиента
        private int roomCode;  // код номера
        private DateTime bookingDate;  // дата брони
        private DateTime checkInDate;  // дата заезда
        private DateTime checkOutDate; // дата выезда

        // Свойства для доступа к приватным полям
        public int BookingCode
        {
            get { return bookingCode; }
            set { bookingCode = value; }
        }
        public int ClientCode
        {
            get { return clientCode; }
            set { clientCode = value; }
        }
        public int RoomCode
        {
            get { return roomCode; }
            set { roomCode = value; }
        }
        public DateTime BookingDate
        {
            get { return bookingDate; }
            set { bookingDate = value; }
        }
        public DateTime CheckInDate
        {
            get { return checkInDate; }
            set { checkInDate = value; }
        }
        public DateTime CheckOutDate
        {
            get { return checkOutDate; }
            set { checkOutDate = value; }
        }
        // Конструктор с параметрами
        public Booking(int bookingCode, int clientCode, int roomCode, DateTime bookingDate, DateTime checkInDate, DateTime checkOutDate)
        {
            this.BookingCode = bookingCode;
            this.ClientCode = clientCode;
            this.RoomCode = roomCode;
            this.BookingDate = bookingDate;
            this.CheckInDate = checkInDate;
            this.CheckOutDate = checkOutDate;
        }

        // пустой конструктор
        public Booking() { }
        // переопределение метода ToString для удобного отображения информации
        public override string ToString()
        {
            return $"код брони: {BookingCode}, клиент:{ClientCode} , номер:{RoomCode} , дата брони:{BookingDate.ToShortDateString()}, проживание: {CheckInDate.ToShortDateString()} - {CheckOutDate.ToShortDateString()} ";
        }
    }
}
