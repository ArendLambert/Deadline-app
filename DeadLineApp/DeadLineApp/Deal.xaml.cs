using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeadLineApp
{
    /// <summary>
    /// Логика взаимодействия для Deal.xaml
    /// </summary>
    public partial class Deal : UserControl
    {
        public Deal()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        public new int Priority
        {
            get => Int32.Parse((PriorityLevel.Content).ToString());           
            set => PriorityLevel.Content = value;
        }
        [Browsable(true)]
        public new string DeadLine
        {
            get => (DeadLineValue.Content).ToString();
            set => DeadLineValue.Content = value;
        }
        [Browsable(true)]
        public new string DealText
        {
            get => (AboutDeal.Text).ToString();
            set => AboutDeal.Text = value;
        }

        public Deal (string dealText, int priority, string deadLine)
        {
            Priority = priority;
            DeadLine = deadLine;
            DealText = dealText;
        }
    }
}
