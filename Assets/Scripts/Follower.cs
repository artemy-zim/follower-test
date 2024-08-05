using UnityEngine;

[RequireComponent(typeof(IDirectionable))]
public class Follower : MonoBehaviour
{
    [SerializeField] private float minDistance;

    private ITarget _target;
    private IDirectionable _directionable;

    public void Init(ITarget target)
    {
        _target = target;
    }

    private void Awake()
    {
        _directionable = GetComponent<IDirectionable>();
    }

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 direction = _target.GetPosition() - transform.position;

        if (direction.magnitude > minDistance)
            direction = new Vector2(direction.x, direction.z).normalized;
        else
            direction = Vector3.zero;

        _directionable.SetDirection(direction);
    }
}
