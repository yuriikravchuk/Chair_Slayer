using UnityEngine.SceneManagement;

public static class LevelManager
{ 
    public static void LoadScene(int current)
    {
        SceneManager.LoadScene(current);
    }
}