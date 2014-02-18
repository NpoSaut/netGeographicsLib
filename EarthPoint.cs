namespace Geographics
{
    /// <summary>Представляет проекцию точки на земную сферу</summary>
    public struct EarthPoint
    {
        private Degree _latitude;

        private Degree _longitude;

        /// <summary>Создаёт новую точку со сферическими координатами</summary>
        /// <param name="Longitude">Долгота</param>
        /// <param name="Latitude">Широта</param>
        public EarthPoint(Degree Longitude, Degree Latitude)
        {
            _latitude = Latitude;
            _longitude = Longitude;
        }

        /// <summary>Широта</summary>
        public Degree Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        /// <summary>Долгота</summary>
        public Degree Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        public override string ToString() { return string.Format("{0} {1}", Latitude, Longitude); }
    }
}
