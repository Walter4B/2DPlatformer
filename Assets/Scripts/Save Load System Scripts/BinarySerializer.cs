using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class BinarySerializer
{
    public static void SaveStates(Stats stats)
    {
        string path = Application.persistentDataPath + "/PlayerStats.dat";

        FileStream file = File.Create(path);

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(file, stats);

        file.Close();

        Debug.Log("BinarySerializer: PlayerStats saved - " + path);
    }

    public static Stats LoadStats()
    {
        string path = Application.persistentDataPath + "/PlayerStats.dat";
        if(File.Exists (path))
        {
            FileStream file = File.Open(path, FileMode.Open);

            BinaryFormatter binaryFormatter = new BinaryFormatter();

            Stats stats = (Stats)binaryFormatter.Deserialize(file);

            file.Close();

            Debug.Log("BinarySerializer: PlayerStats saved - " + path);

            return stats;
        }

        Debug.LogWarning("No data file found at: " + path);
        // return null nije najbolje rijesenje
        return null;
    }

}
