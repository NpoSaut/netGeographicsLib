using System;

namespace Geographics
{
    /// <summary>Вектор между двумя точками на поверхности</summary>
    public struct EarthVector
    {
        /// <summary>Кэш длины вектора</summary>
        private readonly Lazy<Double> _lazyLength;

        /// <summary>Создаёт вектор между двумя точками на поверхности</summary>
        /// <param name="StartPoint">Начальная точка</param>
        /// <param name="EndPoint">Конечная точка</param>
        public EarthVector(EarthPoint StartPoint, EarthPoint EndPoint) : this()
        {
            _lazyLength = new Lazy<double>(GetLength, true);
            this.EndPoint = EndPoint;
            this.StartPoint = StartPoint;
        }

        /// <summary>Начальная точка</summary>
        public EarthPoint StartPoint { get; private set; }

        /// <summary>Конечная точка</summary>
        public EarthPoint EndPoint { get; private set; }

        /// <summary>Длина вектора</summary>
        public Double Length
        {
            get { return _lazyLength.Value; }
        }

        /// <summary>Функция измерения длины вектора</summary>
        private double GetLength() { return EndPoint.DistanceTo(StartPoint); }
    }
}
