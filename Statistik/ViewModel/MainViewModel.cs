using Statistik.Model;
using System.Drawing;

namespace Statistik.ViewModel
{
    internal class MainViewModel : BaseModel
    {
        private DataSet _selectedDataSet;
        private List<DataSet> _dataSets = new();
        public DataSet SelectedDataSet
        {
            get
            {
                return _selectedDataSet;
            }
            set
            {
                _selectedDataSet = value;
                OnPropertyChanged(nameof(SelectedDataSet));
            }
        }
        public List<DataSet> DataSets
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
