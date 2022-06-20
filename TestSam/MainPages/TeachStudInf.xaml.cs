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
using TestSam.MainWindow;

namespace TestSam.MainPages
{
    /// <summary>
    /// Логика взаимодействия для TeachStudInf.xaml
    /// </summary>
    public partial class TeachStudInf : Page
    {
        List<Group> groups = new List<Group>();
        Entities ent = new Entities();
        int UsID = Avt.UserId;
        public TeachStudInf()
        {
            InitializeComponent();
            LBox.ItemsSource = ClassConnect.con.Student.ToList();
            
        }

        private void LBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Student student = LBox.SelectedItem as Student;
            var IsID = ClassConnect.con.PerformanceJournal.ToList().Where(i => i.IDStudent == student.ID).FirstOrDefault();
            L2.ItemsSource = IsID.Estimation.ToString();
        }
    }
}
