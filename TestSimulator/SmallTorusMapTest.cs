using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallTorusMapTests
{
    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    public void Constructor_ValidSize_CreatesMap(int size)
    {
        // Act
        var map = new SmallTorusMap(size);

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
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallTorusMap(size));
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    public void Next_PointWithinBounds_ReturnsNextPoint(int size)
    {
        // Arrange
        var map = new SmallTorusMap(size);
        var point = new Point(1, 1);

        // Act
        var result = map.Next(point, Direction.Right);

        // Assert
        Assert.Equal(new Point(2, 1), result);
    }

    [Theory]
    [InlineData(5)]
    public void Next_PointAtBoundary_WrapsAround(int size)
    {
        // Arrange
        var map = new SmallTorusMap(size);
        var point = new Point(size - 1, size - 1);

        // Act
        var result = map.Next(point, Direction.Right);

        // Assert
        Assert.Equal(new Point(0, size - 1), result);
    }
}