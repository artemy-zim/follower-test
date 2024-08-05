using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private PlayerInput _input;
    private IDirectionable _playerMover;

    public void Init(PlayerMover playerMover)
    {
        _playerMover = playerMover != null ? playerMover : throw new ArgumentNullException(nameof(playerMover));
    }

    public void Awake()
    {
        _input = new PlayerInput();

        _input.Player.Movement.performed += OnMove;
        _input.Player.Movement.canceled += (ctx) => _playerMover.SetDirection(Vector2.zero);
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        if(_playerMover == null)
            throw new InvalidOperationException(nameof(_playerMover));

        _playerMover.SetDirection(context.ReadValue<Vector2>());
    }
}
