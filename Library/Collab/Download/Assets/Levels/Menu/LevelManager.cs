using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager
{ 
    public static void SetLevel(int current)
    {
        SceneManager.LoadScene(current);
    }

    public static void Exit()
    {
        Application.Quit();
    }
}
