using UnityEngine;
using UnityEngine.UI;
public class MenuManager : Singleton<MenuManager>
{
    private static bool GameIsPaused;
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private GameObject statBar;
    [SerializeField] private GameObject options;
    private int _money,_killCount, _mapLevel = 1, _level = 1;
    [SerializeField] private Text money, killCount, mapLevel, level;

    [SerializeField] private GameObject Loading;
    [SerializeField] private Text loadProgress;

    [SerializeField] private GameObject UIHPBoss;
    public Image GreenHPBoss;

    private void Awake()
    {
        LoadChStats();
        SaveManager.deathEvent.AddListener(SaveChStats);
        EnemiesManager.killEvent.AddListener(IncreaseKillCount);
    }
    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void ShowMainMenu()
    {
        mainMenu.gameObject.SetActive(true);
    }

    public void HideMainMenu()
    {
        mainMenu.gameObject.SetActive(false);
    }



    public void ChangePauseState()
    {
        GameIsPaused = !GameIsPaused;
        if (GameIsPaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;

        mainMenu.gameObject.SetActive(GameIsPaused);
        statBar.SetActive(!GameIsPaused);
    }

    public void ShowBossUIHP()
    {
        UIHPBoss.SetActive(true);
    }

    public void Victory()
    {
        UIHPBoss.SetActive(false);
        SaveManager.SaveChStats(_money,_level);
    }

    public void IncreaseMoney(int value)
    {
        _money += value;
        money.text = _money.ToString();
    }
    
    public void IncreaseKillCount()
    {
        _killCount++;
        IncreaseMoney(3);
        killCount.text = _killCount.ToString();
    }

    public void IncreaseMapLevel()
    {
        _mapLevel++;
        mapLevel.text = _mapLevel.ToString();
        SaveChStats();
    }

    private void SaveChStats()
    {
        SaveManager.SaveChStats(_money, _level);
    }

    private void LoadChStats()
    {
        SaveManager.LoadChStats(ref _money, ref _level);
        money.text = _money.ToString();
        killCount.text = _killCount.ToString();
        level.text = _level.ToString();
    }

    public void ShowOptions()
    {
        options.SetActive(true);
    }

    public void HideOptions()
    {
        options.SetActive(false);
    }
}