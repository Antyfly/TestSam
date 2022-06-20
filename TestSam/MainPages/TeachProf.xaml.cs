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
    /// Логика взаимодействия для TeachProf.xaml
    /// </summary>
    public partial class TeachProf : Page
    {
        Entities ent = new Entities();
        int UsID = Avt.UserId;
        public TeachProf()
        {
            InitializeComponent();

            int UsID = Avt.UserId;
            var teacher = ClassConnect.con.Teacher.ToList().Where(i => i.ID == UsID).FirstOrDefault();
            LN.Text = teacher.Name;
            MN.Text = teacher.LastName;
            Nm.Text = teacher.MiddleName;
            Log.Content = teacher.Login;
            Pas.Content = teacher.Password;
        }
        private void OlGrPrf_Loaded(object sender, RoutedEventArgs e)
        {
            GrPrf.ItemsSource = ClassConnect.con.Group.ToList();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int UsID = Avt.UserId;
            var teacher = ent.Group.AsNoTracking().FirstOrDefault(i => i.Teacher.ID == UsID);
            if (teacher != null)
            {
                var query =
                      from Group in ent.Group
                      where Group.IdTeacher == teacher.ID
                      orderby Group.Name
                      select new { Group.ID, Group.Name };
                //GrPrf.ItemsSource = query.ToList();
                GrPrf.ItemsSource = teacher.Name.ToList();
                //Test.Content = teacher.Name.ToString();
            }
        }
    }
}
