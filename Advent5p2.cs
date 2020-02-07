using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent3
{
  public class Advent5p2
  {
    List<int> IntCode;
    int nextInstructionStartPoint = 0;
    public string getUpdatedIntCode(string intCodeFromConsole, string inp)
    {
      int userInput = int.Parse(inp);
      int output = 0;
      List<int> instructionParams;
      IntCode = getIntCode();
      string nextInstruction;
      int operationCode;
      int p1, p2, p3;

      while (nextInstructionStartPoint < IntCode.Count)
      {
        nextInstruction = getNextInstruction();
        operationCode = int.Parse(nextInstruction.Substring(3, 2));
        if (operationCode == 99) break;

        int digitsQnty = getNextInstructionDigitsQuantity();

        instructionParams = IntCode.GetRange(nextInstructionStartPoint, digitsQnty);

        nextInstructionStartPoint += digitsQnty;

        if (opCodeRequiresInputAtPosition()) IntCode[instructionParams[1]] = userInput;

        if (opCodeRequiresDisclosingOutput())
        {
          output = IntCode[instructionParams[1]];
          Console.WriteLine("output -  " + output);
        }
        if (instructionParams.Count > 2)
        {
          p1 = getParameterOneDependingOnMode();
          p2 = getParameterTwoDependingOnMode();
          if (opCodeRequiresToJumpIf_P1isNotZero()) nextInstructionStartPoint = p2;
          if (opCodeRequiresToJumpIf_P1isZero()) nextInstructionStartPoint = p2;

          p3 = instructionParams.Count > 3 ? instructionParams[3] : 0;
          if (operationCode == 7 && instructionParams.Count > 3)
            ifP1lessThanP2storeOneOtherwiseZeroAtPositionThree();

          if (operationCode == 8 && instructionParams.Count > 3)
          {
            ifP1equalsP2storeOneOtherwiseZeroAtPositionThree();
          }
          if (operationCode < 3 && instructionParams.Count > 3)
          {
            if (opCodeRequiresInputAtP3sumOfP1nP2()) IntCode[p3] = p1 + p2;
            if (opCodeRequiresInputAtP3productOfP1nP2()) IntCode[p3] = p1 * p2;
          }

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
        return (operationCode == 3 || operationCode == 4) ? 2
              : ((operationCode == 5 || operationCode == 6) ? 3 : Math.Min(4, IntCode.Count - nextInstructionStartPoint));
      }

      bool opCodeRequiresInputAtPosition()
      {
        return operationCode == 3 && instructionParams.Count > 1;
      }

      bool opCodeRequiresDisclosingOutput()
      {
        return operationCode == 4 && instructionParams.Count > 1 && IntCode.Count > instructionParams[1];
      }

      bool opCodeRequiresToJumpIf_P1isNotZero()
      {
        return operationCode == 5 && instructionParams.Count > 2 && p1 > 0;
      }

      bool opCodeRequiresToJumpIf_P1isZero()
      {
        return operationCode == 6 && instructionParams.Count > 2 && p1 == 0;
      }

      bool opCodeRequiresInputAtP3sumOfP1nP2()
      {
        return operationCode == 1;
      }

      bool opCodeRequiresInputAtP3productOfP1nP2()
      {
        return operationCode == 2;
      }

      int getParameterOneDependingOnMode()
      {
        return nextInstruction.Substring(2, 1) == "1" ? instructionParams[1] : IntCode[instructionParams[1]];
      }

      int getParameterTwoDependingOnMode()
      {
        return nextInstruction.Substring(1, 1) == "1" ? instructionParams[2] : IntCode[instructionParams[2]];
      }

      void ifP1lessThanP2storeOneOtherwiseZeroAtPositionThree()
      {
        if (p1 < p2) IntCode[p3] = 1;
        else IntCode[p3] = 0;
      }

      void ifP1equalsP2storeOneOtherwiseZeroAtPositionThree()
      {
        if (p1 == p2) IntCode[p3] = 1;
        else IntCode[p3] = 0;
      }

    }

  }
}