using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Person
    {
        string name;
        string surname;
        DateTime birthday;
        public Person(string nameValue, string surnameValue, DateTime birthdayValue)
        {
            name = nameValue;
            surname = surnameValue;
            birthday = birthdayValue;
        }
        public Person() : this("Иван", "Иванов", new DateTime(2000, 1, 1))
        {

        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                //какие-то проверки (буква заглавная или нет)
                name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }
        public int Year
        {
            get
            {
                return birthday.Year;
            }
            set
            {
                birthday = new DateTime(value, Birthday.Month, Birthday.Day);
            }
        }
        public override string ToString()
        {
            return Name + " " + Surname + " " + Birthday.ToShortDateString();
        }
        public virtual string ToShortString()
        {
            return Name + " " + Surname;
        }
    }
}