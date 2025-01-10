using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xunit;
using Simulator.Maps;
using System;

namespace Simulator.Tests.Maps
{
    public class SmallSquareMapTests
    {
        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void Constructor_ValidSize_CreatesMap(int size)
        {
            // Act
            var map = new SmallSquareMap(size);

            // Assert
            Assert.Equal(size, map.Size);
        }

        [Theory]
        [InlineData(4)]  // too small
        [InlineData(21)] // too large
        public void Constructor_InvalidSize_ThrowsArgumentOutOfRangeException(int size)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
        }

        [Theory]
        [InlineData(5, 0, 0)]     // top-left corner
        [InlineData(5, 4, 4)]     // bottom-right corner
        [InlineData(5, 2, 2)]     // center
        public void Exist_PointsWithinBoundary_ReturnsTrue(int size, int x, int y)
        {
            // Arrange
            var map = new SmallSquareMap(size);
            var point = new Point(x, y);

            // Act
            bool exists = map.Exist(point);

            // Assert
            Assert.True(exists);
        }

        [Theory]
        [InlineData(5, -1, 0)]    // left of boundary
        [InlineData(5, 0, -1)]    // above boundary
        [InlineData(5, 5, 0)]     // right of boundary
        [InlineData(5, 0, 5)]     // below boundary
        public void Exist_PointsOutsideBoundary_ReturnsFalse(int size, int x, int y)
        {
            // Arrange
            var map = new SmallSquareMap(size);
            var point = new Point(x, y);

            // Act
            bool exists = map.Exist(point);

            // Assert
            Assert.False(exists);
        }

        [Theory]
        [InlineData(5, 2, 2, Direction.Up, 2, 1)]    // Move up
        [InlineData(5, 2, 2, Direction.Down, 2, 3)]  // Move down
        [InlineData(5, 2, 2, Direction.Right, 3, 2)] // Move right
        [InlineData(5, 2, 2, Direction.Left, 1, 2)]  // Move left
        public void Next_ValidMove_ReturnsNewPosition(int size, int startX, int startY,
            Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var map = new SmallSquareMap(size);
            var startPoint = new Point(startX, startY);

            // Act
            var result = map.Next(startPoint, direction);

            // Assert
            Assert.Equal(new Point(expectedX, expectedY), result);
        }

        [Theory]
        [InlineData(5, 0, 0, Direction.Up)]    // Try to move up from top edge
        [InlineData(5, 0, 0, Direction.Left)]  // Try to move left from left edge
        [InlineData(5, 4, 4, Direction.Down)]  // Try to move down from bottom edge
        [InlineData(5, 4, 4, Direction.Right)] // Try to move right from right edge
        public void Next_InvalidMove_ReturnsSamePosition(int size, int startX, int startY, Direction direction)
        {
            // Arrange
            var map = new SmallSquareMap(size);
            var startPoint = new Point(startX, startY);

            // Act
            var result = map.Next(startPoint, direction);

            // Assert
            Assert.Equal(startPoint, result);
        }

        [Theory]
        [InlineData(5, 2, 2, Direction.Right, 3, 1)] // Move right+up
        [InlineData(5, 2, 2, Direction.Left, 1, 1)]  // Move left+up
        [InlineData(5, 2, 2, Direction.Right, 3, 3)] // Move right+down
        [InlineData(5, 2, 2, Direction.Left, 1, 3)]  // Move left+down
        public void NextDiagonal_ValidMove_ReturnsNewPosition(int size, int startX, int startY,
            Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var map = new SmallSquareMap(size);
            var startPoint = new Point(startX, startY);

            // Act
            var result = map.NextDiagonal(startPoint, direction);

            // Assert
            Assert.Equal(new Point(expectedX, expectedY), result);
        }

        [Theory]
        [InlineData(5, 0, 0, Direction.Right)]  // Try to move right+up from top-left corner
        [InlineData(5, 4, 0, Direction.Right)]  // Try to move right+up from top-right corner
        [InlineData(5, 0, 4, Direction.Left)]   // Try to move left+down from bottom-left corner
        [InlineData(5, 4, 4, Direction.Right)]  // Try to move right+down from bottom-right corner
        public void NextDiagonal_InvalidMove_ReturnsSamePosition(int size, int startX, int startY, Direction direction)
        {
            // Arrange
            var map = new SmallSquareMap(size);
            var startPoint = new Point(startX, startY);

            // Act
            var result = map.NextDiagonal(startPoint, direction);

            // Assert
            Assert.Equal(startPoint, result);
        }
    }
}