using UnityEngine;
using UnityEngine.UI;

public class MenuManager : Singleton<MenuManager>
{
    public static bool GameIsPaused;
    public GameObject PausedMenu;
    public DisplayStatistics statBar;

    public GameObject UIHPBoss;
    public Image GreenHPBoss;

    public void ChangePauseState()
    {
        GameIsPaused = !GameIsPaused;
        SetPause(GameIsPaused);
    }
    private void SetPause(bool IsPaused)
    {
        if (IsPaused)      
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;


        PausedMenu.SetActive(IsPaused);
        statBar.gameObject.SetActive(!IsPaused);
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public void MenuButton()
    {
        LevelManager.SetLevel(0);
        SetPause(false);
    }
}

