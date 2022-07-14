using UnityEngine;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _playInterface;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _loadScreen;
    [SerializeField] private Text _loadProgress;
    [SerializeField] private GameObject _UIHPBoss;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void Show()
    {
        Time.timeScale = 0f;
        _mainMenu.SetActive(true);
        _playInterface.SetActive(false);
    }

    public void Hide()
    {
        Time.timeScale = 1f;
        _mainMenu.SetActive(false);
        _playInterface.SetActive(true);
    }


    public void ShowBossUIHP()
    {
        _UIHPBoss.SetActive(true);
    }

    public void HideBossUIHP()
    {
        _UIHPBoss.SetActive(false);
    }


    public void ShowOptions()
        => _settings.SetActive(true);

    public void HideOptions()
        => _settings.SetActive(false);
}