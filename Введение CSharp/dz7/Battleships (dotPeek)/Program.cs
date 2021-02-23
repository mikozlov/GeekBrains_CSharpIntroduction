// Decompiled with JetBrains decompiler
// Type: Battleships.Program
// Assembly: Battleships, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C61D177D-AFED-44BB-AC54-28596A38709E
// Assembly location: C:\Users\kozlovma\Downloads\Telegram Desktop\Battleships.exe

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Battleships
{
  internal static class Program
  {
    private static bool _playerOneWon;
    private static bool _playerTwoWon;

    public static void Main(string[] args)
    {
      Console.OutputEncoding = Encoding.UTF8;
      bool flag = true;
      ushort[,] battleshipField1 = Program.CreateBattleshipField(Program.ZeroTwoDimMatrix((ushort) 10, (ushort) 10));
      ushort[,] battleshipField2 = Program.CreateBattleshipField(Program.ZeroTwoDimMatrix((ushort) 10, (ushort) 10));
      ushort[,] myTargets1 = Program.ZeroTwoDimMatrix((ushort) 10, (ushort) 10);
      ushort[,] myTargets2 = Program.ZeroTwoDimMatrix((ushort) 10, (ushort) 10);
      for (; !Program._playerOneWon && !Program._playerTwoWon; Program._playerTwoWon = Program.IsWin(battleshipField1))
      {
        Console.Clear();
        Program.ColorfulWrite(new Dictionary<object, ConsoleColor?>()
        {
          {
            (object) "Ready player ",
            new ConsoleColor?()
          },
          {
            flag ? (object) "one" : (object) "two",
            new ConsoleColor?(ConsoleColor.DarkCyan)
          }
        });
        Console.WriteLine();
        Program.CheckReady();
        if (flag)
          Program.Shot(ref myTargets1, ref battleshipField2, battleshipField1);
        else
          Program.Shot(ref myTargets2, ref battleshipField1, battleshipField2);
        flag = !flag;
        Program._playerOneWon = Program.IsWin(battleshipField2);
      }
      Program.ColorfulWrite(new Dictionary<object, ConsoleColor?>()
      {
        {
          (object) "Congratulations, Player ",
          new ConsoleColor?()
        },
        {
          Program._playerOneWon ? (object) "One" : (object) "Two",
          new ConsoleColor?(ConsoleColor.DarkCyan)
        },
        {
          (object) "! You won!",
          new ConsoleColor?()
        }
      });
      Console.WriteLine();
      Console.WriteLine();
      Program.ColorfulWrite(new Dictionary<object, ConsoleColor?>()
      {
        {
          (object) "Press ",
          new ConsoleColor?()
        },
        {
          (object) "<Enter>",
          new ConsoleColor?(ConsoleColor.DarkCyan)
        },
        {
          (object) " to close application...",
          new ConsoleColor?()
        }
      });
      Console.WriteLine();
      Console.Read();
    }

    private static void CheckReady()
    {
      if (Program.GetBoolFromUser("Are you ready?"))
        return;
      Program.CheckReady();
    }

    private static void ColorfulWrite(Dictionary<object, ConsoleColor?> dataDictionary)
    {
      foreach (KeyValuePair<object, ConsoleColor?> data in dataDictionary)
      {
        ConsoleColor? nullable = data.Value;
        if (!nullable.HasValue)
        {
          Console.Write(data.Key);
        }
        else
        {
          nullable = data.Value;
          Console.ForegroundColor = nullable.Value;
          Console.Write(data.Key);
          Console.ResetColor();
        }
      }
    }

    private static bool GetBoolFromUser(string textRequest)
    {
      Console.WriteLine(textRequest);
      Program.ColorfulWrite(new Dictionary<object, ConsoleColor?>()
      {
        {
          (object) "Enter ",
          new ConsoleColor?()
        },
        {
          (object) "Y",
          new ConsoleColor?(ConsoleColor.DarkCyan)
        },
        {
          (object) " if yes or ",
          new ConsoleColor?()
        },
        {
          (object) "N",
          new ConsoleColor?(ConsoleColor.DarkCyan)
        },
        {
          (object) " if no",
          new ConsoleColor?()
        }
      });
      Console.WriteLine();
      switch (Console.ReadLine().ToLower())
      {
        case "n":
        case "no":
        case "н":
        case "нет":
          return false;
        case "y":
        case "yes":
        case "д":
        case "да":
          return true;
        default:
          Console.WriteLine("Invalid input. Try again");
          return Program.GetBoolFromUser(textRequest);
      }
    }

    private static ushort[,] ZeroTwoDimMatrix(ushort dim0, ushort dim1)
    {
      ushort[,] numArray = new ushort[(int) dim0, (int) dim1];
      for (int index1 = 0; index1 < numArray.GetUpperBound(0); ++index1)
      {
        for (int index2 = 0; index2 < numArray.GetUpperBound(1); ++index2)
          numArray[index1, index2] = (ushort) 0;
      }
      return numArray;
    }

    private static ushort[,] CreateBattleshipField(ushort[,] field)
    {
      try
      {
        field = Program.PlaceShip((ushort) 4, field);
        field = Program.PlaceShip((ushort) 3, field);
        field = Program.PlaceShip((ushort) 3, field);
        field = Program.PlaceShip((ushort) 2, field);
        field = Program.PlaceShip((ushort) 2, field);
        field = Program.PlaceShip((ushort) 2, field);
        field = Program.PlaceShip((ushort) 1, field);
        field = Program.PlaceShip((ushort) 1, field);
        field = Program.PlaceShip((ushort) 1, field);
        field = Program.PlaceShip((ushort) 1, field);
        return field;
      }
      catch (IndexOutOfRangeException ex)
      {
        return Program.CreateBattleshipField(Program.ZeroTwoDimMatrix((ushort) 10, (ushort) 10));
      }
    }

    private static ushort[,] PlaceShip(ushort shipSize, ushort[,] field)
    {
      bool flag = SRandom.Next(1, 100) > (ushort) 50;
      ushort num1 = flag ? SRandom.Next(0, 9) : SRandom.Next(0, 10 - (int) shipSize);
      ushort num2 = flag ? SRandom.Next(0, 10 - (int) shipSize) : SRandom.Next(0, 9);
      if ((ushort) 1 == field[(int) num2, (int) num1] || num2 != (ushort) 0 && (ushort) 1 == field[(int) num2 - 1, (int) num1] || num1 != (ushort) 0 && (ushort) 1 == field[(int) num2, (int) num1 - 1] || num2 != (ushort) 0 && num1 != (ushort) 0 && (ushort) 1 == field[(int) num2 - 1, (int) num1 - 1])
        return Program.PlaceShip(shipSize, field);
      if (!flag)
      {
        for (int index = (int) num1; index < (int) num1 + (int) shipSize; ++index)
        {
          if (num2 != (ushort) 0 && (ushort) 1 == field[(int) num2 - 1, index] || (ushort) 9 != num2 && (ushort) 1 == field[(int) num2 + 1, index])
            return Program.PlaceShip(shipSize, field);
        }
        if (10 != (int) num1 + (int) shipSize && (ushort) 1 == field[(int) num2, (int) num1 + (int) shipSize] || (ushort) 9 != num2 && num1 != (ushort) 0 && (ushort) 1 == field[(int) num2 + 1, (int) num1 - 1] || (num2 != (ushort) 0 && 10 != (int) num1 + (int) shipSize && (ushort) 1 == field[(int) num2 - 1, (int) num1 + (int) shipSize + 1] || (ushort) 9 != num2 && 10 != (int) num1 + (int) shipSize && (ushort) 1 == field[(int) num2 + 1, (int) num1 + (int) shipSize + 1]))
          return Program.PlaceShip(shipSize, field);
        for (int index = (int) num1; index < (int) num1 + (int) shipSize; ++index)
          field[(int) num2, index] = (ushort) 1;
      }
      else
      {
        for (int index = (int) num2; index < (int) num2 + (int) shipSize; ++index)
        {
          if (num1 != (ushort) 0 && (ushort) 1 == field[index, (int) num1 - 1] || (ushort) 9 != num1 && (ushort) 1 == field[index, (int) num1 + 1])
            return Program.PlaceShip(shipSize, field);
        }
        if (10 != (int) num2 + (int) shipSize && (ushort) 1 == field[(int) num2 + (int) shipSize, (int) num1] || 10 != (int) num2 + (int) shipSize && num1 != (ushort) 0 && (ushort) 1 == field[(int) num2 + (int) shipSize + 1, (int) num1 - 1] || (num2 != (ushort) 0 && (ushort) 9 != num1 && (ushort) 1 == field[(int) num2 - 1, (int) num1 + 1] || 10 != (int) num2 + (int) shipSize && (ushort) 9 != num1 && (ushort) 1 == field[(int) num2 + (int) shipSize + 1, (int) num1 + 1]))
          return Program.PlaceShip(shipSize, field);
        for (int index = (int) num2; index < (int) num2 + (int) shipSize; ++index)
          field[index, (int) num1] = (ushort) 1;
      }
      return field;
    }

    private static bool IsWin(ushort[,] otherPlayerShips)
    {
      for (int index1 = 0; index1 < 10; ++index1)
      {
        for (int index2 = 0; index2 < 10; ++index2)
        {
          if ((ushort) 1 == otherPlayerShips[index1, index2])
            return false;
        }
      }
      return true;
    }

    private static void PrintFields(ushort[,] ships, ushort[,] targets)
    {
      Dictionary<object, ConsoleColor?> dataDictionary = new Dictionary<object, ConsoleColor?>();
      dataDictionary.Add((object) Program.PadBoth("#", 3), new ConsoleColor?(ConsoleColor.DarkCyan));
      dataDictionary.Add((object) Program.PadBoth("A", 3), new ConsoleColor?(ConsoleColor.DarkCyan));
      dataDictionary.Add((object) Program.PadBoth("B", 3), new ConsoleColor?(ConsoleColor.DarkCyan));
      dataDictionary.Add((object) Program.PadBoth("C", 3), new ConsoleColor?(ConsoleColor.DarkCyan));
      dataDictionary.Add((object) Program.PadBoth("D", 3), new ConsoleColor?(ConsoleColor.DarkCyan));
      dataDictionary.Add((object) Program.PadBoth("E", 3), new ConsoleColor?(ConsoleColor.DarkCyan));
      dataDictionary.Add((object) Program.PadBoth("F", 3), new ConsoleColor?(ConsoleColor.DarkCyan));
      dataDictionary.Add((object) Program.PadBoth("G", 3), new ConsoleColor?(ConsoleColor.DarkCyan));
      dataDictionary.Add((object) Program.PadBoth("H", 3), new ConsoleColor?(ConsoleColor.DarkCyan));
      dataDictionary.Add((object) Program.PadBoth("I", 3), new ConsoleColor?(ConsoleColor.DarkCyan));
      dataDictionary.Add((object) Program.PadBoth("J", 3), new ConsoleColor?(ConsoleColor.DarkCyan));
      Console.Clear();
      Console.WriteLine("Legend:");
      Program.ColorfulWrite(new Dictionary<object, ConsoleColor?>()
      {
        {
          (object) Program.PadBoth("", 3),
          new ConsoleColor?()
        },
        {
          (object) " -- Unknown",
          new ConsoleColor?()
        }
      });
      Console.WriteLine();
      Program.ColorfulWrite(new Dictionary<object, ConsoleColor?>()
      {
        {
          (object) Program.PadBoth("~", 3),
          new ConsoleColor?()
        },
        {
          (object) " -- Clear water",
          new ConsoleColor?()
        }
      });
      Console.WriteLine();
      Program.ColorfulWrite(new Dictionary<object, ConsoleColor?>()
      {
        {
          (object) Program.PadBoth("[ ]", 3),
          new ConsoleColor?(ConsoleColor.DarkGreen)
        },
        {
          (object) " -- Player ships",
          new ConsoleColor?()
        }
      });
      Console.WriteLine();
      Program.ColorfulWrite(new Dictionary<object, ConsoleColor?>()
      {
        {
          (object) Program.PadBoth("[X]", 3),
          new ConsoleColor?(ConsoleColor.DarkRed)
        },
        {
          (object) " -- Hits/Destroyed ships",
          new ConsoleColor?()
        }
      });
      Console.WriteLine();
      Program.ColorfulWrite(new Dictionary<object, ConsoleColor?>()
      {
        {
          (object) Program.PadBoth("O", 3),
          new ConsoleColor?()
        },
        {
          (object) " -- Miss",
          new ConsoleColor?()
        }
      });
      Console.WriteLine();
      Console.WriteLine();
      Program.ColorfulWrite(dataDictionary);
      Console.Write(Program.PadBoth("", 6));
      Program.ColorfulWrite(dataDictionary);
      Console.WriteLine();
      for (uint index1 = 0; index1 < 10U; ++index1)
      {
        Program.ColorfulWrite(new Dictionary<object, ConsoleColor?>()
        {
          {
            (object) Program.PadBoth(string.Format("{0}", (object) (uint) ((int) index1 + 1)), 3),
            new ConsoleColor?(ConsoleColor.DarkCyan)
          }
        });
        for (uint index2 = 0; index2 < 10U; ++index2)
        {
          switch (ships[(int) index1, (int) index2])
          {
            case 0:
              Program.ColorfulWrite(new Dictionary<object, ConsoleColor?>()
              {
                {
                  (object) Program.PadBoth("~", 3),
                  new ConsoleColor?()
                }
              });
              break;
            case 1:
              Program.ColorfulWrite(new Dictionary<object, ConsoleColor?>()
              {
                {
                  (object) Program.PadBoth("[ ]", 3),
                  new ConsoleColor?(ConsoleColor.DarkGreen)
                }
              });
              break;
            case 2:
              Program.ColorfulWrite(new Dictionary<object, ConsoleColor?>()
              {
                {
                  (object) Program.PadBoth("[X]", 3),
                  new ConsoleColor?(ConsoleColor.DarkRed)
                }
              });
              break;
            case 3:
              Program.ColorfulWrite(new Dictionary<object, ConsoleColor?>()
              {
                {
                  (object) Program.PadBoth("O", 3),
                  new ConsoleColor?()
                }
              });
              break;
            default:
              throw new Exception("Undefined filed filler");
          }
        }
        Console.Write(Program.PadBoth("", 6));
        Program.ColorfulWrite(new Dictionary<object, ConsoleColor?>()
        {
          {
            (object) Program.PadBoth(string.Format("{0}", (object) (uint) ((int) index1 + 1)), 3),
            new ConsoleColor?(ConsoleColor.DarkCyan)
          }
        });
        for (uint index2 = 0; index2 < 10U; ++index2)
        {
          switch (targets[(int) index1, (int) index2])
          {
            case 0:
              Program.ColorfulWrite(new Dictionary<object, ConsoleColor?>()
              {
                {
                  (object) Program.PadBoth("~", 3),
                  new ConsoleColor?()
                }
              });
              break;
            case 2:
              Program.ColorfulWrite(new Dictionary<object, ConsoleColor?>()
              {
                {
                  (object) Program.PadBoth("[X]", 3),
                  new ConsoleColor?(ConsoleColor.DarkRed)
                }
              });
              break;
            case 3:
              Program.ColorfulWrite(new Dictionary<object, ConsoleColor?>()
              {
                {
                  (object) Program.PadBoth("O", 3),
                  new ConsoleColor?()
                }
              });
              break;
            default:
              throw new Exception("Undefined filed filler");
          }
        }
        Console.WriteLine();
      }
    }

    private static string PadBoth(string source, int length)
    {
      int totalWidth = (length - source.Length) / 2 + source.Length;
      return source.PadLeft(totalWidth).PadRight(length);
    }

    private static void Shot(
      ref ushort[,] myTargets,
      ref ushort[,] otherPlayerShips,
      ushort[,] myShips)
    {
      Program.PrintFields(myShips, myTargets);
      ushort[] shotCoordinates = Program.GetShotCoordinates();
      if (myTargets[(int) shotCoordinates[0], (int) shotCoordinates[1]] != (ushort) 0)
      {
        Console.WriteLine("You have already fired at this position");
        Thread.Sleep(2000);
        Program.Shot(ref myTargets, ref otherPlayerShips, myShips);
      }
      if ((ushort) 1 == otherPlayerShips[(int) shotCoordinates[0], (int) shotCoordinates[1]])
      {
        myTargets[(int) shotCoordinates[0], (int) shotCoordinates[1]] = (ushort) 2;
        otherPlayerShips[(int) shotCoordinates[0], (int) shotCoordinates[1]] = (ushort) 2;
        if (Program.IsWin(otherPlayerShips))
          return;
        Program.Shot(ref myTargets, ref otherPlayerShips, myShips);
      }
      else
      {
        if (otherPlayerShips[(int) shotCoordinates[0], (int) shotCoordinates[1]] != (ushort) 0)
          return;
        myTargets[(int) shotCoordinates[0], (int) shotCoordinates[1]] = (ushort) 3;
        otherPlayerShips[(int) shotCoordinates[0], (int) shotCoordinates[1]] = (ushort) 3;
        Program.ColorfulWrite(new Dictionary<object, ConsoleColor?>()
        {
          {
            (object) "You ",
            new ConsoleColor?()
          },
          {
            (object) "miss",
            new ConsoleColor?(ConsoleColor.DarkCyan)
          }
        });
        Console.WriteLine();
        Thread.Sleep(2000);
      }
    }

    private static ushort[] GetShotCoordinates()
    {
      ushort[] numArray = new ushort[2];
      Program.ColorfulWrite(new Dictionary<object, ConsoleColor?>()
      {
        {
          (object) "Enter shot coordinates (ex. ",
          new ConsoleColor?()
        },
        {
          (object) "A7",
          new ConsoleColor?(ConsoleColor.DarkCyan)
        },
        {
          (object) ")",
          new ConsoleColor?()
        }
      });
      Console.WriteLine();
      char[] charArray = Console.ReadLine().ToLower().ToCharArray();
      switch (charArray[0])
      {
        case 'a':
          numArray[1] = (ushort) 0;
          break;
        case 'b':
          numArray[1] = (ushort) 1;
          break;
        case 'c':
          numArray[1] = (ushort) 2;
          break;
        case 'd':
          numArray[1] = (ushort) 3;
          break;
        case 'e':
          numArray[1] = (ushort) 4;
          break;
        case 'f':
          numArray[1] = (ushort) 5;
          break;
        case 'g':
          numArray[1] = (ushort) 6;
          break;
        case 'h':
          numArray[1] = (ushort) 7;
          break;
        case 'i':
          numArray[1] = (ushort) 8;
          break;
        case 'j':
          numArray[1] = (ushort) 9;
          break;
        default:
          Console.WriteLine("Invalid input. Try again");
          return Program.GetShotCoordinates();
      }
      switch (charArray.Length)
      {
        case 2:
          switch (charArray[1])
          {
            case '1':
              numArray[0] = (ushort) 0;
              break;
            case '2':
              numArray[0] = (ushort) 1;
              break;
            case '3':
              numArray[0] = (ushort) 2;
              break;
            case '4':
              numArray[0] = (ushort) 3;
              break;
            case '5':
              numArray[0] = (ushort) 4;
              break;
            case '6':
              numArray[0] = (ushort) 5;
              break;
            case '7':
              numArray[0] = (ushort) 6;
              break;
            case '8':
              numArray[0] = (ushort) 7;
              break;
            case '9':
              numArray[0] = (ushort) 8;
              break;
            default:
              Console.WriteLine("Invalid input. Try again");
              return Program.GetShotCoordinates();
          }
          break;
        case 3:
          if ('1' == charArray[1] && '0' == charArray[2])
          {
            numArray[0] = (ushort) 9;
            break;
          }
          goto default;
        default:
          Console.WriteLine("Invalid input. Try again");
          return Program.GetShotCoordinates();
      }
      return numArray;
    }
  }
}
