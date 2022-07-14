using UnityEngine;

public class InputMediator
{
    private readonly FloatingJoystick _joystick;
    private readonly FireButton _fireButton;
    private readonly PlayerFacade _player;
    public InputMediator(FloatingJoystick joystick, FireButton fireButton, PlayerFacade player)
    {
        _joystick = joystick;
        _fireButton = fireButton;
        _player = player;
        _fireButton.PointerDown += FireButtonPointerDown;
        _fireButton.PointerUp += FireButtonPointerUp;
        _joystick.PointerDown += JoystickPointerDown;
        _joystick.PointerUp += JoystickPointerUp;
    }

    public void SetMoveVector(Vector2 moveVector)
    {
        _player.SetMoveVector(moveVector);
    }

    private void FireButtonPointerDown() => _player.StartAiming();
    private void FireButtonPointerUp() => _player.StopAiming();
    private void JoystickPointerDown() => _player.StartMoving();
    private void JoystickPointerUp() => _player.StopMoving();


}
