[System.Serializable]
public class Save
{
    public int Level { get; private set; }
    public int Money { get; private set; }

    public void UpdateStats(int money, int level)
    {
        Level = level;
        Money = money;
    }
}
