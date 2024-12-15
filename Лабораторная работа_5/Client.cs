using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Лабораторная_работа_5
{
    // класс для представления клиента
    public class Client
    {
        private int clientCode;       // код клиента
        private string lastName;     // фамилия
        private string name;  // имя
        private string patronymic;  // отчество 
        private string address;   // место жительства 

        // Свойства для доступа к приватным полям
        public int ClientCode
        {
            get { return clientCode; }
            set { clientCode = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public Client(int clientCode, string lastName, string name, string patronymic, string address)
        {
            this.ClientCode = clientCode;
            this.LastName = lastName;
            this.Name = name;
            this.Address = address;
        }
        public Client() { }

        // переопределение метода ToString для удобного отображения информации о клиенте
        public override string ToString()
        {
            return $"код клиента: {ClientCode} ФИО:{LastName}, {Name}, {Patronymic}, Адрес: {Address}";
        }
    }
}
