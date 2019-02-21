using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Xml.Serialization;

public class XMLSerializer
{
    public static void SaveStates (Stats stats)
    {
        string path = Application.persistentDataPath + "/PlayerStats.xml";

        StreamWriter streamWriter = new StreamWriter(path);

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Stats));
        xmlSerializer.Serialize(streamWriter.BaseStream, stats);

        streamWriter.Close();

        Debug.Log("XMLSerializer: Player stats saved - " + path);

    }

    public static Stats LoadStats()
    {
        string path = Application.persistentDataPath + "/PlayerStats.xml";

        if(File.Exists (path))
        {
            StreamReader streamReader = new StreamReader(path);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Stats));
            Stats stats = (Stats)xmlSerializer.Deserialize(streamReader.BaseStream);

            streamReader.Close();

            Debug.Log("XMLSerializer: PlayerStats loaded - " + path);

            return stats;
        }

        Debug.Log("No data file found at: " + path);
        return null;
    }
}
