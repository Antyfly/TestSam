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
using TestSam.MainWindow;


namespace TestSam.MainWindow
{
    /// <summary>
    /// Логика взаимодействия для Stud.xaml
    /// </summary>
    public partial class Stud : Window
    {
        public static Stud menuWindow { get; set; }
        public Stud()
        {
            InitializeComponent();
            Stu.Navigate(new StudMaterial());
           menuWindow = this;
           MP4.Source = new Uri(Environment.CurrentDirectory + @"\Backgr.wmv");
           MP4.Position = TimeSpan.Zero;
           MP4.Play();
        }

        private void Mat_Click(object sender, RoutedEventArgs e)
        {
            Stu.Navigate(new StudMaterial());
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            Stu.Navigate(new StudTest());
        }

        private void My_Click(object sender, RoutedEventArgs e)
        {
            Stu.Navigate(new MyGrades());
        }

        private void MI_Click(object sender, RoutedEventArgs e)
        {
            Stu.Navigate(new StudProfile());
        }

        private void MP4_MediaEnded(object sender, RoutedEventArgs e)
        {
            MP4.Position = TimeSpan.Zero;
            MP4.Play();
        }
    }
}
