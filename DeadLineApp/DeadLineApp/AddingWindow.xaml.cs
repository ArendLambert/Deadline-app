using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DeadLineApp
{
    /// <summary>
    /// Логика взаимодействия для AddingWindow.xaml
    /// </summary>
    public partial class AddingWindow : Window
    {
        public AddingWindow()
        {
            InitializeComponent();
        }

        // Позволяет вводить только цифры в соответсвующее поле
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Запись нового дела в файл
        private void OkayButton_Click(object sender, RoutedEventArgs e)
        {
            if (AboutDeal.Text == "" || AboutDeal.Text == "Deal") return;
            if (PriorityData.Text == "" || Int32.Parse(PriorityData.Text) < 0) PriorityData.Text = "0";
            if (DeadLineData.Text == "") DeadLineData.Text = "Сейчас";

            using (StreamWriter writer = new StreamWriter(@"AllDeals.txt", true))
            {
                writer.WriteLineAsync($"{AboutDeal.Text};{PriorityData.Text};{DeadLineData.Text}");
            }
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.Update();
            Close();
        }

        private void PriorityDataSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            PriorityData.Text = ((int)PriorityDataSlider.Value).ToString();
        }
    }
}
