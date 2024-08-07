using System;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private BotMover _mover;
    [SerializeField] private float _minDistance;

    private ITarget _target;
    private IDirectionable _directionable;

    public void Init(ITarget target)
    {
        _target = target ?? throw new ArgumentNullException(nameof(target));
        _directionable = _mover;
    }

    private void OnValidate()
    {
        if (_mover == null)
            Debug.LogWarning($"Mover component is not set to {gameObject.name}");

        _minDistance = Mathf.Clamp(_minDistance, 0, float.MaxValue);
    }

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 direction = _target.GetPosition() - transform.position;

        if (direction.magnitude > _minDistance)
            direction = new Vector2(direction.x, direction.z).normalized;
        else
            direction = Vector3.zero;

        _directionable.SetDirection(direction);
    }
}
