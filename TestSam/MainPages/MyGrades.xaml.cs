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
using TestSam.MainClass;
using TestSam.MainCon;
using TestSam.MainWindow;

namespace TestSam.MainPages
{
    /// <summary>
    /// Логика взаимодействия для MyGrades.xaml
    /// </summary>
    public partial class MyGrades : Page
    {
        Entities ent = new Entities();
        int UsID = Avt.UserId;
        public MyGrades()
        {
            InitializeComponent();
            
            Graf.Navigate(new LineGrap());

            var student = ClassConnect.con.Student.ToList().Where(i => i.ID == UsID).FirstOrDefault();
        }

        private void OlGr_Loaded(object sender, RoutedEventArgs e)
        {
            var student = ent.Student.AsNoTracking().FirstOrDefault(i => i.ID == UsID);
           if (student != null)
           {
                var query =
                      from PerformanceJournal in ent.PerformanceJournal
                      where PerformanceJournal.IDStudent == student.ID
                      orderby PerformanceJournal.EdMaterial.Topic
                      select new { PerformanceJournal.ID, PerformanceJournal.Estimation, PerformanceJournal.EdMaterial.Topic };
                OlGr.ItemsSource = query.ToList();
           }
        }
    }
}
