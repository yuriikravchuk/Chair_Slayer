using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : Singleton<GameLoader>
{
    public GameObject enemies_manager;
    public GameObject boost_manager;
    public GameObject map_generator;
    public GameObject menu_manager;
    public GameObject game_config;

    private void Awake()
    {
        if (!GameConfig.instance)
        {
            Instantiate(game_config);
        }
        if (!EnemiesManager.instance)
        {
            Instantiate(enemies_manager);
        }
        if (!BoostController.instance)
        {
            Instantiate(boost_manager);
        }
        if (!MapGenerator.instance)
        {
            Instantiate(map_generator);
        }
        if (!MenuManager.instance)
        {
            Instantiate(menu_manager);
        }
    }
}
