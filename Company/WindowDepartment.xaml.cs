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
    /// Логика взаимодействия для WindowDepartment.xaml
    /// </summary>
    public partial class WindowDepartment : Window
    {
        public WindowDepartment(Department department)
        {
            InitializeComponent();
            dep_Name.Text = department.Name;
            dep_Profit.Text = department.Profit.ToString();
            dep_Name.KeyUp += delegate  { department.Name = dep_Name.Text; };
            dep_Profit.KeyUp += delegate { department.Profit = Convert.ToInt64(dep_Profit.Text); };
            dep_Profit.KeyDown += new KeyEventHandler(NumericTextBox_KeyDown);
            this.Topmost = true;
            this.Activate();
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
    }
}
