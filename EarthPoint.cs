using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Geographics
{
    /// <summary>Представляет проекцию точки на земную сферу</summary>
    public struct EarthPoint
    {
        private static readonly Regex _parsingExpression = new Regex(@"(?<lat>\d+([,\.]\d+)?)°?\s+(?<lon>\d+([,\.]\d+)?)°?");
        private Degree _latitude;

        private Degree _longitude;

        /// <summary>Создаёт новую точку со сферическими координатами</summary>
        /// <param name="Latitude">Широта</param>
        /// <param name="Longitude">Долгота</param>
        public EarthPoint(Degree Latitude, Degree Longitude)
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

        /// <summary>Проверяет, попадает ли точка в заданную прямоугольную область</summary>
        /// <param name="Area">Прямоугольная область</param>
        /// <returns>True, если точка лежит внутри заданной прямоугольной области</returns>
        public bool IsInArea(EarthArea Area)
        {
            return Longitude >= Area.MostWesternLongitude && Longitude <= Area.MostEasternLongitude &&
                   Latitude >= Area.MostSouthernLatitude && Latitude <= Area.MostNorthenLatitude;
        }

        /// <summary>Получает точку, лежащую между указанными точками</summary>
        /// <param name="Point1">Точка 1</param>
        /// <param name="Point2">Точка 2</param>
        /// <param name="Ratio">Доля участка между точками 1 и 2</param>
        public static EarthPoint MiddlePoint(EarthPoint Point1, EarthPoint Point2, Double Ratio = 0.5)
        {
            return new EarthPoint(
                (1 - Ratio) * Point1.Latitude + Ratio * Point2.Latitude,
                (1 - Ratio) * Point1.Longitude + Ratio * Point2.Longitude);
        }

        public override string ToString() { return string.Format("{0} {1}", Latitude, Longitude); }

        public static bool TryParse(string Value, out EarthPoint Point)
        {
            Match m = _parsingExpression.Match(Value);
            if (!m.Success)
            {
                Point = default(EarthPoint);
                return false;
            }
            Point = new EarthPoint(Double.Parse(m.Groups["lat"].Value.Replace(',', '.'), CultureInfo.InvariantCulture),
                                   Double.Parse(m.Groups["lon"].Value.Replace(',', '.'), CultureInfo.InvariantCulture));
            return true;
        }

        public static EarthPoint Parse(string Value)
        {
            EarthPoint p;
            TryParse(Value, out p);
            return p;
        }
    }
}
