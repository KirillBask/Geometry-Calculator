namespace GeometryCalculatorTest
{
    public class CircleAreaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase]
        public void CircleRadiusIsTooBig()
        {
            //Arrange
            var radius = Math.Pow(Constants.MaxValue, 2);

            //Assert
            Assert.Catch<ArgumentException>(() => new CircleArea(radius));
        }

        [Test]
        public void GetAreaTest()
        {
            // Arrange
            var radius = 10;
            var circle = new CircleArea(radius);
            var expectedValue = Math.PI * Math.Pow(radius, 2d);

            // Act
            var area = circle.GetAreaCircle();

            //Assert
            Assert.Less(Math.Abs(area - expectedValue), Constants.MinValue);
        }

        [TestCase(-1)]
        [TestCase(-4)]
        [TestCase(-66.6)]
        public void CircleRadiusIsNegativeTest(double a)
        {
            Assert.Catch<ArgumentException>(() => new CircleArea(a));
        }

        [TestCase]
        public void CircleRadiusIsZero()
        {
            Assert.Catch<ArgumentException>(() => new CircleArea(0));
        }
    }
}