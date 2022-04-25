using UnityEngine;

[RequireComponent(typeof(PlayerFacade))]

public class Breaker : MonoBehaviour
{
    [SerializeField] private PlayerFacade _player;

    public delegate void BreakWall(Wall brakedWall);
    public event BreakWall BreakWallEvent;

    private Wall _wall;

    private void Break() // call in animation
    {
        if(_wall != null)
            BreakWallEvent.Invoke(_wall);
    }

    public void SetBreakState()
        => _player.SetBreakState();
    public void SetStateToDefault() // call in animation
        => _player.SetDefaultState();

    public void SetWallToBrake(Wall wall) 
        => _wall = wall;
}