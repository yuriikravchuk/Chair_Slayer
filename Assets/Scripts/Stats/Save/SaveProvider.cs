using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveProvider<T> : ISaveProvider<T>
{
    private T save;
    private readonly string filePath = Application.persistentDataPath + "/save3.gm";
    private readonly BinaryFormatter bf = new BinaryFormatter();
    
    public T TryGetSave()
    {
        if (!File.Exists(filePath))
        {
            return default;
        }
        else
        {
            var fileStream = new FileStream(filePath, FileMode.Open);
            fileStream.Position = 0;
            save = (T)bf.Deserialize(fileStream);
            fileStream.Close();
            return save;
        }
    }

    public void UpdateSave(T save)
    {
        var fileStream = new FileStream(filePath, FileMode.Create);
        bf.Serialize(fileStream, save);
        fileStream.Close();
    }
}
