using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_CSharp_Level2_Lesson_6
{
    /// <summary>
    /// Базовый класс работников 
    /// </summary>
    public class Employee : IComparable<Employee>, INotifyPropertyChanged
    {
        double rate = 0;
        string name;
        int age;
        int salary;

        public event PropertyChangedEventHandler PropertyChanged;

        public Employee(string name, int age, int salary, double rate)
        {
            this.name = name;
            this.age = age;
            this.salary = salary;
            this.rate = rate;
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.name)));
            }
        }

        public int Age
        {
            get => age;
            set
            {
                age = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.age)));
            }
        }

        public int Salary
        {
            get => salary;
            set
            {
                salary = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.salary)));
            }
        }

        public double Rate
        {
            get => rate;
            set
            {
                rate = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Rate)));
            }
        }

        /// <summary>
        /// Данные о работнике
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.Name}, {this.Age} лет,  {this.Salary} р. ";
        }

        /// <summary>
        /// Сравнение двух работников
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(Employee obj) => obj.Salary > this.Salary ? -1 : 1;

        public double PaymentInManth()
        {
            Salary = (int)Rate;
            return Salary;
        }
    }
}
