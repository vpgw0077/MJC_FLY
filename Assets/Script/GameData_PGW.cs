using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class GameData_PGW 
{
    public static void Save(SaveData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "FLY.bin");
        FileStream stream = File.Create(path);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData Load()
    {
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Path.Combine(Application.persistentDataPath, "FLY.bin");
            FileStream stream = File.OpenRead(path);
            SaveData data = (SaveData)formatter.Deserialize(stream);
            stream.Close();
            return data;
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
            return default;
        }

    }
}
