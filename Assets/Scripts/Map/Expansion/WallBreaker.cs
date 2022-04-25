using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreaker : Object
{
    private GameObject _wreckingWall;
    private GameObject _brokenWall;

    private Animator _wreck_anim;
    public WallBreaker()
    {
        _wreckingWall = Instantiate(MapConfig.WreckingWall);
        _wreck_anim = _wreckingWall.GetComponentInChildren<Animator>();
        _wreckingWall.SetActive(false);
        _brokenWall = MapConfig.BrokenWall;
    }

    public void WreckWall(Wall wall)
    {
        _wreckingWall.transform.position = wall.transform.position;
        _wreckingWall.transform.rotation = wall.transform.rotation;
        _wreckingWall.SetActive(true);
        wall.gameObject.SetActive(false);
        Instantiate(_brokenWall, _wreckingWall.transform.position, _wreckingWall.transform.rotation);
        //ChangeTriggersActive(false);
        _wreck_anim.SetBool("wrecking", true);
        //Invoke("RestoreAfterWrecking", 4);
    }


    //private void RestoreAfterWrecking()
    //{
    //    wreck_wall.SetActive(false);
    //    _wreck_anim.SetBool("wrecking", false);
    //    //ChangeEnemySpawnActive(true);
    //}
}
