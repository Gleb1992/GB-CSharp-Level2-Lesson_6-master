using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GB_CSharp_Level2_Lesson_5
{
    /// <summary>
    /// Логика взаимодействия для WindowEmployee.xaml
    /// </summary>
    public partial class WindowEmployee : Window
    {
        Employee employee;
        Department department;
        ListView listView;
        Company company;

        public WindowEmployee(Employee employee, Department department, Company company, ListView listView)
        {
            InitializeComponent();
            this.employee = employee;
            this.department = department;
            this.listView = listView;
            this.company = company;

            dep.ItemsSource = company.Departments;
            dep.SelectedItem = department;
            tb_Name.Text = employee.Name;
            tb_Age.Text = employee.Age.ToString();
            tb_Salary.Text = employee.Salary.ToString();

            tb_Name.KeyUp += delegate 
            {
                employee.Name = tb_Name.Text;
            };
            tb_Age.KeyUp += delegate
            {
                employee.Age = int.Parse(tb_Age.Text);
            };
            tb_Salary.KeyUp += delegate
            {
                employee.Salary = int.Parse(tb_Salary.Text);
            };
            tb_Name.KeyDown += new KeyEventHandler(LetterTextBox_KeyDown);
            tb_Age.KeyDown += new KeyEventHandler(NumericTextBox_KeyDown);
            tb_Salary.KeyDown += new KeyEventHandler(NumericTextBox_KeyDown);
            this.Closed += delegate { listView.Items.Refresh(); };
            this.Topmost = true;
            this.Activate();
        }

        /// <summary>
        /// Изменить отдел дял сотркудника
        /// </summary>
        private void Dep_SelectChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((Department)dep.SelectedItem != department)
            {
                ((Department)dep.SelectedItem).Employees.Add((Employee)employee);
                department.Employees.Remove((Employee)employee);
                department = (Department)dep.SelectedItem;
            }
        }

        /// <summary>
        /// Пропускать символы кроме чисел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumericTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) && 
                e.Key != Key.Back || e.Key == Key.Space)
                e.Handled = true;
        }

        /// <summary>
        /// Пропускать символы кроме букв
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LetterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)))
                e.Handled = true;
        }


    }
}
