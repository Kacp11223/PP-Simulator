using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 10, 20, 10)] // Below min
    [InlineData(25, 10, 20, 20)] // Above max
    [InlineData(15, 10, 20, 15)] // In range
    public void Limiter_ShouldReturnExpectedValue(int value, int min, int max, int expected)
    {
        // Act
        int result = Validator.Limiter(value, min, max);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(null, 5, 10, '-', "-----")] // Null input, padding to minimum
    [InlineData("", 3, 5, '*', "***")] // Empty string, padding
    [InlineData("abc", 3, 5, '*', "Abc")] // Short string within range, capitalize
    [InlineData("  abc  ", 3, 5, '*', "Abc")] // Short string with whitespaces
    [InlineData("abcdefgh", 3, 5, '*', "abcde")] // String exceeding max length
    [InlineData("Abc", 3, 5, '*', "Abc")] // Already properly formatted
    public void Shortener_ShouldReturnExpectedString(string value, int min, int max, char placeholder, string expected)
    {
        // Act
        string result = Validator.Shortener(value, min, max, placeholder);

        // Assert
        Assert.Equal(expected, result);
    }
}

