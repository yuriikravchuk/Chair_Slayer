using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.Events;

public class SaveManager
{
    private static Save save = new Save();
    private static readonly string filePath = Application.persistentDataPath + "/save3.gm";
    private static readonly BinaryFormatter bf = new BinaryFormatter();
    public static UnityEvent deathEvent = new UnityEvent();
    public static void SaveChStats(int money, int characterLevel)
    {
        FileStream fs = new FileStream(filePath, FileMode.Create);
        save.SaveCharacterStats(money, characterLevel);
        bf.Serialize(fs, save);
        fs.Close();
    }
    
    public static void LoadChStats(ref int money, ref int level)
    {
        if (!File.Exists(filePath))
        {
            //Debug.Log("Not loaded save");
            return;
        }

        FileStream fs = new FileStream(filePath, FileMode.Open);
        fs.Position = 0;
        save = (Save)bf.Deserialize(fs);
        fs.Close();
        money = save.chStats.money;
        level = save.chStats.level;
        //Debug.Log("Save is loaded");
    }

    public static void SaveMenuStats(int killCount, int deathCount)
    {
        FileStream fs = new FileStream(filePath, FileMode.Create);
        save.SaveMenuStats(killCount, deathCount);
        bf.Serialize(fs, save);
        fs.Close();
    }

    public static void LoadMenuStats(ref int killCount, ref int deathCount, ref int money, ref int level)
    {
        if (!File.Exists(filePath))
        {
            //Debug.Log("Not loaded save");
            return;
        }

        FileStream fs = new FileStream(filePath, FileMode.Open);
        fs.Position = 0;
        save = (Save)bf.Deserialize(fs);
        fs.Close();

        killCount = save.menuStats.killCount;
        deathCount = save.menuStats.deathCount;
        money = save.chStats.money;
        level = save.chStats.level;
        //Debug.Log("MenuSave is loaded");
    }
}

[System.Serializable]
public class Save
{
    public CharacterStats chStats { get; private set; }
    public MainMenuStats menuStats { get; private set; }
    [System.Serializable]
    public struct CharacterStats
    {
        public int money, level;

        public CharacterStats(int money, int level)
        {
            this.money = money;
            this.level = level;
        }


    }
    [System.Serializable]
    public struct MainMenuStats
    {
        public int deathCount, killCount;

        public MainMenuStats(int killCount, int deathCount)
        {
            this.deathCount = deathCount;
            this.killCount = killCount;
        }
    }
    public void SaveCharacterStats(int money, int characterLevel)
    {
        chStats = new CharacterStats(money, characterLevel);
    }

    public void SaveMenuStats(int killCount, int deathCount)
    {
        menuStats = new MainMenuStats(killCount, deathCount);
    }
}