using Statistik.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Statistik.ViewModel
{
    internal class MainViewModel : BaseModel
    {
        private ObservableCollection<DataSet> _dataSets = new();
        public MainViewModel()
        {
            _dataSets.Add(new DataSet("Bob", 59));
            _dataSets.Add(new DataSet("Markus", 10));
            _dataSets.Add(new DataSet("Sabine", 89));
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
    }
}
