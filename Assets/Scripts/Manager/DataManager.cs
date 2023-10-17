using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;

namespace Manager
{
  public interface ILoader<TKey, TValue>
  {
    Dictionary<TKey, TValue> MakeDict();
  }

  public class DataManager : IInitialable
  {
    public Dictionary<int, Stat> StatDict { get; private set; } = new();

    public void Init()
    {
      var textAsset = Managers.Resource.Load<TextAsset>("Data/StatData");
      var statData = JsonUtility.FromJson<StatData>(textAsset.text);

      StatDict = statData.MakeDict();
    }
  }
}