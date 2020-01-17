// using Xunit;

// namespace Advent3
// {
//     public class Advent5p2Test
//     {
//     [Fact]
//     public void NotEight1()
//     {
//         Assert.Equal("0", new Advent5p2().getUpdatedIntCode("3,9,8,9,10,9,4,9,99,-1,8", "1"));
//         Assert.Equal("0", new Advent5p2().getUpdatedIntCode("3,9,8,9,10,9,4,9,99,-1,8", "4"));
//         Assert.Equal("0", new Advent5p2().getUpdatedIntCode("3,9,8,9,10,9,4,9,99,-1,8", "10"));
//         Assert.Equal("0", new Advent5p2().getUpdatedIntCode("3,9,8,9,10,9,4,9,99,-1,8", "15"));
//     }
//     [Fact]
//     public void Eight1()
//     {
//         Assert.Equal("1", new Advent5p2().getUpdatedIntCode("3,9,8,9,10,9,4,9,99,-1,8", "8"));
//     }
//     [Fact(Skip = "Remove to run test")]
//     public void NotEight2()
//     {
//         Assert.Equal("0", new Advent5p2().getUpdatedIntCode("3,9,7,9,10,9,4,9,99,-1,8", "1"));
//         Assert.Equal("0", new Advent5p2().getUpdatedIntCode("3,9,7,9,10,9,4,9,99,-1,8", "4"));
//         Assert.Equal("0", new Advent5p2().getUpdatedIntCode("3,9,7,9,10,9,4,9,99,-1,8", "10"));
//         Assert.Equal("0", new Advent5p2().getUpdatedIntCode("3,9,7,9,10,9,4,9,99,-1,8", "15"));

//     }

//     [Fact]
//     public void Eight2()
//     {
//         Assert.Equal("1", new Advent5p2().getUpdatedIntCode("3,9,7,9,10,9,4,9,99,-1,8", "8"));
//     }

//    }
// }