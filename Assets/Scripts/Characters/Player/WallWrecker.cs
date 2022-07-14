using System;
using UnityEngine;
using playerStateMachine;
[RequireComponent(typeof(PlayerFacade))]
public class WallWrecker : MonoBehaviour
{
    private PlayerStateMachine _player;
    public event Action EndWrecking;
    public event Action Wrecked;

    private Wall _wall;
    private IBreakable _breakingWall;

    public void Init(IBreakable breakingWall, PlayerStateMachine player)
    {
        _breakingWall = breakingWall;
        _player = player;
    }

    public void StartWrecking(Wall wall)
    {
        _wall = wall;
        _player.SetRootState<BreakState>();
    }

    public void Wreck() // call in animation
    {
        _breakingWall.Break(_wall);
        _wall.BackwardRoom.Activate();
        Wrecked?.Invoke();
    }

    public void End() // call in animation
        => EndWrecking.Invoke();
}