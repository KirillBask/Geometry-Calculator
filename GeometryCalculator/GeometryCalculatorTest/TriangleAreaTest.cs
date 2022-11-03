namespace GeometryCalculatorTest
{
    public class TriangleAreaTest
    {
        [TestCase(-6, 6, 6)]
        [TestCase(6, -6, 6)]
        [TestCase(7, 7, -7)]
        [TestCase(0, 0, 0)]
        public void InitTriangleAreaWithErrorTest(double a, double b, double c)
        {
            Assert.Catch<ArgumentException>(() => new TriangleArea(a, b, c));
        }

        [Test]
        public void InitTriangleAreaWithMaxSideValue()
        {
            //Arrange
            var a = Math.Pow(Constants.MaxValue, 2);
            var b = 6;
            var c = 6;
            Assert.Catch<ArgumentException>(() => new TriangleArea(a, b, c));
        }

        [Test]
        public void InitTriangleAreaTest()
        {
            //Arrange
            double a = 3d, b = 4d, c = 5d;

            //Act
            var triangle = new TriangleArea(a, b, c);

            //Assert
            Assert.NotNull(triangle);
            Assert.Less(Math.Abs(triangle.SideA - a), Constants.MinValue);
            Assert.Less(Math.Abs(triangle.SideB - b), Constants.MinValue);
            Assert.Less(Math.Abs(triangle.SideC - c), Constants.MinValue);
        }

        [Test]
        public void GetSquareTest()
        {
            //Arrange
            double a = 3d, b = 4d, c = 5d;
            double result = 6d;
            var triangle = new TriangleArea(a, b, c);

            //Act
            var square = triangle?.GetTriangleArea();

            //Assert
            Assert.NotNull(square);
            Assert.Less(Math.Abs(square.Value - result), Constants.MinValue);
        }

        [Test]
        public void InitNotTriangleTest()
        {
            Assert.Catch<ArgumentException>(() => new TriangleArea(1, 1, 9));
        }

        [TestCase(3, 4, 3, ExpectedResult = false)]
        [TestCase(3, 4, 5, ExpectedResult = true)]
        [TestCase(3, 4, 5.000000001, ExpectedResult = true)]
        public bool NotRightTriangle(double a, double b, double c)
        {
            // Data.
            var triangle = new TriangleArea(a, b, c);

            // Act.
            var isRight = triangle.IsIsoscelesTriangle;

            // Assert. 
            return isRight;
        }
    }
}
