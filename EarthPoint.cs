﻿using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Geographics
{
    /// <summary>Представляет проекцию точки на земную сферу</summary>
    public struct EarthPoint
    {
        private static readonly Regex[] _parsingExpressions =
        {
            new Regex(@"(?<lat>\d+([,\.]\d+)?)°?\s+(?<lon>\d+([,\.]\d+)?)°?"),
            new Regex(@"http.+yandex.+?(?<lon>\d+\.\d+).+?(?<lat>\d+\.\d+)"),
            new Regex(@"http.+google.+?(?<lat>\d+\.\d+).+?(?<lon>\d+\.\d+)"),
            new Regex(@"(?<lat>\d+\.\d+).+?(?<lon>\d+\.\d+)")
        };

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
            get => _latitude;
            set => _latitude = value;
        }

        /// <summary>Долгота</summary>
        public Degree Longitude
        {
            get => _longitude;
            set => _longitude = value;
        }

        /// <summary>Проверяет, попадает ли точка в заданную прямоугольную область</summary>
        /// <param name="Area">Прямоугольная область</param>
        /// <returns>True, если точка лежит внутри заданной прямоугольной области</returns>
        public bool IsInArea(EarthArea Area)
        {
            return Longitude.Value >= Area.MostWesternLongitude.Value && Longitude.Value <= Area.MostEasternLongitude.Value &&
                   Latitude.Value >= Area.MostSouthernLatitude.Value && Latitude.Value <= Area.MostNorthenLatitude;
        }

        /// <summary>Получает точку, лежащую между указанными точками</summary>
        /// <param name="Point1">Точка 1</param>
        /// <param name="Point2">Точка 2</param>
        /// <param name="Ratio">Доля участка между точками 1 и 2</param>
        public static EarthPoint MiddlePoint(EarthPoint Point1, EarthPoint Point2, double Ratio = 0.5)
        {
            return new EarthPoint(
                (1 - Ratio) * Point1.Latitude + Ratio * Point2.Latitude,
                (1 - Ratio) * Point1.Longitude + Ratio * Point2.Longitude);
        }

        public override string ToString() { return string.Format("{0} {1}", Latitude, Longitude); }

        #region Parsing

        public static bool TryParse(string Value, out EarthPoint Point)
        {
            var match =
                _parsingExpressions.Select(exp => exp.Match(Value))
                                   .FirstOrDefault(m => m.Success);

            if (match == null)
            {
                Point = default(EarthPoint);
                return false;
            }
            Point = new EarthPoint(double.Parse(match.Groups["lat"].Value.Replace(',', '.'), CultureInfo.InvariantCulture),
                                   double.Parse(match.Groups["lon"].Value.Replace(',', '.'), CultureInfo.InvariantCulture));
            return true;
        }

        public static EarthPoint Parse(string Value)
        {
            EarthPoint p;
            TryParse(Value, out p);
            return p;
        }

        #endregion

        #region Equality

        public bool Equals(EarthPoint other) { return _latitude.Equals(other._latitude) && _longitude.Equals(other._longitude); }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is EarthPoint && Equals((EarthPoint)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_latitude.GetHashCode() * 397) ^ _longitude.GetHashCode();
            }
        }

        public static bool operator ==(EarthPoint left, EarthPoint right) { return left.Equals(right); }
        public static bool operator !=(EarthPoint left, EarthPoint right) { return !left.Equals(right); }

        #endregion
    }
}
