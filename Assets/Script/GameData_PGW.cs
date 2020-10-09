using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class GameData_PGW 
{
    public int TotalCoin;

    public GameData_PGW(int Coin)
    {
        this.TotalCoin = Coin;
        
    }
    public void Save()
    {
        FileStream fileStream = new FileStream("Fly.dat", FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        binaryFormatter.Serialize(fileStream, this);
        fileStream.Close();
    }

    //불러오기
    public static GameData_PGW Load()
    {
        FileStream fileStream = new FileStream("Fly.dat", FileMode.Open);
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        GameData_PGW gameData = (GameData_PGW)binaryFormatter.Deserialize(fileStream);

        return gameData;
    }
}
