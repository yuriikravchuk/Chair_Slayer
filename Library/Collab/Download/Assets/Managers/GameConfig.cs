using UnityEngine;

public class GameConfig : Singleton<GameConfig>
{

    public GameObject charPref;
    public Character character;
    public Ch_Camera cam;

    private void Start()
    {
        CreateCharacter();
    }

    void CreateCharacter()
    {
        character = Instantiate(charPref).GetComponent<Character>();
    }
}
