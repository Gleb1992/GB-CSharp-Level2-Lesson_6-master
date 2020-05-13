using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_CSharp_Level2_Lesson_6
{
    public class Department: INotifyPropertyChanged
    {
        string name = "";
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        long profit = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public Department(string name, long profit)
        {
            Name = name;
            Profit = profit;
        }

        public string Name {
            get => name;
            set
            {
                name = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Name)));
            }
        }
        public long Profit
        {
            get => profit;
            set
            {
                profit = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Convert.ToString(this.Profit)));
            }
        }

        internal ObservableCollection<Employee> Employees { get => employees; set => employees = value; }
    }
}
