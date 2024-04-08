using System.Windows.Media;

namespace Statistik.Model
{
    internal class DataSet
    {
        private string _name;
        private int _value;
        private SolidColorBrush _solidColorBrush;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        public SolidColorBrush solidColorBrush
        {
            get
            {
                return _solidColorBrush;
            }
            set
            {
                _solidColorBrush = value;
            }
        }
        public byte ColorR
        {
            get
            {
                return _solidColorBrush.Color.R;
            }
            set 
            {
                Color color = _solidColorBrush.Color;
                color.R = value;
                _solidColorBrush.Color = color;
            }
        }
        public byte ColorG
        {
            get
            {
                return _solidColorBrush.Color.G;
            }
            set
            {
                Color color = _solidColorBrush.Color;
                color.G = value;
                _solidColorBrush.Color = color;
            }
        }
        public byte ColorB
        {
            get
            {
                return _solidColorBrush.Color.B;
            }
            set
            {
                Color color = _solidColorBrush.Color;
                color.B = value;
                _solidColorBrush.Color = color;
            }
        }
    }
}
