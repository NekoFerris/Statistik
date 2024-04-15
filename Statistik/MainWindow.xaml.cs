using Statistik.Model;
using Statistik.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
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
            if (MainViewModel == null)
                throw new NullReferenceException();
            cnvBalken.Children.Clear();
            double abstand = (cnvBalken.ActualWidth * 0.1) / (MainViewModel.DataSets.Count + 1);
            double breite = (cnvBalken.ActualWidth * 0.9) / (MainViewModel.DataSets.Count);
            double rechts = abstand;
            double hoehe = cnvBalken.ActualHeight;
            double maxVal = MainViewModel.DataSets.Max(x => x.Value);
            DropShadowEffect dropShadow = new DropShadowEffect();
            dropShadow.Color = Colors.White; // Shadow color
            dropShadow.Direction = 0; // Angle of shadow (in degrees)
            dropShadow.ShadowDepth = 0; // Shadow depth
            dropShadow.BlurRadius = 10; // Shadow blur radius
            foreach (DataSet dataSet in MainViewModel.DataSets)
            {
                Rectangle rectangle = new();
                rectangle.Width = breite;
                double hoheProzent = dataSet.Value / maxVal;
                rectangle.Height = hoehe * hoheProzent * 0.9;
                rectangle.Fill = dataSet.SolidColorBrush;
                rectangle.Tag = dataSet;
                rectangle.MouseLeftButtonUp += SelectDataSet;
                cnvBalken.Children.Add(rectangle);
                Canvas.SetBottom(rectangle, 0);
                Canvas.SetLeft(rectangle, rechts);
                Label label = new();
                label.Content = dataSet.Name;
                label.FontSize = 20;
                label.FontWeight = FontWeights.Bold;
                label.Width = breite;
                label.HorizontalContentAlignment = HorizontalAlignment.Center;
                label.Effect = dropShadow;
                label.Focusable = false;
                cnvBalken.Children.Add(label);
                if ((rectangle.Height / 3) < 20)
                {
                    Canvas.SetBottom(label, rectangle.Height);
                    Canvas.SetLeft(label, rechts);
                }
                else
                {
                    Canvas.SetBottom(label, rectangle.Height - 35);
                    Canvas.SetLeft(label, rechts);
                }
                rechts += abstand + breite;
            }
        }

        private void SelectDataSet(object sender, MouseButtonEventArgs e)
        {
            if (sender is Rectangle rec)
            {
                MainViewModel.SelDataSet = (DataSet)rec.Tag;
                dataGrid.ScrollIntoView((DataSet)rec.Tag);
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ZeichneDiagramm();
        }

        private void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            ZeichneDiagramm();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ZeichneDiagramm();
        }

        private void dataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if(sender != null)
            {
                if(((DataGrid)sender).SelectedItem != null)
                {
                    if (e.Key == Key.Delete)
                    {
                        DataGrid dataGrid = (DataGrid)sender;
                        MainViewModel.DataSets.Remove(MainViewModel.SelDataSet);
                    }
                }
            }
        }
    }
}