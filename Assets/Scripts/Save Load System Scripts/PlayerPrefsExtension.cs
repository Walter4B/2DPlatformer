using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsExtension
{
    private static string ArmorKey = "Armor";
    private static string HealthKey = "Health";

    public static void SaveStats(Stats stats)
    {
        PlayerPrefs.SetInt (ArmorKey, stats.Armor);
        PlayerPrefs.SetInt (HealthKey, stats.Health);

        Debug.Log ("PlayerPrefs: Stats saved");
    }

    public static Stats LoadStats()
    {
        int armor = PlayerPrefs.GetInt(ArmorKey, 150);
        int health = PlayerPrefs.GetInt(HealthKey, 150);

        Stats stats = new Stats(armor, health);

        Debug.Log("PlayerPrefs: Stats loaded");

        return stats;
    }
	
}
