using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace DeadLineApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string dealInfo = null;
        public int priorityInfo = 0;
        public string deadLineInfo = null;

        private List<string[]> deals;

        public MainWindow()
        {
            InitializeComponent();
            Update();
        }

        public void Update()
        {
            deals = GetDeals(@"AllDeals.txt");
            AddDeals(deals);
        }

        /// <summary>
        /// Получение данных из файла
        /// </summary>
        /// <param name="path">Путь файла</param>
        /// <returns>Список содержащий нераспределенные дела из файла</returns>
        private List<string[]> GetDeals(string path)
        {
            deals = new List<string[]>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    deals.Add(line.Split(new char[] { ';' }));
                }
            }
            return deals;
        }

        // Добавить все дела из файла
        private void AddDeals(List<string[]> deals)
        {
            ListDeals.Items.Clear();
            for (int i = 0; i < deals.Count; i++)
            {
                Deal deal = new Deal();
                ListDeals.Items.Add(deal);
                deal.DeadLine = deals[i][2];
                deal.DealText = deals[i][0];
                deal.Priority = Int32.Parse(deals[i][1]);
            }
        }

        private void AddDealButton_Click(object sender, RoutedEventArgs e)
        {
            AddingWindow window = new AddingWindow();
            window.Show();
        }

        private void DeleteDealButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListDeals.SelectedItem != null)
            {
                string stringToRemove = "";
                Deal deal = ListDeals.SelectedItem as Deal;
                if (deal != null)
                {
                    stringToRemove = $"{deal.DealText};{deal.Priority};{deal.DeadLine}";
                }
                List<string> lines = new List<string>(File.ReadLines(@"AllDeals.txt"));
                lines.Remove(stringToRemove);
                File.WriteAllLines(@"AllDeals.txt", lines);
                ListDeals.Items.Remove(ListDeals.SelectedItem);
            }
        }

        private void MinSortButton_Click(object sender, RoutedEventArgs e)
        {
            ListDeals.Items.Clear();
            List<string[]> dealsTop = new List<string[]>();
            List<string[]> dealsMiddle = new List<string[]>();
            List<string[]> dealsBottom = new List<string[]>();
            List<string[]> dealsNever = new List<string[]>();
            for (int i = 0; i < deals.Count; i++)
            {
                ListDeals.Items.Clear();
                if (Int32.Parse(deals[i][1]) == 3)
                {
                    dealsTop.Add(deals[i]);
                }
                else if (Int32.Parse(deals[i][1]) == 2)
                {
                    dealsMiddle.Add(deals[i]);
                }
                else if (Int32.Parse(deals[i][1]) == 1)
                {
                    dealsBottom.Add(deals[i]);
                }
                else if (Int32.Parse(deals[i][1]) == 0)
                {
                    dealsNever.Add(deals[i]);
                }
            }
            addOneDeal(dealsNever);
            addOneDeal(dealsBottom);
            addOneDeal(dealsMiddle);
            addOneDeal(dealsTop);
        }

        private void MaxSortButton_Click(object sender, RoutedEventArgs e)
        {
            ListDeals.Items.Clear();
            List<string[]> dealsTop = new List<string[]>();
            List<string[]> dealsMiddle = new List<string[]>();
            List<string[]> dealsBottom = new List<string[]>();
            List<string[]> dealsNever = new List<string[]>();
            for (int i = 0; i < deals.Count; i++)
            {
                ListDeals.Items.Clear();
                if (Int32.Parse(deals[i][1]) == 3)
                {
                    dealsTop.Add(deals[i]);
                }
                else if (Int32.Parse(deals[i][1]) == 2)
                {
                    dealsMiddle.Add(deals[i]);
                }
                else if (Int32.Parse(deals[i][1]) == 1)
                {
                    dealsBottom.Add(deals[i]);
                }
                else if (Int32.Parse(deals[i][1]) == 0)
                {
                    dealsNever.Add(deals[i]);
                }
            }
            addOneDeal(dealsTop);
            addOneDeal(dealsMiddle);
            addOneDeal(dealsBottom);
            addOneDeal(dealsNever);
        }

        private void ClearSortButton_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        // Добавить одно дело из файла
        private void addOneDeal(List<string[]> dealsNow)
        {
            for (int i = 0; i < dealsNow.Count; i++)
            {
                Deal deal = new Deal();
                ListDeals.Items.Add(deal);
                deal.DeadLine = dealsNow[i][2];
                deal.DealText = dealsNow[i][0];
                deal.Priority = Int32.Parse(dealsNow[i][1]);
            }
        }

        private void MainCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = MainCalendar.SelectedDate;

            ListDeals.Items.Clear();
            List<string[]> deals = GetDeals(@"AllDeals.txt");
            for (int i = 0; i < deals.Count; i++)
            {
                if (deals[i][2].Contains(selectedDate.Value.Date.ToShortDateString()))
                {
                    Deal deal = new Deal();
                    ListDeals.Items.Add(deal);
                    deal.DeadLine = deals[i][2];
                    deal.DealText = deals[i][0];
                    deal.Priority = Int32.Parse(deals[i][1]);
                }
            }
        }

        private void SearchTextBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        // Поиск по содержанию
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListDeals.Items.Clear();
            List<string[]> deals = GetDeals(@"AllDeals.txt");
            for (int i = 0; i < deals.Count; i++)
            {
                if (deals[i][0].Contains(SearchTextBox.Text))
                {
                    Deal deal = new Deal();
                    ListDeals.Items.Add(deal);
                    deal.DeadLine = deals[i][2];
                    deal.DealText = deals[i][0];
                    deal.Priority = Int32.Parse(deals[i][1]);
                }
            }
        }

        // Очищение поля ввода поиска от приглашения написать что-либо
        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = "";
        }
    }
}
