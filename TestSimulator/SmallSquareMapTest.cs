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
            Assert.Equal(size, map.SizeX);
            Assert.Equal(size, map.SizeY);
        }

        [Theory]
        [InlineData(4)]  // za mały
        [InlineData(21)] // za duży
        public void Constructor_InvalidSize_ThrowsException(int size)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void Next_PointWithinBounds_ReturnsNextPoint(int size)
        {
            // Arrange
            var map = new SmallSquareMap(size);
            var point = new Point(1, 1);

            // Act
            var result = map.Next(point, Direction.Right);

            // Assert
            Assert.Equal(new Point(2, 1), result);
        }

        [Fact]
        public void Next_PointAtBoundary_ReturnsSamePoint()
        {
            // Arrange
            var map = new SmallSquareMap(5);
            var point = new Point(4, 4);

            // Act
            var result = map.Next(point, Direction.Right);

            // Assert
            Assert.Equal(point, result);
        }
    }
}