using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simulator;


namespace Simulator.Tests
{
    public class RectangleTests
    {
        [Theory]
        [InlineData(0, 0, 2, 2)]
        [InlineData(-1, -1, 1, 1)]
        [InlineData(-2, -2, 2, 2)]
        public void Constructor_ValidCoordinates_CreatesRectangle(int x1, int y1, int x2, int y2)
        {
            // Act
            var rectangle = new Rectangle(x1, y1, x2, y2);

            // Assert
            Assert.Equal(x1, rectangle.X1);
            Assert.Equal(y1, rectangle.Y1);
            Assert.Equal(x2, rectangle.X2);
            Assert.Equal(y2, rectangle.Y2);
        }

        [Theory]
        [InlineData(2, 2, 0, 0)]
        [InlineData(1, 1, -1, -1)]
        public void Constructor_ReversedCoordinates_NormalizesPoints(int x1, int y1, int x2, int y2)
        {
            // Act
            var rectangle = new Rectangle(x1, y1, x2, y2);

            // Assert
            Assert.True(rectangle.X1 < rectangle.X2);
            Assert.True(rectangle.Y1 < rectangle.Y2);
        }

        [Theory]
        [InlineData(0, 0, 0, 2)] // Vertical line
        [InlineData(0, 0, 2, 0)] // Horizontal line
        public void Constructor_CollinearPoints_ThrowsArgumentException(int x1, int y1, int x2, int y2)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
        }

        [Fact]
        public void Constructor_WithPoints_CreatesRectangle()
        {
            // Arrange
            var point1 = new Point(0, 0);
            var point2 = new Point(2, 2);

            // Act
            var rectangle = new Rectangle(point1, point2);

            // Assert
            Assert.Equal(0, rectangle.X1);
            Assert.Equal(0, rectangle.Y1);
            Assert.Equal(2, rectangle.X2);
            Assert.Equal(2, rectangle.Y2);
        }

        [Fact]
        public void Constructor_WithReversedPoints_NormalizesPoints()
        {
            // Arrange
            var point1 = new Point(2, 2);
            var point2 = new Point(0, 0);

            // Act
            var rectangle = new Rectangle(point1, point2);

            // Assert
            Assert.Equal(0, rectangle.X1);
            Assert.Equal(0, rectangle.Y1);
            Assert.Equal(2, rectangle.X2);
            Assert.Equal(2, rectangle.Y2);
        }

        [Theory]
        [InlineData(1, 1, 0, 0, 2, 2)]     // Point inside
        [InlineData(0, 0, 0, 0, 2, 2)]     // Point on corner
        [InlineData(2, 2, 0, 0, 2, 2)]     // Point on opposite corner
        [InlineData(1, 0, 0, 0, 2, 2)]     // Point on edge
        public void Contains_PointInRectangle_ReturnsTrue(int pointX, int pointY,
            int rectX1, int rectY1, int rectX2, int rectY2)
        {
            // Arrange
            var rectangle = new Rectangle(rectX1, rectY1, rectX2, rectY2);
            var point = new Point(pointX, pointY);

            // Act
            bool contains = rectangle.Contains(point);

            // Assert
            Assert.True(contains);
        }

        [Theory]
        [InlineData(-1, -1, 0, 0, 2, 2)]   // Point outside - left bottom
        [InlineData(3, 3, 0, 0, 2, 2)]     // Point outside - right top
        [InlineData(-1, 1, 0, 0, 2, 2)]    // Point outside - left
        [InlineData(1, 3, 0, 0, 2, 2)]     // Point outside - top
        public void Contains_PointOutsideRectangle_ReturnsFalse(int pointX, int pointY,
            int rectX1, int rectY1, int rectX2, int rectY2)
        {
            // Arrange
            var rectangle = new Rectangle(rectX1, rectY1, rectX2, rectY2);
            var point = new Point(pointX, pointY);

            // Act
            bool contains = rectangle.Contains(point);

            // Assert
            Assert.False(contains);
        }

        [Theory]
        [InlineData(0, 0, 2, 2, "(0, 0):(2, 2)")]
        [InlineData(-1, -1, 1, 1, "(-1, -1):(1, 1)")]
        public void ToString_ReturnsCorrectFormat(int x1, int y1, int x2, int y2, string expected)
        {
            // Arrange
            var rectangle = new Rectangle(x1, y1, x2, y2);

            // Act
            var result = rectangle.ToString();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
