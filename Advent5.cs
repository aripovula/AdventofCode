using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent3
{
  public class Advent5
  {
    public List<int> getUpdatedIntCode(string intCode, string inp)
    {
      int position = 0;
      int input = int.Parse(inp);
      List<int> IntCode = intCode.Length > 2
       ? new List<string>(intCode.Split(",")).Select(int.Parse).ToList()
       : RawData.dataForAdvent5();

      while (position < IntCode.Count)
      {
        string abcde = IntCode[position].ToString();
        abcde = "00000".Substring(abcde.Length) + abcde;
        int opCode = int.Parse(abcde.Substring(3, 2));
        if (opCode == 99) break;
        int qnty = opCode < 3 ? Math.Min(4, IntCode.Count - position) : 2;
        var aSet = IntCode.GetRange(position, qnty);
        position += qnty;
        if (opCode > 2)
        {
          if (opCode == 3) IntCode[aSet[1]] = input;
          if (opCode == 4) Console.WriteLine("output -  " + IntCode[aSet[1]]);
        }
        else if (aSet.Count > 3)
        {
          int p1 = abcde.Substring(2, 1) == "1" ? aSet[1] : IntCode[aSet[1]];
          int p2 = abcde.Substring(1, 1) == "1" ? aSet[2] : IntCode[aSet[2]];
          int p3 = abcde.Substring(0, 1) == "1" ? aSet[3] : IntCode[aSet[3]];
          if (opCode == 1) IntCode[aSet[3]] = p1 + p2;
          if (opCode == 2) IntCode[aSet[3]] = p1 * p2;
        }
      }
      return IntCode;
    }
  }
}