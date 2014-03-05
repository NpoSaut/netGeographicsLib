using System;

namespace Geographics
{
    /// <summary>Величина угла в градусах</summary>
    public struct Degree : IComparable<Degree>
    {
        private double _value;

        public Degree(Double value) { _value = value; }

        /// <summary>Значение величины угла в градусах</summary>
        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>Сравнивает текущий объект с другим объектом того же типа.</summary>
        /// <param name="other">Объект, который требуется сравнить с данным объектом.</param>
        public int CompareTo(Degree other) { return Value.CompareTo(other.Value); }

        public static implicit operator Double(Degree v) { return v.Value; }
        public static implicit operator Degree(Double v) { return new Degree(v); }

        public Radian ToRadian() { return new Radian(Value * Math.PI / 180.0); }
        public static implicit operator Radian(Degree v) { return v.ToRadian(); }

        public override string ToString() { return string.Format("{0:F4}°", Value); }
    }
}
