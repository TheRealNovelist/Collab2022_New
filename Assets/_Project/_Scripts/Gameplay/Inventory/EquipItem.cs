using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipType
{
    Gun,
    Ability
}

[CreateAssetMenu]
public class EquipItem : Item
{
    public EquipType type;
    public bool unlocked = false;
    public bool equipping = false;
}
