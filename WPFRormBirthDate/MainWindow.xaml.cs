using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFRormBirthDate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            int day = int.Parse(tbDay.Text);
            int month = int.Parse(tbMonth.Text);
            int year = int.Parse(tbYear.Text);

            DateTime date = new DateTime(year, month, day);
            dpBirthDate.SelectedDate = date;
        }
    }
}