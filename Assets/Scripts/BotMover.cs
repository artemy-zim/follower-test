using UnityEngine;

[RequireComponent (typeof(GroundChecker))]
[RequireComponent(typeof(Rigidbody))]
public class BotMover : Mover
{
    [SerializeField] private float _maxClimbAngle;

    private Rigidbody _rigidBody;
    private GroundChecker _checker;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _checker = GetComponent<GroundChecker>();
    }

    protected override void Move()
    {
        if (_checker.TryCheckGround(out Vector3 groundNormal))
        {
            float angle = Vector3.Angle(Vector3.up, groundNormal);
            Vector3 movementVelocity = CalculateMovementVelocity(groundNormal, angle);

            _rigidBody.velocity = movementVelocity;
        }
        else
        {
            _rigidBody.velocity += Physics.gravity;
        }
    }

    private Vector3 CalculateMovementVelocity(Vector3 groundNormal, float slopeAngle)
    {
        if (slopeAngle <= _maxClimbAngle)
            return Vector3.ProjectOnPlane(Direction, groundNormal).normalized * Speed;

        return new Vector3(_rigidBody.velocity.x, 0, _rigidBody.velocity.z);
    }
}
