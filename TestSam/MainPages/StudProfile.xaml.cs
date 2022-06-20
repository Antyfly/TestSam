using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для StudProfile.xaml
    /// </summary>
    public partial class StudProfile : Page
    {
        Entities ent = new Entities();
        int UsID = Avt.UserId;
        public StudProfile()
        {
            InitializeComponent();
            int UsID = Avt.UserId;
            var student = ClassConnect.con.Student.ToList().Where(i => i.ID == UsID).FirstOrDefault();
            Nm.Text = student.Name;
            MN.Text = student.MiddleName;
            LN.Text = student.LastName;
            Gr.Content = student.Group.Name;
            Log.Content = student.Login;
            Pas.Content = student.Password;
        }

        private void OlGrPrf_Loaded(object sender, RoutedEventArgs e)
        {
            var student = ent.Student.AsNoTracking().FirstOrDefault(i => i.ID == UsID);
            if (student != null)
            {
                var query =
                      from PerformanceJournal in ent.PerformanceJournal
                      where PerformanceJournal.IDStudent == student.ID
                      orderby PerformanceJournal.EdMaterial.Topic
                      select new { PerformanceJournal.ID, PerformanceJournal.Estimation, PerformanceJournal.EdMaterial.Topic };
                OlGrPrf.ItemsSource = query.ToList();
            }
        }
    }
}   
