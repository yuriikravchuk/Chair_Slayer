using UnityEngine;

public class MainMenu : MonoBehaviour
{
       public void NewGame()
        {
        LevelManager.SetLevel(1);
        }
        
        public void Exit()
        {
            Application.Quit();
        }
}
