using System;
using System.Drawing;

namespace Geographics
{
    static class Mercator
    {
        public const double R = 6.371e6;

        public static PointF Project(EarthPoint p)
        {
            return new PointF()
            {
                X = (float)(R * (Radian)p.Longitude),
                Y = (float)(R * Math.Log(Math.Tan(Math.PI / 4 + (Radian)p.Latitude)))
            };
        }
    }
}
