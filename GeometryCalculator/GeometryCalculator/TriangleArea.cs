namespace GeometryCalculator
{
    public class TriangleArea: ITriangle
    {
        public bool IsIsoscelesTriangle => _isoscelesTriangle.Value;
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        private readonly Lazy<bool> _isoscelesTriangle;

        private double _minSideValue = Constants.MinValue;
        private double _maxSideValue = Constants.MaxValue;

        public TriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA < _minSideValue || sideA > _maxSideValue)
                throw new ArgumentException("Side 'A' value is wrong", nameof(sideA));

            if (sideB < _minSideValue || sideB > _maxSideValue)
                throw new ArgumentException("Side 'B' value is wrong", nameof(sideB));

            if (sideC < _minSideValue || sideC > _maxSideValue)
                throw new ArgumentException("Side 'C' value is wrong", nameof(sideC));

            var maxSideValue = Math.Max(sideA, Math.Max(sideB, sideC));
            var perimeter = sideA + sideB + sideC;

            if (perimeter - maxSideValue - maxSideValue < _minSideValue)
                throw new ArgumentException("The sum of the lengths of any two sides of a triangle must be greater than the length of the third side");

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            _isoscelesTriangle = new Lazy<bool>(IfIsoscelesTriangle);
        }


        private bool IfIsoscelesTriangle()
        {
            double maxSideValue = SideA, bSide = SideB, cSide = SideC;
            if (bSide - maxSideValue > _minSideValue)
                SwapTriangleSides(ref maxSideValue, ref bSide);

            if (cSide - maxSideValue > _minSideValue)
                SwapTriangleSides(ref maxSideValue, ref cSide);

            return Math.Abs(Math.Pow(maxSideValue, 2d) - Math.Pow(bSide, 2d) - Math.Pow(cSide, 2d)) < _minSideValue;
        }

        public double GetTriangleArea()
        {
            var halfPerimeter = (SideA + SideB + SideC) / 2d;
            var area = Math.Sqrt(halfPerimeter * (halfPerimeter - SideA) * (halfPerimeter - SideB) * (halfPerimeter - SideC));

            return area;
        }

        #region Utilities
        private void SwapTriangleSides<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        #endregion
    }
}