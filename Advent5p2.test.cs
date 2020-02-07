using Xunit;

namespace Advent3
{
    public class Advent5p2Test
    {
    [Theory]
    [InlineData("0", "3,9,8,9,10,9,4,9,99,-1,8", "1")]
    [InlineData("0", "3,9,8,9,10,9,4,9,99,-1,8", "4")]
    [InlineData("0", "3,9,8,9,10,9,4,9,99,-1,8", "10")]
    [InlineData("0", "3,9,8,9,10,9,4,9,99,-1,8", "15")]
    public void NotEight(string equals, string intCode, string input)
    {
        Assert.Equal(equals, new Advent5p2().getUpdatedIntCode(intCode, input));
    }
    [Fact]
    public void Eight()
    {
        Assert.Equal("1", new Advent5p2().getUpdatedIntCode("3,9,8,9,10,9,4,9,99,-1,8", "8"));
    }
    [Theory]
    [InlineData("1", "3,9,7,9,10,9,4,9,99,-1,8", "1")]
    [InlineData("1", "3,9,7,9,10,9,4,9,99,-1,8", "4")]
    public void LessThanEight(string equals, string intCode, string input)
    {
        Assert.Equal(equals, new Advent5p2().getUpdatedIntCode(intCode, input));
    }

    [Theory]
    [InlineData("0", "3,9,7,9,10,9,4,9,99,-1,8", "8")]
    [InlineData("0", "3,9,7,9,10,9,4,9,99,-1,8", "10")]
    [InlineData("0", "3,9,7,9,10,9,4,9,99,-1,8", "15")]
    public void EightOrAbove(string equals, string intCode, string input)
    {
        Assert.Equal(equals, new Advent5p2().getUpdatedIntCode(intCode, input));
    }

    [Theory]
    [InlineData("0", "3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", "0")]
    [InlineData("1", "3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", "1")]
    [InlineData("0", "3,3,1105,-1,9,1101,0,0,12,4,12,99,1", "0")]
    [InlineData("1", "3,3,1105,-1,9,1101,0,0,12,4,12,99,1", "1")]
    public void ZeroToZeroOneForMore(string equals, string intCode, string input)
    {
        Assert.Equal(equals, new Advent5p2().getUpdatedIntCode(intCode, input));
    }
    [Theory]
    [InlineData("1000", "3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", "8")]
    [InlineData("1001", "3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", "10")]

    public void BelowEqualOrAboveEight(string equals, string intCode, string input)
    {
        Assert.Equal(equals, new Advent5p2().getUpdatedIntCode(intCode, input));
    }

    [Theory]
    [InlineData("4601506", "", "1")]
    [InlineData("5525561", "", "5")]
    public void ParOneAndPartTwoMainTests(string equals, string intCode, string input)
    {
      Assert.Equal(equals, new Advent5p2().getUpdatedIntCode(intCode, input));
    }

   }
}