using System;
using System.Collections.Generic;
using System.Linq;
using Manager;

namespace Data
{
  [Serializable]
  public class Stat
  {
    public int level;
    public int hp;
    public int attack;
  }

  public class StatData : ILoader<int, Stat>
  {
    public List<Stat> stats = new List<Stat>();
    
    public Dictionary<int, Stat> MakeDict()
    {
      return stats.ToDictionary(x => x.level, x => x);
    }

  }
}