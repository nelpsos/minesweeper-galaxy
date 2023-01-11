using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Round

[Serializable]
public class Round
{
	public int round;
	public int animal;
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
    public int effect;
    public string resouce;
    public string explanation;
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
    public string name;
    public int type;
    public string effect;
    public string resouce;
}

[Serializable]
public class SpacesuitData : ILoader<string, Spacesuit>
{
    public List<Spacesuit> spacesuits = new List<Spacesuit>();

    public Dictionary<string, Spacesuit> MakeDict()
    {
        Dictionary<string, Spacesuit> dict = new Dictionary<string, Spacesuit>();
        foreach (Spacesuit spacesuit in spacesuits)
            dict.Add(spacesuit.name, spacesuit);
        return dict;
    }
}
#endregion

#region RepairTool

[Serializable]
public class RepairTool
{
    public string name;
    public int grade;
    public int collect;
    public string resouce;
    public string explanation;
}

[Serializable]
public class RepairToolData : ILoader<string, RepairTool>
{
    public List<RepairTool> repairtools = new List<RepairTool>();

    public Dictionary<string, RepairTool> MakeDict()
    {
        Dictionary<string, RepairTool> dict = new Dictionary<string, RepairTool>();
        foreach (RepairTool repairtool in repairtools)
            dict.Add(repairtool.name, repairtool);
        return dict;
    }
}
#endregion