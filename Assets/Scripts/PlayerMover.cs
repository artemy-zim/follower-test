using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : Mover
{
    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    protected override void Move()
    {
        Vector3 motion;

        if (_controller.isGrounded)
            motion = Speed * Time.deltaTime * (Direction + Vector3.down);
        else
            motion = _controller.velocity + Physics.gravity * Time.deltaTime;

        _controller.Move(motion);
    }
}
