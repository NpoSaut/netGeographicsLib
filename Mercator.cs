using System;

namespace Geographics
{
    /// <summary>Содержит методы для работы с проекцией Меркатора</summary>
    /// <remarks>Материалы по проекции:
    ///     <see href="http://ru.wikipedia.org/wiki/Проекция_Меркатора">Проекция Меркатора</see>
    ///     <see href="http://wiki.openstreetmap.org/wiki/Mercator#C.23_implementation">Реализации на OSM Wiki</see>
    /// </remarks>
    public static class Mercator
    {
        /// <summary>Усреднённый радиус Земли</summary>
        public const double R = 6.371e6;

        /// <summary>Прямое преобразование Меркатора (со сферы на плоскость)</summary>
        /// <param name="p">Координаты точки на сфере</param>
        /// <returns>Координаты точки на поверхности</returns>
        public static SurfacePoint Direct(EarthPoint p)
        {
            return new SurfacePoint(LongitudeToX(p.Longitude), LatitudeToY(p.Latitude));
        }

        /// <summary>Обратное преобразование Меркатора (с плоскости на сферу)</summary>
        /// <param name="p">Координаты точки на плоскости</param>
        /// <returns>Координаты точки на сфере</returns>
        public static EarthPoint Inverse(SurfacePoint p)
        {
            return new EarthPoint(XToLongitude(p.X), YToLatitude(p.Y));
        }

        /// <summary>Преобразует вертикальную координату на плоскости в широту</summary>
        public static Degree YToLatitude(double y)
        {
            return new Radian(2 * Math.Atan(Math.Exp(y / R)) - Math.PI / 2);
        }

        /// <summary>Преобразует широту в вертикальную координату на плоскости</summary>
        public static double LatitudeToY(Degree Latitude)
        {
            return R * Math.Log(Math.Tan(Math.PI / 4.0 + (Radian)Latitude / 2));
        }

        /// <summary>Преобразует горизонтальную координату на плоскости в долготу</summary>
        public static Degree XToLongitude(double x)
        {
            return new Radian(x / R);
        }

        /// <summary>Преобразует долготу в горизонтальную координату на плоскости</summary>
        public static double LongitudeToX(Degree Longitude)
        {
            return R * (Radian)Longitude;
        }
    }
}
