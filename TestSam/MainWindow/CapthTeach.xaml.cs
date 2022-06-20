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

namespace TestSam.MainWindow
{
    /// <summary>
    /// Логика взаимодействия для CapthTeach.xaml
    /// </summary>
    public partial class CapthTeach : Window
    {
        public static CapthTeach menuWindow { get; set; }
        public CapthTeach()
        {
            InitializeComponent();
            CapthLb.Content = GetCaptha();
            menuWindow = this;
            MP4.Source = new Uri(Environment.CurrentDirectory + @"\Cap.mp4");
            MP4.Position = TimeSpan.Zero;
            MP4.Play();
        }
        private void MP4_MediaEnded(object sender, RoutedEventArgs e)
        {
            MP4.Position = TimeSpan.Zero;
            MP4.Play();
        }
        string GetCaptha()
        {
            Random random = new Random();
            string str = string.Empty;
            string getstring = string.Empty;
            str = "1234567890"; // 10 
            for (int i = 65; i < 91; i++) // 25 + 0
            {
                str += (char)i;
            }

            for (int i = 0; i < 4; i++)
            {
                getstring += str[random.Next(36)];
            }
            return getstring;
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            CapthLb.Content = GetCaptha();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TextTb.Text.Equals(CapthLb.Content))
            {
                MessageBox.Show("OK");
                Teach m = new Teach();
                m.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("NO");
            }

        }
    }
}
