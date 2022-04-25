using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : MonoBehaviour
{
    public WallObject wall;
    GameObject wreck_wall;
    GameObject s_wall;
    Animator animator;
    Character character;
    Room room;

    private void Awake()
    {
        character = GetComponent<Character>();
    }
    void Break()
    {
        wreck_wall = MapController.Instance.wreck_wall;
        s_wall = MapController.Instance.stat_wall;
        animator = wreck_wall.GetComponentInChildren<Animator>();
        if(wall)
        {
            room = wall.forward;
            MapController.Instance.FindNextRoof(room, wall);
            ReplaceWall();
            character.state = Character.State.Default;
        }
    }

    void ReplaceWall()
    {
        wreck_wall.transform.position = wall.transform.position;
        wreck_wall.transform.rotation = wall.transform.rotation;
        wreck_wall.SetActive(true);

        Instantiate(s_wall);
        s_wall.transform.position = wreck_wall.transform.position;
        s_wall.transform.rotation = wreck_wall.transform.rotation;

        MapController.Instance.ChangeTriggers(false);
        animator.SetBool("wrecking", true);
        Invoke("SetFalse", 4);
        wall.gameObject.SetActive(false);
    }

    void SetFalse()
    {
        wreck_wall.SetActive(false);
        animator.SetBool("wrecking", false);
        MapController.Instance.ChangeSpawn(true);
    }
}

