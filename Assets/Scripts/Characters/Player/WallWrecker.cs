using System;
using UnityEngine;
using player;

public class WallWrecker : MonoBehaviour
{
    public event Action EndWrecking;

    private Wall _wall;
    private IBreakable _breakingWall;
    private PlayerStateMachine _player;

    public void Init(IBreakable breakingWall, PlayerStateMachine player)
    {
        _breakingWall = breakingWall;
        _player = player;
    }

    public void StartWrecking(Wall wall)
    {
        _wall = wall;
        _player.GetRootState<BreakState>();
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