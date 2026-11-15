namespace GradeTracker.Tests;

using Xunit;

public class GradeTrackerTests
{
    [Fact]
    public void CalculateAverage_ReturnsCorrectAverage()
    {
        // Arrange
        double[] scores = { 20, 60, 100 };

        // Act
        double result = Program.CalculateAverage(scores);

        // Assert
        Assert.Equal(60, result);
    }

    [Fact]
    public void FindHighestScore_ReturnsHighest()
    {
        // Arrange
        double[] scores = { 20, 60, 100 };

        // Act
        double result = Program.FindHighestScore(scores);

        // Assert
        Assert.Equal(100, result);
    }

    [Fact]
    public void FindLowestScore_ReturnsLowest()
    {
        // Arrange
        double[] scores = { 20, 60, 100 };

        // Act
        double result = Program.FindLowestScore(scores);

        // Assert
        Assert.Equal(20, result);
    }

    [Theory]
    [InlineData(100, "A")]
    [InlineData(95, "A")]
    [InlineData(80, "A")]
    [InlineData(79, "B+")]
    [InlineData(70, "B+")]
    [InlineData(69, "B")]
    [InlineData(60, "B")]
    [InlineData(59, "C")]
    [InlineData(50, "C")]
    [InlineData(49, "D")]
    [InlineData(0, "D")]
    public void GetGrade_ReturnsCorrectGrade(double score, string expected)
    {
        // Act
        string result = Program.GetGrade(score);

        // Assert
        Assert.Equal(expected, result);
    }
}