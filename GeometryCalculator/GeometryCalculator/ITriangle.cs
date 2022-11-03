namespace GeometryCalculator
{
    public interface ITriangle
    {
        public bool IsIsoscelesTriangle { get; }
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
    }
}
