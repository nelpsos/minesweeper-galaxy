using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    List<RepairTool> _repairTools = new List<RepairTool>();
    List<Spacesuit> _spacesuit = new List<Spacesuit>();

    public void AddRepairTool(RepairTool tool)
    {
        _repairTools.Add(tool); 
    }

    public void AddSpacesuit(Spacesuit spacesuit)
    {
        _spacesuit.Add(spacesuit); 
    }

    public List<RepairTool>  GetRepairTools() 
    {
        return _repairTools;
    }

    public List<Spacesuit> GetSpacesuits()
    {
        return _spacesuit;
    }
}
