using System;

namespace Geographics
{
    /// <summary>
    /// Величина угла в градусах
    /// </summary>
    public struct Degree
    {
        private double _Value;
        /// <summary>
        /// Значение величины угла в градусах
        /// </summary>
        public double Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        public Degree(Double value) { _Value = value; }

        public static implicit operator Double(Degree v) { return v.Value; }
        public static implicit operator Degree(Double v) { return new Degree(v); }

        public Radian ToRadian() { return new Radian(Value * Math.PI / 180.0); }
        public static implicit operator Radian(Degree v) { return v.ToRadian(); }

        public override string ToString()
        {
            return string.Format("{0:F4}°", Value.ToString());
        }
    }
}
