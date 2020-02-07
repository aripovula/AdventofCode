using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent3
{
  public class Advent5p2
  {
    public string getUpdatedIntCode(string intCodeFromConsole, string inp)
    {
      int userInput = int.Parse(inp);
      int output = 0;
      List<int> instructionParams;
      List<int> IntCode = getIntCode();
      int nextInstructionStartPoint = 0;
      string nextInstruction;
      int operationCode;

      while (nextInstructionStartPoint < IntCode.Count)
      {
        nextInstruction = getNextInstruction();
        operationCode = int.Parse(nextInstruction.Substring(3, 2));
        if (operationCode == 99) break;

        int digitsQnty = getNextInstructionDigitsQuantity();

        instructionParams = IntCode.GetRange(nextInstructionStartPoint, digitsQnty);

        nextInstructionStartPoint += digitsQnty;

        int p1 = getParameterOneDependingOnMode();
        int p2 = instructionParams.Count > 2 ? getParameterTwoDependingOnMode() : 0;
        int p3 = instructionParams.Count > 3 ? instructionParams[3] : 0;

        switch (OpCodes[operationCode - 1])
        {
          case "opCodeRequires__InputAtP3sumOfP1nP2":
            IntCode[p3] = p1 + p2;
            break;
          case "opCodeRequires__InputAtP3productOfP1nP2":
            IntCode[p3] = p1 * p2;
            break;
          case "opCodeRequires__InputAtPosition":
            IntCode[instructionParams[1]] = userInput;
            break;
          case "opCodeRequires__DisclosingOutput":
            output = IntCode[instructionParams[1]];
            Console.WriteLine("output -  " + output);
            break;
          case "opCodeRequires__JumpIf_P1isNotZero":
            if (p1 > 0) nextInstructionStartPoint = p2;
            break;
          case "opCodeRequires__JumpIf_P1isZero":
            if (p1 == 0) nextInstructionStartPoint = p2;
            break;
          case "ifP1lessThanP2storeOneElseZeroAtP3":
            if (p1 < p2) IntCode[p3] = 1;
            else IntCode[p3] = 0;
            break;
          case "ifP1equalsP2storeOneElseZeroAtP3":
            if (p1 == p2) IntCode[p3] = 1;
            else IntCode[p3] = 0;
            break;
          default:
            Console.WriteLine("Something wrong !");
            break;
        }
      }
      return output.ToString();

      // local (in function) functions
      List<int> getIntCode()
      {
        return intCodeFromConsole.Length > 2
        ? intCodeFromConsole.Split(",").Select(int.Parse).ToList()
        : RawData.dataForAdvent5();
      }

      string getNextInstruction()
      {
        string abcde = IntCode[nextInstructionStartPoint].ToString();
        return "00000".Substring(abcde.Length) + abcde;
      }

      int getNextInstructionDigitsQuantity()
      {
        return (operationCode == 3 || operationCode == 4)
            ? 2 : ((operationCode == 5 || operationCode == 6)
            ? 3 : Math.Min(4, IntCode.Count - nextInstructionStartPoint));
      }

      int getParameterOneDependingOnMode()
      {
        string p1mode = nextInstruction.Substring(2, 1);
        return p1mode == "1" ? instructionParams[1] : IntCode[instructionParams[1]];
      }

      int getParameterTwoDependingOnMode()
      {
        string p2mode = nextInstruction.Substring(1, 1);
        return p2mode == "1" ? instructionParams[2] : IntCode[instructionParams[2]];
      }
    }

    List<string> OpCodes = new List<string> {
      "opCodeRequires__InputAtP3sumOfP1nP2",
      "opCodeRequires__InputAtP3productOfP1nP2",
      "opCodeRequires__InputAtPosition",
      "opCodeRequires__DisclosingOutput",
      "opCodeRequires__JumpIf_P1isNotZero",
      "opCodeRequires__JumpIf_P1isZero",
      "ifP1lessThanP2storeOneElseZeroAtP3",
      "ifP1equalsP2storeOneElseZeroAtP3"
    };
  }
}
