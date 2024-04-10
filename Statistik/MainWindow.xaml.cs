using Statistik.Model;
using Statistik.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Statistik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel? MainViewModel;

        public MainWindow()
        {
            InitializeComponent();
            MainViewModel = FindResource("mvmodel") as MainViewModel;
            ZeichneDiagramm();
        }

        public void ZeichneDiagramm()
        {
            cnvBalken.Children.Clear();
            if (MainViewModel == null)
                throw new NullReferenceException();
            double abstand = (cnvBalken.ActualWidth * 0.1) / (MainViewModel.DataSets.Count + 1);
            double breite = (cnvBalken.ActualWidth * 0.9) / (MainViewModel.DataSets.Count);
            double rechts = abstand;
            double hoehe = cnvBalken.ActualHeight;
            double maxVal = MainViewModel.DataSets.Max(x => x.Value);
            foreach (DataSet dataSet in MainViewModel.DataSets)
            {
                Rectangle rectangle = new();
                rectangle.Width = breite;
                double hoheProzent = dataSet.Value / maxVal;
                rectangle.Height = hoehe * hoheProzent * 0.9;
                rectangle.Fill = dataSet.solidColorBrush;
                cnvBalken.Children.Add(rectangle);
                Canvas.SetBottom(rectangle, 0);
                Canvas.SetLeft(rectangle, rechts);
                rechts += abstand + breite;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ZeichneDiagramm();
        }

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            ZeichneDiagramm();
        }
    }
}