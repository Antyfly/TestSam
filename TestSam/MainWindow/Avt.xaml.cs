using System;
using System.Collections.Generic;
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
using TestSam.MainCon;
namespace TestSam.MainWindow
{
    /// <summary>
    /// Логика взаимодействия для Avt.xaml
    /// </summary>
    public partial class Avt : Window
    {
         
        public Avt()
        {
            InitializeComponent();
        }
        public static int UserId { get; set;}
        public bool isEnter = false;
        private void LoginSt()
        {
            var student = ClassConnect.con.Student.ToList().Where(i => i.Login == Log.Text && i.Password == Pas.Password).FirstOrDefault();
            if (student != null)
            {
                UserId = student.ID;
                MessageBox.Show("ВЫ УСПЕШНО АВТОРИЗОВАЛИСЬ");
                CapthStud c = new CapthStud();
                c.ShowDialog();
                this.Close();
                isEnter = true;
            }
        }
        private void LoginTe()
        {
            var teacher = ClassConnect.con.Teacher.ToList().Where(i => i.Login == Log.Text && i.Password == Pas.Password).FirstOrDefault();
            if (teacher != null)
            {
                UserId = teacher.ID;
                MessageBox.Show("ВЫ УСПЕШНО АВТОРИЗОВАЛИСЬ");
                CapthTeach c = new CapthTeach();
                c.ShowDialog();
                this.Close();
                isEnter = true;
            }
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            LoginSt();
            if(isEnter == false)
            {
                LoginTe();
                if (isEnter == false)
                {
                    MessageBox.Show("Проверьте правильность данных");
                }
            }
        }
        private void PasAvt_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Pas.Password.Length > 0)
            {
                Watermack.Visibility = Visibility.Collapsed;
            }
            else
            {
                Watermack.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}

