using System;
using UnityEngine;
[RequireComponent(typeof(PlayerFacade))]
public class WallWrecker : MonoBehaviour
{
    [SerializeField] private PlayerFacade _player;

    public event Action EndWrecking;

    private Wall _wall;
    private IBreakable _breakingWall;
    

    public void Init(IBreakable breakingWall)
        => _breakingWall = breakingWall;

    public void StartWrecking(Wall wall)
    {
        _wall = wall;
        _player.SetBreakState();
    }

    public void Wreck() // call in animation
    {
        _breakingWall.Break(_wall);
        _wall.BackwardRoom.Activate();
    }

    public void End() // call in animation
    {
        EndWrecking.Invoke();
    }
}