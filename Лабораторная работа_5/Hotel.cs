using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;


namespace Лабораторная_работа_5
{
    internal class Hotel
    {
        // создаем списки для хранения данных 
        private List<Client> clients = new List<Client>(); // клиенты
        private List<Booking> bookings = new List<Booking>(); // бронирования
        private List<Room> rooms = new List<Room>();      // номера

        static string filePath = "LR5-var9.xls"; // путь  файлу Excel
        private Workbook workbook; // создание объекта для работы с эксель файлом, инициализируем в конструкторе 

        // Конструктор класса Hotel
        public Hotel()
        {
            // Проверка существования файла
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл Excel не найден по пути: {filePath}");
            }

            workbook = new Workbook(filePath); // создание объекта Workbook для работы с Excel файлом
        }


        // метод для чтения базы данных из Excel файла
        public void ReadDatabase(StreamWriter protocolWriter)
        {
            // Чтение таблицы клиенты
            Worksheet clientsSheet = workbook.Worksheets["Клиенты"]; // получение листа "Клиенты"
            if (clientsSheet == null)
            {
                protocolWriter.WriteLine($"{DateTime.Now}: Ошибка: Таблица 'Клиенты' не найдена.");
                return; // выход из функции, если лист не найден
            }

            for (int row = 1; row < clientsSheet.Cells.MaxDataRow + 1; row++)
            {
                try
                {
                    Client client = new Client() // Создание нового клиента
                    {
                        ClientCode = clientsSheet.Cells[row, 0].IntValue, // Чтение кода клиента
                        LastName = clientsSheet.Cells[row, 1].StringValue, // Чтение фамилии клиента
                        Name = clientsSheet.Cells[row, 2].StringValue, // Чтение имени
                        Patronymic = clientsSheet.Cells[row, 3].StringValue, // Чтение отчества
                        Address = clientsSheet.Cells[row, 4].StringValue // Чтение адреса клиента
                    };
                    clients.Add(client); // Добавление клиента в список
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при чтении данных из строки {row}: {ex.Message}");
                }
            }
            protocolWriter.WriteLine($"{DateTime.Now}: Прочитано {clients.Count} клиентов."); // протоколирование количества прочитанных клиентов
            Console.WriteLine($"Прочитано {clients.Count} клиентов.");


            // Чтение таблицы бронирования
            Worksheet bookingsSheet = workbook.Worksheets["Бронирование"]; // Получение листа "Бронирование"
            if (clientsSheet == null)
            {
                protocolWriter.WriteLine($"{DateTime.Now}: Ошибка: Таблица 'Бронирование' не найдена.");
                return; // Выход из функции, если лист не найден
            }
            for (int row = 1; row < bookingsSheet.Cells.MaxDataRow + 1; row++)
            {
                try
                {
                    Booking booking = new Booking // Создание нового бронирования
                    {
                        BookingCode = bookingsSheet.Cells[row, 0].IntValue, // Чтение кода бронирования
                        ClientCode = bookingsSheet.Cells[row, 1].IntValue, // Чтение кода клиента
                        RoomCode = bookingsSheet.Cells[row, 2].IntValue, // Чтение кода номера
                        BookingDate = bookingsSheet.Cells[row, 3].DateTimeValue, // Чтение даты бронирования
                        CheckInDate = bookingsSheet.Cells[row, 4].DateTimeValue, // Чтение даты заезда
                        CheckOutDate = bookingsSheet.Cells[row, 5].DateTimeValue // Чтение даты выезда
                    };
                    bookings.Add(booking); // Добавление бронирования в список
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при чтении данных из строки {row}: {ex.Message}");
                }
            }
            protocolWriter.WriteLine($"{DateTime.Now}: Прочитано {bookings.Count} бронирований."); // протоколирование количества прочитанных бронирований
            Console.WriteLine($"Прочитано {bookings.Count} бронирований.");


            // Чтение таблицы номера
            Worksheet roomsSheet = workbook.Worksheets["Номера"]; // Получение листа "Номера"

            if (clientsSheet == null)
            {
                protocolWriter.WriteLine($"{DateTime.Now}: Ошибка: Таблица 'Номера' не найдена.");
                return; // Выход из функции, если лист не найден
            }

            for (int row = 1; row < roomsSheet.Cells.MaxDataRow + 1; row++)
            {
                try
                {
                    Room room = new Room() // Создание нового номера
                    {
                        RoomCode = roomsSheet.Cells[row, 0].IntValue, // Чтение кода номера
                        Floor = roomsSheet.Cells[row, 1].IntValue, // Чтение этажа
                        Capacity = roomsSheet.Cells[row, 2].IntValue, // Чтение числа мест
                        Price = roomsSheet.Cells[row, 3].IntValue, // Чтение стоимости за сутки
                        Category = roomsSheet.Cells[row, 4].IntValue // Чтение категории гостиницы
                    };
                    rooms.Add(room); // Добавление номера в список
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при чтении данных из строки {row}: {ex.Message}");
                }
            }
            protocolWriter.WriteLine($"{DateTime.Now}: Прочитано {rooms.Count} номеров."); // протоколирование количества прочитанных номеров
            Console.WriteLine($"Прочитано {rooms.Count} номеров.\n");
        }



        // метод для просмотра базы данных
        public void ViewingDatabase(StreamWriter protocolWriter)
        {
            Console.WriteLine("Выберите номер таблицы БД, которую хотите просмотреть:\n1. Клиенты\n2. Бронирования\n3. Номера");
            int tableType;

            if (int.TryParse(Console.ReadLine(), out tableType))
            {
                switch (tableType)
                {
                    case 1:
                        Console.WriteLine("Таблица 'Клиенты':");
                        foreach (var client in clients)
                        {
                            Console.WriteLine(client.ToString());
                        }
                        break;

                    case 2:
                        Console.WriteLine("Таблица 'Бронирование':");
                        foreach (var booking in bookings)
                        {
                            Console.WriteLine(booking.ToString());
                        }
                        break;

                    case 3:
                        Console.WriteLine("Таблица 'Номера':");
                        foreach (var room in rooms)
                        {
                            Console.WriteLine(room.ToString());
                        }
                        break;

                    default:
                        Console.WriteLine("Неверный тип данных. Пожалуйста, используйте '1', '2' или '3'.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ошибка: Неверный формат ввода. Необходимо ввести число от 1 до 3.");
            }
            protocolWriter.WriteLine($"{DateTime.Now}: Просмотр базы данных."); // протоколирование действия просмотра базы данных
        }



        // Метод для удаления элемента по ключу
        public void DeleteElement(StreamWriter protocolWriter)
        {
            Console.WriteLine("Выберите номер таблицы, из которой хотите удалить элемент:\n1. Клиенты\n2. Бронирования\n3. Номера");
            string tableChoice = Console.ReadLine(); //  хранит выбор таблицы
            int codeToDelete; // хранит код для удаления

            switch (tableChoice)
            {
                case "1": // Удаление клиента
                    Console.WriteLine("Введите код клиента для удаления:");
                    if (int.TryParse(Console.ReadLine(), out codeToDelete))
                    {
                        var clientToDelete = clients.FirstOrDefault(c => c.ClientCode == codeToDelete);
                        if (clientToDelete != null)
                        {
                            clients.Remove(clientToDelete); // Удаление клиента из списка
                            protocolWriter.WriteLine($"{DateTime.Now}: Удален клиент с кодом {codeToDelete}."); // протоколирование удаления
                            Console.WriteLine("Клиент удален."); // Подтверждение удаления

                            // Удаление клиента из Excel
                            Worksheet clientsSheet = workbook.Worksheets["Клиенты"];
                            for (int row = 1; row <= clientsSheet.Cells.MaxDataRow; row++)
                            {
                                if (clientsSheet.Cells[row, 0].IntValue == codeToDelete)
                                {
                                    clientsSheet.Cells.DeleteRow(row); // Удаление строки с клиентом
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Клиент не найден."); // Сообщение, если клиент не найден
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный код клиента."); // Сообщение об ошибке ввода
                    }
                    break;

                case "2": // Удаление бронирования
                    Console.WriteLine("Введите код бронирования для удаления:");
                    if (int.TryParse(Console.ReadLine(), out codeToDelete))
                    {
                        var bookingToDelete = bookings.FirstOrDefault(b => b.BookingCode == codeToDelete);
                        if (bookingToDelete != null)
                        {
                            bookings.Remove(bookingToDelete); // Удаление бронирования из списка
                            protocolWriter.WriteLine($"{DateTime.Now}: Удалено бронирование с кодом {codeToDelete}."); // протоколирование удаления
                            Console.WriteLine("Бронирование удалено.");

                            // Удаление бронирования из Excel
                            Worksheet bookingsSheet = workbook.Worksheets["Бронирование"];
                            for (int row = 1; row <= bookingsSheet.Cells.MaxDataRow; row++)
                            {
                                if (bookingsSheet.Cells[row, 0].IntValue == codeToDelete)
                                {
                                    bookingsSheet.Cells.DeleteRow(row); // Удаление строки с бронированием
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Бронирование не найдено."); // Сообщение, если бронирование не найдено
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный код бронирования."); // Сообщение об ошибке ввода
                    }
                    break;

                case "3": // Удаление номера
                    Console.WriteLine("Введите код номера для удаления:");
                    if (int.TryParse(Console.ReadLine(), out codeToDelete))
                    {
                        var roomToDelete = rooms.FirstOrDefault(r => r.RoomCode == codeToDelete);
                        if (roomToDelete != null)
                        {
                            rooms.Remove(roomToDelete); // Удаление номера из списка
                            protocolWriter.WriteLine($"{DateTime.Now}: Удален номер с кодом {codeToDelete}."); // протоколирование удаления
                            Console.WriteLine("Номер удален.");

                            // Удаление номера из Excel
                            Worksheet roomsSheet = workbook.Worksheets["Номера"];
                            for (int row = 1; row <= roomsSheet.Cells.MaxDataRow; row++)
                            {
                                if (roomsSheet.Cells[row, 0].IntValue == codeToDelete)
                                {
                                    roomsSheet.Cells.DeleteRow(row); // Удаление строки с номером
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Номер не найден."); // Сообщение, если номер не найден
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный код номера."); // Сообщение об ошибке ввода
                    }
                    break;

                default:
                    Console.WriteLine("Неверный выбор таблицы."); // Сообщение об ошибке выбора таблицы
                    break;
            }

            // Сохранение изменений в Excel файл
            workbook.Save(filePath);
        }

        // метод для корректировки элемента
        public void AdjustingAnElement(StreamWriter protocolWriter)
        {
            Console.WriteLine("\nВыберите таблицу, в которой хотите корректировать элемент:\n1. Клиенты\n2. Бронирования\n3. Номера");
            string tableChoice = Console.ReadLine(); //  хранит выбор таблицы

            int codeToEdit; // хранит код для корректировки
            switch (tableChoice)
            {
                case "1":
                    Console.WriteLine("Введите код клиента для корректировки:");
                    if (int.TryParse(Console.ReadLine(), out codeToEdit))
                    {
                        var clientToEdit = clients.FirstOrDefault(c => c.ClientCode == codeToEdit);
                        if (clientToEdit != null)
                        {
                            Console.Write("Введите новую фамилию клиента (если она не поменялась, введите старую): ");
                            clientToEdit.LastName = Console.ReadLine();
                            Console.Write("Введите новое имя клиента: ");
                            clientToEdit.Name = Console.ReadLine();
                            Console.Write("Введите новое отчество клиента: ");
                            clientToEdit.Patronymic = Console.ReadLine();
                            Console.Write("Введите новый адрес клиента: ");
                            clientToEdit.Address = Console.ReadLine();

                            protocolWriter.WriteLine($"{DateTime.Now}: Изменен клиент с кодом {codeToEdit}."); // протоколирование изменения
                            Console.WriteLine("Клиент обновлен.");

                            // Обновление клиента в Excel
                            try
                            {
                                Worksheet clientsSheet = workbook.Worksheets["Клиенты"]; 

                                // Поиск строки с помощью цикла 
                                for (int row = 1; row <= clientsSheet.Cells.MaxDataRow; row++) // Начинаем с 1, предполагая заголовок в 0-й строке
                                {
                                    if (clientsSheet.Cells[row, 0].IntValue == codeToEdit)
                                    {
                                        clientsSheet.Cells[row, 1].PutValue(clientToEdit.LastName);
                                        clientsSheet.Cells[row, 2].PutValue(clientToEdit.Name);
                                        clientsSheet.Cells[row, 3].PutValue(clientToEdit.Patronymic);
                                        clientsSheet.Cells[row, 4].PutValue(clientToEdit.Address);
                                        workbook.Save(filePath);
                                        break; // Выходим из цикла после обновления
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ошибка при обновлении данных в Excel: {ex.Message}");
                                protocolWriter.WriteLine($"{DateTime.Now}: Ошибка при обновлении данных в Excel: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Клиент не найден.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный код клиента.");
                    }
                    break;
                case "2":
                    Console.WriteLine("\nВведите код бронирования для корректировки:");
                    if (int.TryParse(Console.ReadLine(), out codeToEdit))
                    {
                        var bookingToEdit = bookings.FirstOrDefault(b => b.BookingCode == codeToEdit);
                        if (bookingToEdit != null)
                        {
                            Console.WriteLine("Введите новый код клиента");
                            bookingToEdit.ClientCode = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите новый код комнаты");
                            bookingToEdit.RoomCode = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите новую дату бронирования в формате дд.мм.гггг");
                            bookingToEdit.BookingDate = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Введите новую дату заезда в формате дд.мм.гггг");
                            bookingToEdit.CheckInDate = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Введите новую дату выезда в формате дд.мм.гггг");
                            bookingToEdit.CheckOutDate = DateTime.Parse(Console.ReadLine());

                            protocolWriter.WriteLine($"{DateTime.Now}: Измено бронирование с кодом {codeToEdit}."); // протоколирование изменения
                            Console.WriteLine("Бронирование обновлено.");

                            // Обновление бронирования в Excel
                            try
                            {
                                Worksheet bookingSheet = workbook.Worksheets["Бронирование"];
                                

                                // Поиск строки с помощью цикла 
                                for (int row = 1; row <= bookingSheet.Cells.MaxDataRow; row++) // Начинаем с 1, предполагая заголовок в 0-й строке
                                {
                                    if (bookingSheet.Cells[row, 0].IntValue == codeToEdit)
                                    {
                                        bookingSheet.Cells[row, 1].PutValue(bookingToEdit.ClientCode);
                                        bookingSheet.Cells[row, 2].PutValue(bookingToEdit.RoomCode);
                                        bookingSheet.Cells[row, 3].PutValue(bookingToEdit.BookingDate);
                                        bookingSheet.Cells[row, 4].PutValue(bookingToEdit.CheckInDate);
                                        bookingSheet.Cells[row, 5].PutValue(bookingToEdit.CheckOutDate);
                                        workbook.Save(filePath);
                                        break; // Выходим из цикла после обновления
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ошибка при обновлении данных в Excel: {ex.Message}");
                                protocolWriter.WriteLine($"{DateTime.Now}: Ошибка при обновлении данных в Excel: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Бронирование не найдено.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный код бронирования.");
                    }
                    break;

                case "3":
                    Console.WriteLine("\nВведите код номера для корректировки:");
                    if (int.TryParse(Console.ReadLine(), out codeToEdit))
                    {
                        var roomToEdit = rooms.FirstOrDefault(r => r.RoomCode == codeToEdit);
                        if (roomToEdit != null)
                        {
                            Console.WriteLine("Введите новый этаж");
                            roomToEdit.Floor = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите новый число мест");
                            roomToEdit.Capacity = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите новую цену");
                            roomToEdit.Price = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите новую категорию гостиницы");
                            roomToEdit.Category = int.Parse(Console.ReadLine());

                            protocolWriter.WriteLine($"{DateTime.Now}: Измен номер с кодом {codeToEdit}."); // протоколирование изменения
                            Console.WriteLine("Номер обновлен.");

                            // Обновление номера в Excel
                            try
                            {
                                Worksheet roomSheet = workbook.Worksheets["Номера"];


                                // Поиск строки с помощью цикла 
                                for (int row = 1; row <= roomSheet.Cells.MaxDataRow; row++) // Начинаем с 1, предполагая заголовок в 0-й строке
                                {
                                    if (roomSheet.Cells[row, 0].IntValue == codeToEdit)
                                    {
                                        roomSheet.Cells[row, 1].PutValue(roomToEdit.Floor);
                                        roomSheet.Cells[row, 2].PutValue(roomToEdit.Capacity);
                                        roomSheet.Cells[row, 3].PutValue(roomToEdit.Price);
                                        roomSheet.Cells[row, 4].PutValue(roomToEdit.Category);
                                        workbook.Save(filePath);
                                        break; // Выходим из цикла после обновления
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ошибка при обновлении данных в Excel: {ex.Message}");
                                protocolWriter.WriteLine($"{DateTime.Now}: Ошибка при обновлении данных в Excel: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Номер не найден.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный код номера.");
                    }
                    break;
                default:
                    Console.WriteLine("Неверный выбор таблицы.");
                    break ;
            }
        }


        // метод для добавления элементов
        public void AddElement(StreamWriter protocolWriter)
        {
            Console.WriteLine("Выберите таблицу, в которую хотите добавить элемент:\n1. Клиенты\n2. Бронирования\n3. Номера");
            string tableChoice = Console.ReadLine(); //  хранит выбор таблицы

            switch (tableChoice)
            {
                case "1":
                    Client newClient = null;
                    int clientCode; // будет хранить код нового клиента

                    do
                    {
                        Console.Write("Введите код клиента (он должен быть уникальным): ");
                        if (int.TryParse(Console.ReadLine(), out clientCode))
                        {
                            // Проверка на уникальность кода
                            if (clients.Any(c => c.ClientCode == clientCode))
                            {
                                Console.WriteLine("Ошибка: Клиент с таким кодом уже существует.");
                                protocolWriter.WriteLine($"{DateTime.Now}: Попытка создать запись с существующим уникальным кодом");
                            }
                            else
                            {
                                newClient = new Client { ClientCode = clientCode };
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Некорректный формат кода клиента.");
                        }
                    } 
                    while (newClient == null);

                    try
                    {
                        // Ввод остальных данных о клиенте
                        Console.Write("Введите фамилию клиента: ");
                        newClient.LastName = Console.ReadLine();
                        Console.Write("Введите имя клиента: ");
                        newClient.Name = Console.ReadLine();
                        Console.Write("Введите отчество клиента: ");
                        newClient.Patronymic = Console.ReadLine();
                        Console.Write("Введите адрес клиента: ");
                        newClient.Address = Console.ReadLine();

                        clients.Add(newClient);

                        // Добавление в Excel (изменений не требуется)
                        Worksheet clientsSheet = workbook.Worksheets["Клиенты"];
                        int nextRow = clientsSheet.Cells.MaxDataRow + 1;
                        clientsSheet.Cells[nextRow, 0].PutValue(newClient.ClientCode);
                        clientsSheet.Cells[nextRow, 1].PutValue(newClient.LastName);
                        clientsSheet.Cells[nextRow, 2].PutValue(newClient.Name);
                        clientsSheet.Cells[nextRow, 3].PutValue(newClient.Patronymic);
                        clientsSheet.Cells[nextRow, 4].PutValue(newClient.Address);
                        workbook.Save(filePath); // Сохранение изменений в файле

                        protocolWriter.WriteLine($"{DateTime.Now}: Добавлен клиент с кодом {newClient.ClientCode}.");
                        Console.WriteLine("Клиент добавлен.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                    break;

                case "2":
                    // Создание нового объекта Booking
                    Booking newBooking = null;
                    int bookingCode;

                    do
                    {
                        Console.Write("Введите код бронирования (он должен быть уникальным): ");
                        if (int.TryParse(Console.ReadLine(), out bookingCode))
                        {
                            if (bookings.Any(b => b.BookingCode == bookingCode))
                            {
                                Console.WriteLine("Ошибка: Бронирование с таким кодом уже существует.");
                                protocolWriter.WriteLine($"{DateTime.Now}: Попытка создать запись с существующим уникальным кодом");
                            }
                            else
                            {
                                newBooking = new Booking { BookingCode = bookingCode };
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Некорректный формат кода бронирования.");
                        }
                    } 
                    while (newBooking == null);

                    try
                    {
                        // Ввод данных о новой записи
                        Console.WriteLine("Введите код клиента");
                        newBooking.ClientCode = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите код комнаты");
                        newBooking.RoomCode = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите дату бронирования в формате дд.мм.гггг");
                        newBooking.BookingDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Введите дату заезда в формате дд.мм.гггг");
                        newBooking.CheckInDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Введите дату выезда в формате дд.мм.гггг");
                        newBooking.CheckOutDate = DateTime.Parse(Console.ReadLine());
                        bookings.Add(newBooking);

                        // Добавление бронирования в Excel
                        Worksheet bookingsSheet = workbook.Worksheets["Бронирование"];   // Получение листа "Бронирование" из книги Excel
                        int nextRow = bookingsSheet.Cells.MaxDataRow + 1;
                        bookingsSheet.Cells[nextRow, 0].PutValue(newBooking.BookingCode);
                        bookingsSheet.Cells[nextRow, 1].PutValue(newBooking.ClientCode);
                        bookingsSheet.Cells[nextRow, 2].PutValue(newBooking.RoomCode);
                        bookingsSheet.Cells[nextRow, 3].PutValue(newBooking.BookingDate.ToShortDateString());
                        bookingsSheet.Cells[nextRow, 4].PutValue(newBooking.CheckInDate.ToShortDateString());
                        bookingsSheet.Cells[nextRow, 5].PutValue(newBooking.CheckOutDate.ToShortDateString());
                        

                        protocolWriter.WriteLine($"{DateTime.Now}: Добавлено бронирование с кодом {newBooking.BookingCode}."); // протоколирование добавления
                        Console.WriteLine("Бронирование добавлено.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка: Некорректный формат ввода.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                    break;

                case "3":
                    // Создание нового объекта Room
                    Room newRoom = null;
                    int roomCode;

                    do
                    {
                        Console.Write("Введите код номера (он должен быть уникальным): ");
                        if (int.TryParse(Console.ReadLine(), out roomCode))
                        {
                            if (rooms.Any(r => r.RoomCode == roomCode))
                            {
                                protocolWriter.WriteLine($"{DateTime.Now}: Попытка создать запись с существующим уникальным кодом");
                                Console.WriteLine("Ошибка: Номер с таким кодом уже существует.");
                            }
                            else
                            {
                                newRoom = new Room { RoomCode = roomCode };
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: Некорректный формат кода номера.");
                        }
                    }
                    while (newRoom == null);

                    try
                    {
                        // Ввод данных о новой записи
                        Console.WriteLine("Введите этаж");
                        newRoom.Floor = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите число мест");
                        newRoom.Capacity = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите цену");
                        newRoom.Price = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите категорию гостиницы");
                        newRoom.Category = int.Parse(Console.ReadLine());

                        rooms.Add(newRoom); // добавлеие в список

                        // Добавление номера в Excel
                        Worksheet roomsSheet = workbook.Worksheets["Номера"];   // Получение листа "Номера" из книги Excel
                        int nextRow = roomsSheet.Cells.MaxDataRow + 1;

                        roomsSheet.Cells[nextRow, 0].PutValue(newRoom.RoomCode);
                        roomsSheet.Cells[nextRow, 1].PutValue(newRoom.Floor);
                        roomsSheet.Cells[nextRow, 2].PutValue(newRoom.Capacity);
                        roomsSheet.Cells[nextRow, 3].PutValue(newRoom.Price);
                        roomsSheet.Cells[nextRow, 4].PutValue(newRoom.Category);

                        protocolWriter.WriteLine($"{DateTime.Now}: Добавлен номер с кодом {newRoom.RoomCode}."); // протоколирование добавления
                        Console.WriteLine("Номер добавлен.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка: Некорректный формат ввода.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                    break;  
            }
            // Сохранение изменений в Excel файл
            workbook.Save(filePath);
        }


        // метод для выполнения первого запроса
        public void Zapros1(StreamWriter protocolWriter, int category)
        {
            // проверка, чтобы таблица Номера не была пустой
            if (rooms == null || rooms.Count()==0)
            {
                Console.WriteLine("Таблица 'Номера' пуста. (Возможно вы не выполнили 1 пункт)");
                return;
            }


            // Проверяем, существует ли хотя бы один номер с указанной категорией
            if (!rooms.Any(room => room.Category == category))
            {
                Console.WriteLine($"Нет номеров с данной категорией категорией .");
                protocolWriter.WriteLine($"{DateTime.Now}: Ошибка: попытка запроса 1  для несуществующей категории гостиницы.");
                return;
            }

            // выполняем запрос
            var averagePrice = rooms
                .Where(room => room.Category == category) // Фильтруем номера по категории
                .Select(room => room.Price) // Берем только цены
                .DefaultIfEmpty(0) // Если нет номеров, возвращаем 0
                .Average(); // Вычисляем среднее значение

            var resault = Math.Round(averagePrice, 2); // округляем до сотых
            Console.WriteLine($"Средняя цена номеров гостиницы {category} категории составляет: {resault} рублей");
            protocolWriter.WriteLine($"{DateTime.Now}: Выполнен запрос 1."); // протоколирование запроса
        }



        // метод для выполнения второго запроса
        public void Zapros2(StreamWriter protocolWriter)
        {
            // Форматируем дату для сравнения
            var specificDate = new DateTime(2019, 07, 05);

            if (clients == null || clients.Count() == 0)
            {
                Console.WriteLine("Таблица 'Клиенты' пуста. (Возможно вы не выполнили 1 пункт)");
                return;
            }
            if (bookings == null || bookings.Count() == 0)
            {
                Console.WriteLine("Таблица 'Бронирование' пуста. (Возможно вы не выполнили 1 пункт)");
                return;
            }


            // проверим, существует ли хоть одна запись даты заезда 05.07.2019
            if (!bookings.Any(booking => booking.CheckInDate == specificDate))
            {
                Console.WriteLine("В таблице 'Бронирование' нет данной даты заезда");
                protocolWriter.WriteLine($"{DateTime.Now}: Ошибка в запросе 2. В таблице 'Бронирование' нет данной даты заезда");
                return;
            }


            // Получаем список клиентов, у которых дата заезда совпадает с заданной
            var clientsWithBookingOnDate = from booking in bookings
                                           where booking.CheckInDate == specificDate
                                           join client in clients on booking.ClientCode equals client.ClientCode
                                           select client;

            // Проверяем, есть ли клиенты с такой датой заезда
            if (!clientsWithBookingOnDate.Any())
            {
                Console.WriteLine("Нет клиентов с датой заезда 05.07.2019.");
                protocolWriter.WriteLine($"{DateTime.Now}: Ошибка в запросе 2. Нет клиентов с датой заезда 05.07.2019.");
                return;
            }

            // Выводим информацию о клиентах
            Console.WriteLine("Клиенты с датой заезда 05.07.2019:");
            foreach (var client in clientsWithBookingOnDate)
            {
                Console.WriteLine(client.ToString());
            }

            protocolWriter.WriteLine($"{DateTime.Now}: Выполнен запрос 2"); // протоколирование действия
        }



        // метод для выполнения 3 запроса
        public void Zapros3(StreamWriter protocolWriter)
        {
            var startDate = new DateTime(2019, 7, 1);
            var endDate = new DateTime(2019, 7, 15);

            if (clients == null || clients.Count() == 0)
            {
                Console.WriteLine("Таблица 'Клиенты' пуста. (Возможно вы не выполнили 1 пункт)");
                return;
            }
            if (bookings == null || bookings.Count() == 0)
            {
                Console.WriteLine("Таблица 'Бронирование' пуста. (Возможно вы не выполнили 1 пункт)");
                return;
            }
            if (rooms == null || rooms.Count() == 0)
            {
                Console.WriteLine("Таблица 'Номера' пуста. (Возможно вы не выполнили 1 пункт)");
                return;
            }

            // Получаем номера 3 категории
            var categoryThreeRooms = rooms
                .Where(room => room.Category == 3)
                .Select(room => room.RoomCode)
                .ToList();

            // Проверка на наличие номеров 3 категории
            if (categoryThreeRooms.Count == 0)
            {
                Console.WriteLine("Нет гостиниц 3 категории.");
                protocolWriter.WriteLine($"{DateTime.Now}: Нет записей с гостиницами 3 категории"); // протоколирование действия
                return; 
            }

            // Получаем бронирования, которые соответствуют заданным критериям
            var filteredBookings = bookings
                .Where(booking => categoryThreeRooms
                .Contains(booking.RoomCode) &&
                booking.CheckInDate >= startDate && booking.CheckInDate <= endDate)
                .ToList();

            // Проверка на наличие бронирований
            if (filteredBookings.Count == 0)
            {
                Console.WriteLine("Нет бронирований в указанный период для гостиниц 3 категории.");
                protocolWriter.WriteLine($"{DateTime.Now}: Нет бронирований в указанный период для гостиниц 3 категории."); // протоколирование действия
                return;
            }

            // Получаем уникальный список клиентов по кодам
            var clientCodes = filteredBookings.Select(booking => booking.ClientCode).Distinct();

            // Проверка на наличие клиентов
            if (!clientCodes.Any())
            {
                Console.WriteLine("Нет клиентов, заехавших в указанный период.");
                protocolWriter.WriteLine($"{DateTime.Now}: Нет клиентов, заехавших в указанный период."); // протоколирование действия
                return; // Выход из метода, если нет клиентов
            }

            // Выводим информацию о клиентах
            Console.WriteLine("перечень клиентов, которые проживали в гостинице 3 категории с 01.07.2019 по 15.07.2019:\n");
            foreach (var clientCode in clientCodes)
            {
                var client = clients.FirstOrDefault(c => c.ClientCode == clientCode);
                if (client != null)
                {
                    Console.WriteLine(client.ToString());
                }
            }
            protocolWriter.WriteLine($"{DateTime.Now}: Выполнен запрос 3"); // протоколирование действия
        }



        // метод для выполнения запроса 4
        public void Zapros4(StreamWriter protocolWriter)
        {
            var limitedDate = new DateTime(2019, 6, 15);

            if (clients == null || clients.Count() == 0)
            {
                Console.WriteLine("Таблица 'Клиенты' пуста. (Возможно вы не выполнили 1 пункт)");
                return;
            }
            if (bookings == null || bookings.Count() == 0)
            {
                Console.WriteLine("Таблица 'Бронирование' пуста. (Возможно вы не выполнили 1 пункт)");
                return;
            }
            if (rooms == null || rooms.Count() == 0)
            {
                Console.WriteLine("Таблица 'Номера' пуста. (Возможно вы не выполнили 1 пункт)");
                return;
            }

            // получение номеров с категорией гостиницы 5 
            var categoryFiveRooms = rooms
                .Where(room => room.Category == 5)
                .Select(room => room.RoomCode) // Получаем только RoomCode
                .ToList();

            // Проверка на наличие номеров 3 категории
            if (categoryFiveRooms.Count == 0)
            {
                Console.WriteLine("Нет гостиниц 5 категории.");
                protocolWriter.WriteLine($"{DateTime.Now}: Нет записей с гостиницами 5 категории"); // протоколирование действия
                return;
            }

            // отбираем клиентов из Уфы
            var clientsUfa = clients
                .Where(client => client.Address == "г. Уфа")
                .Select(client => client.ClientCode)
                .ToList();

            // Проверка на наличие клиентов из г. Уфа
            if (clientsUfa.Count == 0)
            {
                Console.WriteLine("Нет клиентов из г. Уфа.");
                protocolWriter.WriteLine($"{DateTime.Now}: Нет клиентов из г. Уфа."); // протоколирование действия
                return;
            }

            // Получаем бронирования, которые соответствуют заданным критериям
            var filteredBookings = bookings
                .Where(booking => categoryFiveRooms
                .Contains(booking.RoomCode) && clientsUfa.Contains(booking.ClientCode) && booking.BookingDate <= limitedDate)
                .ToList();

            // Проверка на наличие бронирований
            if (filteredBookings.Count == 0)
            {
                Console.WriteLine("Нет бронирований в указанный период для 5 категории.");
                protocolWriter.WriteLine($"{DateTime.Now}: Нет бронирований в указанный период для 5 категории."); // протоколирование действия
                return ;
            }

            // Рассчитываем общую стоимость
            int totalCost = 0;
            foreach (var booking in filteredBookings)
            {
                var room = rooms.FirstOrDefault(r => r.RoomCode == booking.RoomCode);
                if (room != null)
                {
                    totalCost += room.Price; // Добавляем стоимость за сутки
                }
            }

            Console.WriteLine($"Общая стоимость: {totalCost} руб.");
            protocolWriter.WriteLine($"{DateTime.Now}: Выполнен запрос 3");
        }
    }
} 
