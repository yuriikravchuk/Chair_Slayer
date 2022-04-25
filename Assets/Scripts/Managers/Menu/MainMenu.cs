using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text money;
    public Text level;
    [SerializeField] private Text killCount;
    [SerializeField] private Text deathCount;
    private int _killCount, _deathCount, _money, _level;

    private void Awake()
    {
        LoadMenuStats();
        SaveManager.deathEvent.AddListener(IncreaseDeathCount);
        EnemiesManager.killEvent.AddListener(IncreaseKillCount);
    }

    private void LoadMenuStats()
    {
        SaveManager.LoadMenuStats(ref _killCount, ref _deathCount, ref _money, ref _level);
        killCount.text = "kills: " + _killCount.ToString();
        deathCount.text = "death: " + _deathCount.ToString();
        money.text = "money: " + _money.ToString();
        level.text = "level: " + _level.ToString();
    }
    private void SaveMenuStats()
    {
        SaveManager.SaveMenuStats(_killCount, _deathCount);
    }

    public void IncreaseKillCount()
    {
        _killCount++;
        killCount.text = "kills: " + _killCount.ToString();
    }

    public void IncreaseDeathCount()
    {
        _deathCount++;
        SaveMenuStats();
    }
}
