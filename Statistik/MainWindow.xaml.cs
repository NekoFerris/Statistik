using Statistik.Model;
using Statistik.ViewModel;
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

namespace Statistik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Rectangle> _balken = new();
        private MainViewModel? MainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            MainViewModel = FindResource("mvmodel") as MainViewModel;
        }

        public List<Rectangle> Balken
        {
            get
            {
                return _balken;
            }
        }

        public void UpdateBalken()
        {
            if (MainViewModel != null)
            {
                _balken.Clear();
                MainViewModel.DataSets.Sort((x, y) => x.Value.CompareTo(y.Value));
                foreach (DataSet dataSet in MainViewModel.DataSets)
                {

                }
            }
        }
    }
}