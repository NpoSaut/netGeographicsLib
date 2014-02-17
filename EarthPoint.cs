namespace Geographics
{
    /// <summary>
    /// Представляет проекцию точки на земную сферу
    /// </summary>
    public struct EarthPoint
    {
        private Degree _Latitude;
        /// <summary>
        /// Широта
        /// </summary>
        public Degree Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; }
        }

        private Degree _Longitude;
        /// <summary>
        /// Долгота
        /// </summary>
        public Degree Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
        }
        

        public EarthPoint(Degree Latitude, Degree Longitude)
        {
            this._Latitude = Latitude;
            this._Longitude = Longitude;
        }
    }
}
