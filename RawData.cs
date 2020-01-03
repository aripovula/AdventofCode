using System.Collections.Generic;

namespace Advent3
{
    public static class RawData
    {
        public static List<string> dataForAdvent3() {
            string wireRouteA = "R75,D30,R83,U83,L12,D49,R71,U7,L72";
            string wireRouteB = "U62,R66,U55,R34,D71,R55,D58,R83";

            return new List<string>{wireRouteA, wireRouteB};
        }
    }
}