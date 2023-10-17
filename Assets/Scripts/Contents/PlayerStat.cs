using System;
using UnityEngine;

namespace Contents
{
  public class PlayerStat : Stat
  {
    public int exp;
    public int gold;

    private void Reset()
    {
      level = 1;
      hp = 100;
      maxHp = 100;
      attack = 10;
      defense = 5;
      moveSpeed = 5f;
      exp = 0;
      gold = 0;
    }
  }
}