using System;
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
        _fireButton.PointerDown.AddListener(FireButtonPointerDown);
        _fireButton.PointerUp.AddListener(FireButtonPointerUp);
        _joystick.PointerDown.AddListener(JoystickPointerDown);
        _joystick.PointerUp.AddListener(JoystickPointerUp);
    }

    public void SetMoveVector(Vector2 moveVector)
    {
        _player.SetMoveVector(moveVector);
    }
        private void FireButtonPointerDown() => _player.SetAiming(true);
    private void FireButtonPointerUp() => _player.SetAiming(false);
    private void JoystickPointerDown() => _player.SetMoving(true);
    private void JoystickPointerUp() => _player.SetMoving(false);


}
