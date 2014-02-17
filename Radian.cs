using System;

namespace Geographics
{
    /// <summary>
    /// Величина угла в радианах
    /// </summary>
    public struct Radian
    {
        private double _Value;
        /// <summary>
        /// Значение величины угла в радианах
        /// </summary>
        public double Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        
        public Radian(double value) { _Value = value; }

        public static implicit operator Double(Radian v) { return v.Value; }
        public static explicit operator Radian(Double v) { return new Radian(v); }

        public Degree ToDegree() { return new Degree(Value * 180.0 / Math.PI); }
        public static implicit operator Degree(Radian v) { return v.ToDegree(); }

        public override string ToString()
        {
            return Value.ToString("F4");
        }
    }
}
