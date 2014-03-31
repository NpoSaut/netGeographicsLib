using System;

namespace Geographics
{
    /// <summary>Величина угла в радианах</summary>
    public struct Radian : IComparable<Radian>
    {
        private double _value;

        public Radian(double value) { _value = value; }

        /// <summary>Значение величины угла в радианах</summary>
        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>Сравнивает текущий объект с другим объектом того же типа.</summary>
        /// <param name="other">Объект, который требуется сравнить с данным объектом.</param>
        public int CompareTo(Radian other) { return Value.CompareTo(other.Value); }

        public static implicit operator Double(Radian v) { return v.Value; }
        public static explicit operator Radian(Double v) { return new Radian(v); }

        public Degree ToDegree() { return new Degree(Value * 180.0 / Math.PI); }
        public static implicit operator Degree(Radian v) { return v.ToDegree(); }

        public static Radian operator +(Radian v1, Radian v2) { return new Radian(v1.Value + v2.Value); }
        public static Radian operator -(Radian v1, Radian v2) { return new Radian(v1.Value - v2.Value); }
        public static Radian operator *(Double m, Radian val) { return new Radian(m * val.Value); }
        public static Radian operator *(Radian val, Double m) { return new Radian(m * val.Value); }
        public static Radian operator /(Radian val, Double m) { return new Radian(val.Value / m); }

        public override string ToString() { return Value.ToString("F4"); }
    }
}
