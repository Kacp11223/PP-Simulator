using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Simulator;

namespace Simulator.Tests
{
    public class PointTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, -1)]
        [InlineData(1, 1)]
        [InlineData(100, -100)]
        public void Constructor_SetsCoordinatesCorrectly(int x, int y)
        {
            // Act
            var point = new Point(x, y);

            // Assert
            Assert.Equal(x, point.X);
            Assert.Equal(y, point.Y);
        }

        [Theory]
        [InlineData(1, 1, "(1, 1)")]
        [InlineData(-1, -1, "(-1, -1)")]
        [InlineData(0, 0, "(0, 0)")]
        public void ToString_ReturnsCorrectFormat(int x, int y, string expected)
        {
            // Arrange
            var point = new Point(x, y);

            // Act
            var result = point.ToString();

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0, Direction.Right, 1, 0)]   // Move right
        [InlineData(0, 0, Direction.Left, -1, 0)]   // Move left
        [InlineData(0, 0, Direction.Up, 0, 1)]      // Move up
        [InlineData(0, 0, Direction.Down, 0, -1)]   // Move down
        public void Next_ReturnsCorrectPoint(int startX, int startY, Direction direction,
            int expectedX, int expectedY)
        {
            // Arrange
            var point = new Point(startX, startY);

            // Act
            var result = point.Next(direction);

            // Assert
            Assert.Equal(expectedX, result.X);
            Assert.Equal(expectedY, result.Y);
        }

        [Fact]
        public void Next_InvalidDirection_ReturnsSamePoint()
        {
            // Arrange
            var point = new Point(1, 1);
            Direction invalidDirection = (Direction)99;

            // Act
            var result = point.Next(invalidDirection);

            // Assert
            Assert.Equal(point.X, result.X);
            Assert.Equal(point.Y, result.Y);
        }

        [Theory]
        [InlineData(0, 0, Direction.Right, 1, -1)]  // Right diagonal (Right + 45° clockwise)
        [InlineData(0, 0, Direction.Left, -1, 1)]   // Left diagonal (Left + 45° clockwise)
        [InlineData(0, 0, Direction.Up, 1, 1)]      // Up diagonal (Up + 45° clockwise)
        [InlineData(0, 0, Direction.Down, -1, -1)]  // Down diagonal (Down + 45° clockwise)
        public void NextDiagonal_ReturnsCorrectPoint(int startX, int startY, Direction direction,
            int expectedX, int expectedY)
        {
            // Arrange
            var point = new Point(startX, startY);

            // Act
            var result = point.NextDiagonal(direction);

            // Assert
            Assert.Equal(expectedX, result.X);
            Assert.Equal(expectedY, result.Y);
        }

        [Fact]
        public void NextDiagonal_InvalidDirection_ReturnsSamePoint()
        {
            // Arrange
            var point = new Point(1, 1);
            Direction invalidDirection = (Direction)99;

            // Act
            var result = point.NextDiagonal(invalidDirection);

            // Assert
            Assert.Equal(point.X, result.X);
            Assert.Equal(point.Y, result.Y);
        }

        [Theory]
        [InlineData(2, 3, Direction.Right)]
        [InlineData(-1, 0, Direction.Left)]
        [InlineData(0, 5, Direction.Up)]
        [InlineData(0, -2, Direction.Down)]
        public void Next_PreservesOtherCoordinate(int startX, int startY, Direction direction)
        {
            // Arrange
            var point = new Point(startX, startY);

            // Act
            var result = point.Next(direction);

            // Assert
            switch (direction)
            {
                case Direction.Right:
                case Direction.Left:
                    Assert.Equal(startY, result.Y);  // Y should not change
                    break;
                case Direction.Up:
                case Direction.Down:
                    Assert.Equal(startX, result.X);  // X should not change
                    break;
            }
        }
    }
}
