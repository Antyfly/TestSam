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

namespace TestSam.MainPages
{
    /// <summary>
    /// Логика взаимодействия для TeachGroup.xaml
    /// </summary>
    public partial class TeachGroup : Page
    {
        public int IDGroup;
        public TeachGroup()
        {
            InitializeComponent();
            LGroup.ItemsSource = con.Group.ToList();
        }

        private void LGroup_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (LGroup.SelectedItem is Group infoGroup)
            {
                IDGroup = infoGroup.ID;
                LStudName.ItemsSource = con.Student.Where(i => i.Class == IDGroup).ToList();
            }
        }
    }
}
