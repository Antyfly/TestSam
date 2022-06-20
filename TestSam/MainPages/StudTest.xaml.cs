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
using TestSam.MainPages;

namespace TestSam.MainPages
{
    /// <summary>
    /// Логика взаимодействия для StudTest.xaml
    /// </summary>
    public partial class StudTest : Page
    {
        public int _idMaterial;
        public static int TitleId { get; set; }

        public StudTest()
        {
            InitializeComponent();
            //Test.Navigate(new TestPlug());
            Title.ItemsSource = con.EdMaterial.ToList();

        }

        private void Title_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Title.SelectedItem is EdMaterial info)
            {
                _idMaterial = info.ID;
                EDText.ItemsSource = con.Questions.Where(q => q.IDMaterial == _idMaterial).ToList();
                CheckButton.Visibility = Visibility.Visible;
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
