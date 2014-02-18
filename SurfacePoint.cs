using System;

namespace Geographics
{
    /// <summary>Координата точки на плоскости</summary>
    public struct SurfacePoint
    {
        /// <summary>Горизонтальная координата</summary>
        public Double X { get; set; }
        /// <summary>Вертикальная координата</summary>
        public Double Y { get; set; }

        public SurfacePoint(double X, double Y) : this()
        {
            this.X = X;
            this.Y = Y;
        }

        public static explicit operator EarthPoint(SurfacePoint sp) { return Mercator.Inverse(sp); }
        public static explicit operator SurfacePoint(EarthPoint ep) { return Mercator.Direct(ep); }
    }
}
