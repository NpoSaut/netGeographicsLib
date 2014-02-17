namespace Geographics
{
    /// <summary>
    /// Представляет проекцию точки на земную сферу
    /// </summary>
    public struct EarthPoint
    {
        private Degree _latitude;
        /// <summary>
        /// Широта
        /// </summary>
        public Degree Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        private Degree _longitude;
        /// <summary>
        /// Долгота
        /// </summary>
        public Degree Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
        
        public EarthPoint(Degree Latitude, Degree Longitude)
        {
            this._latitude = Latitude;
            this._longitude = Longitude;
        }

        public override string ToString() { return string.Format("{0} {1}", Latitude, Longitude); }
    }
}
