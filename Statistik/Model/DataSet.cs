using System.Windows.Media;

namespace Statistik.Model
{
    internal class DataSet
    {
        private string? _name;
        private int _value;
        private SolidColorBrush? _solidColorBrush;

        public DataSet() { }

        public DataSet(string? name, int value)
        {
            _name = name;
            _value = value;
            _solidColorBrush = Brushes.Black;
        }

        public string? Name
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
        public SolidColorBrush? solidColorBrush
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
                if (_solidColorBrush != null)
                    return _solidColorBrush.Color.R;
                else 
                    throw new NullReferenceException();
            }
            set
            {
                if (_solidColorBrush == null)
                    throw new NullReferenceException();
                Color color = _solidColorBrush.Color;
                color.R = value;
                _solidColorBrush.Color = color;
            }
        }
        public byte ColorG
        {
            get
            {
                if (_solidColorBrush != null)
                    return _solidColorBrush.Color.G;
                else 
                    throw new NullReferenceException();
            }
            set
            {
                if (_solidColorBrush == null)
                    throw new NullReferenceException();
                Color color = _solidColorBrush.Color;
                color.G = value;
                _solidColorBrush.Color = color;
            }
        }
        public byte ColorB
        {
            get
            {
                if (_solidColorBrush != null)
                    return _solidColorBrush.Color.B;
                else 
                    throw new NullReferenceException();
            }
            set
            {
                if (_solidColorBrush == null)
                    throw new NullReferenceException();
                Color color = _solidColorBrush.Color;
                color.B = value;
                _solidColorBrush.Color = color;
            }
        }
    }
}
