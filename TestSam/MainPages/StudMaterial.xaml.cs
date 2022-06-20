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
using TestSam.MainPages;

namespace TestSam.MainPages
{
    /// <summary>
    /// Логика взаимодействия для StudMaterial.xaml
    /// </summary>
    public partial class StudMaterial : Page
    {
        public StudMaterial()
        {
            InitializeComponent();

            Title.ItemsSource = ClassConnect.con.EdMaterial.ToList();
        }
        
        private void Title_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EdMaterial material = Title.SelectedItem as EdMaterial;
            var IsID = ClassConnect.con.EdMaterial.ToList().Where(i => i.Topic == material.Topic).FirstOrDefault();
            EDText.Text = IsID.Text;
        }
    }
}
