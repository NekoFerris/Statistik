using Statistik.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;

namespace Statistik.ViewModel
{
    internal class MainViewModel : BaseModel
    {
        private ObservableCollection<DataSet> _dataSets = new();
        public MainViewModel()
        {
            _dataSets.CollectionChanged += DataSetsChanged;
            _dataSets.Add(new DataSet("Bob", 59));
            _dataSets.Add(new DataSet("Markus", 10));
            _dataSets.Add(new DataSet("Sabine", 89));
            UpdateBalken();
        }

        private void DataSetsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender == null)
                throw new NullReferenceException();
            UpdateBalken();
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
                UpdateBalken();
                OnPropertyChanged(nameof(DataSets));
            }
        }

        public void UpdateBalken()
        {
            _dataSets = new ObservableCollection<DataSet>(_dataSets.OrderBy(n => n.Value).ToList());
            for(int i = 0; i < _dataSets.Count; i++)
            {
                if(i == 0)
                {
                    _dataSets[i].HeightInPercent = 100;
                }
                else
                {
                    _dataSets[i].HeightInPercent = _dataSets[i].Value / _dataSets[0].Value * 100;
                }
            }
        }
    }
}
