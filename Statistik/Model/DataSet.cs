using System.Windows.Media;

namespace Statistik.Model
{
    internal class DataSet
    {
        private string? _name;
        private int _value;
        private SolidColorBrush? _solidColorBrush;
        Random r = new();

        public DataSet() 
        {
            Name = "NoName";
            Value = 0;
            Color color = new Color();
            color.A = 255;
            color.R = 0;
            color.G = 0;
            color.B = 0;
            _solidColorBrush = new SolidColorBrush(color);
        }

        public DataSet(string? name, int value)
        {
            _name = name;
            _value = value;
            Color color = new Color();
            color.A = 255;
            color.R = (byte)r.Next(0, 256);
            color.G = (byte)r.Next(0, 256);
            color.B = (byte)r.Next(0, 256);
            _solidColorBrush = new SolidColorBrush(color);
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
        public SolidColorBrush? SolidColorBrush
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
                if (SolidColorBrush != null)
                    return SolidColorBrush.Color.R;
                else
                    return 0;
            }
            set
            {
                if (SolidColorBrush == null)
                    throw new NullReferenceException();
                Color color = SolidColorBrush.Color;
                color.R = value;
                SolidColorBrush.Color = color;
            }
        }
        public byte ColorG
        {
            get
            {
                if (SolidColorBrush != null)
                    return SolidColorBrush.Color.G;
                else
                    return 0;
            }
            set
            {
                if (SolidColorBrush == null)
                    throw new NullReferenceException();
                Color color = SolidColorBrush.Color;
                color.G = value;
                SolidColorBrush.Color = color;
            }
        }
        public byte ColorB
        {
            get
            {
                if (SolidColorBrush != null)
                    return SolidColorBrush.Color.B;
                else
                    return 0;
            }
            set
            {
                if (SolidColorBrush == null)
                    throw new NullReferenceException();
                Color color = SolidColorBrush.Color;
                color.B = value;
                SolidColorBrush.Color = color;
            }
        }
    }
}
