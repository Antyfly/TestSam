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
using TestSam.MainPages;

namespace TestSam.MainWindow
{
    /// <summary>
    /// Логика взаимодействия для Teach.xaml
    /// </summary>
    public partial class Teach : Window
    {
        public static Teach menuWindow { get; set; }
        public Teach()
        {
            InitializeComponent();

            Tech.Navigate(new TeachProf());
            menuWindow = this;
            MP4.Source = new Uri(Environment.CurrentDirectory + @"\Backgr.wmv");
            MP4.Position = TimeSpan.Zero;
            MP4.Play();
        }

        private void MP4_MediaEnded(object sender, RoutedEventArgs e)
        {
            MP4.Position = TimeSpan.Zero;
            MP4.Play();
        }

        private void Mat_Click(object sender, RoutedEventArgs e)
        {
            Tech.Navigate(new TeachStudInf());
        }

        private void My_Click(object sender, RoutedEventArgs e)
        {
            Tech.Navigate(new TeachProf());
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            Tech.Navigate(new TeachGroup());
        }

        private void Journal_Click(object sender, RoutedEventArgs e)
        {
            Tech.Navigate(new Journal());
        }
    }
}
