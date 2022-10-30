using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader<Key, Value>
{
    Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
    public Dictionary<int, Stat> StatDict { get; private set; } = new Dictionary<int, Stat>();

    public void Init()
    {
<<<<<<< Updated upstream:Assets/Scripts/Managers/DataManager.cs
       // StatDict = LoadJson<StatData, int, Stat>("StatData").MakeDict();
=======
        //StatDict = LoadJson<StatData, int, Stat>("StatData").MakeDict();
>>>>>>> Stashed changes:Assets/Scripts/Managers/Core/DataManager.cs
    }

 //   Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
 //   {
	//	TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
 //       return JsonUtility.FromJson<Loader>(textAsset.text);
	//}
}
