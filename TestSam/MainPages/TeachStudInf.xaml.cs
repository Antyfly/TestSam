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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestSam.MainCon;
using static TestSam.MainCon.ClassConnect;
using TestSam.MainWindow;

namespace TestSam.MainPages
{
    /// <summary>
    /// Логика взаимодействия для TeachStudInf.xaml
    /// </summary>
    public partial class TeachStudInf : Page
    {
        public int _IDStudent = 3;
        public TeachStudInf()
        {
            InitializeComponent();
            LBox.ItemsSource = con.Student.ToList();
           
        }

        private void LBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Student student = LBox.SelectedItem as Student;
            L2.ItemsSource = con.PerformanceJournal.Where(pj => pj.IDStudent == student.ID).ToList();
        }
    }
}
