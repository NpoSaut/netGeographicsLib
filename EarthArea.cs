using System.Linq;

namespace Geographics
{
    /// <summary>Трапециевидную область на поверхности Земли</summary>
    public struct EarthArea
    {
        /// <summary>Создаёт трапециевидную область с указанными границами</summary>
        /// <param name="MostWesternLongitude">Западная граница области</param>
        /// <param name="MostEasternLongitude">Восточная граница области</param>
        /// <param name="MostNorthenLatitude">Северная граница области</param>
        /// <param name="MostSouthernLatitude">Южная граница области</param>
        public EarthArea(Degree MostWesternLongitude, Degree MostEasternLongitude, Degree MostNorthenLatitude,
                         Degree MostSouthernLatitude) : this()
        {
            this.MostSouthernLatitude = MostSouthernLatitude;
            this.MostNorthenLatitude = MostNorthenLatitude;
            this.MostEasternLongitude = MostEasternLongitude;
            this.MostWesternLongitude = MostWesternLongitude;
        }

        /// <summary>Создаёт трапециевидную область, содержащую все указанные точки</summary>
        /// <param name="Points">Массив точек, вокруг которых должна быть описана область</param>
        public EarthArea(params EarthPoint[] Points) : this()
        {
            MostWesternLongitude = new Degree(Points.Min(p => p.Longitude));
            MostEasternLongitude = new Degree(Points.Max(p => p.Longitude));
            MostSouthernLatitude = new Degree(Points.Min(p => p.Latitude));
            MostNorthenLatitude = new Degree(Points.Max(p => p.Latitude));
        }

        /// <summary>Западная граница области</summary>
        public Degree MostWesternLongitude { get; private set; }

        /// <summary>Восточная граница области</summary>
        public Degree MostEasternLongitude { get; private set; }

        /// <summary>Северная граница области</summary>
        public Degree MostNorthenLatitude { get; private set; }

        /// <summary>Южная граница области</summary>
        public Degree MostSouthernLatitude { get; private set; }

        /// <summary>Проверяет, пересекаются ли эта область с другой</summary>
        /// <param name="Another">Область, пересечение с которой требуется проверить</param>
        /// <returns>True, если области пересекаются</returns>
        public bool IsIntersects(EarthArea Another)
        {
            return MostEasternLongitude >= Another.MostWesternLongitude
                   && MostWesternLongitude <= Another.MostEasternLongitude
                   && MostNorthenLatitude >= Another.MostSouthernLatitude
                   && MostSouthernLatitude <= Another.MostNorthenLatitude;
        }
    }
}
