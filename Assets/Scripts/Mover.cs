using UnityEngine;

public abstract class Mover : MonoBehaviour, IDirectionable
{
    [SerializeField] private float _speed;

    protected Vector3 Direction;

    protected float Speed => _speed;

    private void OnValidate()
    {
        _speed = Mathf.Clamp(_speed, 0, float.MaxValue);
    }

    private void Update()
    {
        Move();
    }

    protected abstract void Move();

    public void SetDirection(Vector2 direction)
    {
        Direction = new Vector3(direction.x, 0, direction.y);
    }
}
