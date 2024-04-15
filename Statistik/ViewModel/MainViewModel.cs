using Statistik.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Statistik.ViewModel
{
    internal class MainViewModel : BaseModel
    {
        private ObservableCollection<DataSet> _dataSets = new();
        private DataSet? _selDataSet = null;
        Random r = new();
        public MainViewModel()
        {
            _dataSets.Add(new DataSet("Bob", r.Next(20,400)));
            _dataSets.Add(new DataSet("Markus", r.Next(20, 400)));
            _dataSets.Add(new DataSet("Sabine", r.Next(20, 400)));
            _dataSets.CollectionChanged += dataSetsChanged;
        }

        private void dataSetsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(DataSets));
        }

        public ObservableCollection<DataSet> DataSets
        {
            get
            {
                return _dataSets;
            }
            set
            {
                _dataSets = value;
                OnPropertyChanged(nameof(DataSets));
            }
        }
        public DataSet SelDataSet
        {
            get
            {
                return _selDataSet;
            }
            set
            {
                _selDataSet = value;
                OnPropertyChanged(nameof(SelDataSet));
            }
        }
    }
}
