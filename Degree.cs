using System;

namespace Geographics
{
    /// <summary>Величина угла в градусах</summary>
    public struct Degree : IComparable<Degree>
    {
        public Degree(double value) { Value = value; }
        public Degree(int Degrees, int Minutes, double Seconds) : this(Degrees + (Minutes + Seconds / 60.0) / 60.0) { }

        /// <summary>Значение величины угла в градусах</summary>
        public double Value { get; }

        /// <summary>Сравнивает текущий объект с другим объектом того же типа.</summary>
        /// <param name="other">Объект, который требуется сравнить с данным объектом.</param>
        public int CompareTo(Degree other) { return Value.CompareTo(other.Value); }

        public static implicit operator double(Degree v) { return v.Value; }
        public static implicit operator Degree(double v) { return new Degree(v); }

        public Radian ToRadian() { return new Radian(Value * Math.PI / 180.0); }
        public static implicit operator Radian(Degree v) { return v.ToRadian(); }

        public static Degree operator +(Degree v1, Degree v2) { return new Degree(v1.Value + v2.Value); }
        public static Degree operator -(Degree v1, Degree v2) { return new Degree(v1.Value - v2.Value); }
        public static Degree operator *(double m, Degree val) { return new Degree(m * val.Value); }
        public static Degree operator *(Degree val, double m) { return new Degree(m * val.Value); }
        public static Degree operator /(Degree val, double m) { return new Degree(val.Value / m); }

        public override string ToString() { return string.Format("{0:F4}°", Value); }
    }
}
