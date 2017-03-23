using System;

namespace Geographics
{
    /// <summary>Величина угла в градусах</summary>
    public struct Degree : IComparable<Degree>
    {
        public Degree(Double value) { Value = value; }

        /// <summary>Значение величины угла в градусах</summary>
        public double Value { get; private set; }

        /// <summary>Сравнивает текущий объект с другим объектом того же типа.</summary>
        /// <param name="other">Объект, который требуется сравнить с данным объектом.</param>
        public int CompareTo(Degree other) { return Value.CompareTo(other.Value); }

        public static implicit operator Double(Degree v) { return v.Value; }
        public static implicit operator Degree(Double v) { return new Degree(v); }

        public Radian ToRadian() { return new Radian(Value * Math.PI / 180.0); }
        public static implicit operator Radian(Degree v) { return v.ToRadian(); }

        public static Degree operator +(Degree v1, Degree v2) { return new Degree(v1.Value + v2.Value); }
        public static Degree operator -(Degree v1, Degree v2) { return new Degree(v1.Value - v2.Value); }
        public static Degree operator *(Double m, Degree val) { return new Degree(m * val.Value); }
        public static Degree operator *(Degree val, Double m) { return new Degree(m * val.Value); }
        public static Degree operator /(Degree val, Double m) { return new Degree(val.Value / m); }

        public override string ToString() { return string.Format("{0:F4}°", Value); }
    }
}
