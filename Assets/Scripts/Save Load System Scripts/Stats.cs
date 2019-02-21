using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    public int Health;
    public int Armor;

    public Stats(){}

    public Stats(int armor, int helath)
    {
        Armor = armor;
        Health = helath;
    }
}
