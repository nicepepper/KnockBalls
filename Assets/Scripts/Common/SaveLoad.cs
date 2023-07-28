using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
    public static List<PlayerData> SavePlayersData = new List<PlayerData>();

    public static void Save()
    {
        Load();
        SavePlayersData.Add(PlayerData.Current);
        SavePlayersData.Sort();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.persistentDataPath + "/SavePlayersData.kb");
        bf.Serialize(fileStream, SaveLoad.SavePlayersData);
        fileStream.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/SavePlayersData.kb"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = File.Open(Application.persistentDataPath + "/SavePlayersData.kb", FileMode.Open);
            SavePlayersData.Clear();
            SavePlayersData = (List<PlayerData>) bf.Deserialize(fileStream);
            fileStream.Close();
        }
    }

    public static void DeleteSave()
    {
        if (File.Exists(Application.persistentDataPath + "/SavePlayersData.kb"))
        {
            File.Delete(Application.persistentDataPath + "/SavePlayersData.kb");
            SavePlayersData.Clear();
        }
        else
        {
            Debug.Log("File to delete not found");
        }
    }
}
