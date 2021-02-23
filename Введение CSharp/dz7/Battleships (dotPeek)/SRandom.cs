// Decompiled with JetBrains decompiler
// Type: Battleships.SRandom
// Assembly: Battleships, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C61D177D-AFED-44BB-AC54-28596A38709E
// Assembly location: C:\Users\kozlovma\Downloads\Telegram Desktop\Battleships.exe

using System;

namespace Battleships
{
  internal static class SRandom
  {
    private static readonly Random R = new Random();
    private static readonly object L = new object();

    public static ushort Next(int min, int max)
    {
      lock (SRandom.L)
        return (ushort) SRandom.R.Next(min, max);
    }
  }
}
