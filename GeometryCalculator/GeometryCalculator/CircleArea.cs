namespace GeometryCalculator
{
    public class CircleArea: ICircle
    {
        public double Radius { get; set; }

        public CircleArea(double radius)
        {
            if (radius - Constants.MinRadiusValue < Constants.MinValue 
                || radius - Constants.MinRadiusValue > Constants.MaxValue)
                throw new ArgumentException("Circle radius is wrong", nameof(radius));

            Radius = radius;
        }

        public double GetAreaCircle()
        {
            return Math.PI * Math.Pow(Radius, 2d);
        }
    }
}
