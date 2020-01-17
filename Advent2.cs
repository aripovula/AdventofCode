using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent3
{
    public class Advent2 {
        int position = 0;
        List<int> IntCode;
        List<int> getASet(int pos) {
            return IntCode.GetRange(pos, Math.Min(4, IntCode.Count - pos));
        }

        public List<int> getUpdatedIntCode(string intCode) {
            IntCode = intCode.Length > 2
             ? new List<string>(intCode.Split(",")).Select(int.Parse).ToList()
             : RawData.dataForAdvent2();


            while(position < IntCode.Count) {
                var aSet = getASet(position);
                if (aSet[0] == 99) break;
                position +=4;
                if (aSet.Count==4) {
                    if (aSet[0] == 1) IntCode[aSet[3]] = IntCode[aSet[1]] + IntCode[aSet[2]];
                    if (aSet[0] == 2) IntCode[aSet[3]] = IntCode[aSet[1]] * IntCode[aSet[2]];
                }
            }
            return  IntCode;
        }
   }
}