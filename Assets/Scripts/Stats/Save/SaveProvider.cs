using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveProvider : ISaveProvider
{
    private Save save = new Save();
    private readonly string filePath = Application.persistentDataPath + "/save3.gm";
    private readonly BinaryFormatter bf = new BinaryFormatter();
    
    public Save GetSave()
    {
        if (!File.Exists(filePath))
        {
            Debug.Log("Not loaded save");
            return null;
        }

        var fileStream = new FileStream(filePath, FileMode.Open);
        fileStream.Position = 0;
        save = (Save)bf.Deserialize(fileStream);
        fileStream.Close();

        return save;
    }

    public void UpdateSave(int money, int characterLevel)
    {
        var fileStream = new FileStream(filePath, FileMode.Create);
        save.UpdateStats(money, characterLevel);
        bf.Serialize(fileStream, save);
        fileStream.Close();
    }
}
