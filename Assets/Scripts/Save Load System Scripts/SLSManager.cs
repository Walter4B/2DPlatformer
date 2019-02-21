using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;


public class SLSManager : MonoBehaviour
{
    public enum SaveLoadSystemType
    {
        PlayerPrefs,
        Binary,
        XML
    }

    public SaveLoadSystemType SLSType = SaveLoadSystemType.PlayerPrefs;
    public Stats PlayerStats;

	void Start ()
    {
        //Singleton
        DontDestroyOnLoad(gameObject);

        //Application.LoadLevel(1);
	}

    public void SavePlayerStats()
    {
        Debug.Log("PlayerSatats Saved");

        switch (SLSType)
        {
            case SaveLoadSystemType.PlayerPrefs:
                PlayerPrefsExtension.SaveStats(PlayerStats);
                break;

            case SaveLoadSystemType.Binary:
                BinarySerializer.SaveStates(PlayerStats);
                break;

            case SaveLoadSystemType.XML:
                XMLSerializer.SaveStates(PlayerStats);
                break;

            default:
                break;
        }
    }

    public void LoadPlayerStats()
    {
        Debug.Log("PlayerSatats Loaded");

        switch (SLSType)
        {
            case SaveLoadSystemType.PlayerPrefs:
                PlayerStats = PlayerPrefsExtension.LoadStats();
                break;

            case SaveLoadSystemType.Binary:
                PlayerStats = BinarySerializer.LoadStats();
                break;

            case SaveLoadSystemType.XML:
                PlayerStats = XMLSerializer.LoadStats();
                break;

            default:
                break;
        }
    }
}

