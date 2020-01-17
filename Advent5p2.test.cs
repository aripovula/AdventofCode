using Xunit;

namespace Advent3
{
    public class Advent5p2Test
    {
    [Fact]
    public void NotEight1()
    {
        Assert.Equal("0", new Advent5p2().getUpdatedIntCode("3,9,8,9,10,9,4,9,99,-1,8", "1"));
        Assert.Equal("0", new Advent5p2().getUpdatedIntCode("3,9,8,9,10,9,4,9,99,-1,8", "4"));
        Assert.Equal("0", new Advent5p2().getUpdatedIntCode("3,9,8,9,10,9,4,9,99,-1,8", "10"));
        Assert.Equal("0", new Advent5p2().getUpdatedIntCode("3,9,8,9,10,9,4,9,99,-1,8", "15"));
    }
    [Fact]
    public void Eight1()
    {
        Assert.Equal("1", new Advent5p2().getUpdatedIntCode("3,9,8,9,10,9,4,9,99,-1,8", "8"));
    }
    [Fact]
    public void LessThanEight()
    {
        Assert.Equal("1", new Advent5p2().getUpdatedIntCode("3,9,7,9,10,9,4,9,99,-1,8", "1"));
        Assert.Equal("1", new Advent5p2().getUpdatedIntCode("3,9,7,9,10,9,4,9,99,-1,8", "4"));

    }

    [Fact]
    public void EightOrAbove()
    {
        Assert.Equal("0", new Advent5p2().getUpdatedIntCode("3,9,7,9,10,9,4,9,99,-1,8", "8"));
        Assert.Equal("0", new Advent5p2().getUpdatedIntCode("3,9,7,9,10,9,4,9,99,-1,8", "10"));
        Assert.Equal("0", new Advent5p2().getUpdatedIntCode("3,9,7,9,10,9,4,9,99,-1,8", "15"));
    }

    [Fact]
    public void ZeroToZeroOneForMore()
    {
        Assert.Equal("0", new Advent5p2().getUpdatedIntCode("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", "0"));
        Assert.Equal("1", new Advent5p2().getUpdatedIntCode("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", "1"));
        Assert.Equal("0", new Advent5p2().getUpdatedIntCode("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", "0"));
        Assert.Equal("1", new Advent5p2().getUpdatedIntCode("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", "1"));
    }
    [Fact]
    public void BelowEqualOrAboveEight()
    {
        Assert.Equal("1000", new Advent5p2().getUpdatedIntCode("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", "8"));
        Assert.Equal("1001", new Advent5p2().getUpdatedIntCode("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", "10"));
    }

    [Fact]
    public void ParOneAndPartTwoMainTests()
    {
      Assert.Equal("4601506", new Advent5p2().getUpdatedIntCode("", "1")); // Part 1 test
      Assert.Equal("5525561", new Advent5p2().getUpdatedIntCode("", "5")); // Part 2 test
    }

   }
}