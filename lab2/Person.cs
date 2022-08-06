using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
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
        public virtual bool Equals(Person obj)
        {
            if (obj.name == name && obj.surname == surname && obj.birthday == birthday) return true;
            else
                return false;
        }
        public static bool operator ==(Person p1, Person p2)
        {
            if (p1.Equals(p2)) return true;
            else
                return false;
        }
        public static bool operator !=(Person p1, Person p2)
        {
            if (!p1.Equals(p2)) return true;
            else
                return false;
        }
        public object DeepCopy()
        {
            Person p = new Person(Name = this.Name, Surname = this.Surname, Birthday = this.Birthday);
            return p;
        }
        public override int GetHashCode() 
        {
            return name.GetHashCode() + surname.GetHashCode() + birthday.GetHashCode();
        }
    }
}
