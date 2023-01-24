using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Round

[Serializable]
public class Round
{
	public int round;
	public int animalCount;
	public int square_row;
	public int square_column;
	public int square_mine;
    public int hexagon_length;
    public int hexagon_mine;
}

[Serializable]
public class RoundData : ILoader<int, Round>
{
	public List<Round> rounds = new List<Round>();

	public Dictionary<int, Round> MakeDict()
	{
		Dictionary<int, Round> dict = new Dictionary<int, Round>();
		foreach (Round round in rounds)
			dict.Add(round.round, round);
		return dict;
	}
}

#endregion

#region Animal

[Serializable]
public class Animal
{
    public int index;
    public string name;
    public string explain;
    public int effect_1;
    public int effect_2;
    public string resource;
}

[Serializable]
public class AnimalData : ILoader<int, Animal>
{
    public List<Animal> animals = new List<Animal>();

    public Dictionary<int, Animal> MakeDict()
    {
        Dictionary<int, Animal> dict = new Dictionary<int, Animal>();
        foreach (Animal animal in animals)
            dict.Add(animal.index, animal);
        return dict;
    }
}

#endregion

#region Spacesuit

[Serializable]
public class Spacesuit
{
    public int index;
    public string name;
    public int type;
    public string explain;
    public string penaltyExplain;
    public int effect;
    public int penalty;
    public string resource;
}

[Serializable]
public class SpacesuitData : ILoader<int, Spacesuit>
{
    public List<Spacesuit> spacesuits = new List<Spacesuit>();

    public Dictionary<int, Spacesuit> MakeDict()
    {
        Dictionary<int, Spacesuit> dict = new Dictionary<int, Spacesuit>();
        foreach (Spacesuit spacesuit in spacesuits)
            dict.Add(spacesuit.index, spacesuit);
        return dict;
    }
}
#endregion

#region RepairTool

[Serializable]
public class RepairTool
{
    public int index;
    public string name;
    public int rarely;
    public string explain;
    public int collect;
    public int type;
    public int maxCollect;
    public int limitCollect;
    public string resource;
    
}

[Serializable]
public class RepairToolData : ILoader<int, RepairTool>
{
    public List<RepairTool> repairtools = new List<RepairTool>();

    public Dictionary<int, RepairTool> MakeDict()
    {
        Dictionary<int, RepairTool> dict = new Dictionary<int, RepairTool>();
        foreach (RepairTool repairtool in repairtools)
            dict.Add(repairtool.index, repairtool);
        return dict;
    }
}
#endregion