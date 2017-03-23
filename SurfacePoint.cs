namespace Geographics
{
    /// <summary>Координата точки на плоскости</summary>
    public struct SurfacePoint
    {
        /// <summary>Горизонтальная координата</summary>
        public double X { get; private set; }

        /// <summary>Вертикальная координата</summary>
        public double Y { get; private set; }

        public SurfacePoint(double X, double Y) : this()
        {
            this.X = X;
            this.Y = Y;
        }

        public static explicit operator EarthPoint(SurfacePoint sp) { return Mercator.Inverse(sp); }
        public static explicit operator SurfacePoint(EarthPoint ep) { return Mercator.Direct(ep); }
    }
}
