using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private Transform _groundPoint;
    [SerializeField] private float _distance;
    [SerializeField] private LayerMask _mask;

    private void OnValidate()
    {
        _distance = Mathf.Clamp(_distance, 0, float.MaxValue);
    }

    public bool TryCheckGround(out Vector3 groundNormal)
    {
        if (Physics.Raycast(_groundPoint.position, Vector3.down, out RaycastHit hit, _distance, _mask))
        {
            groundNormal = hit.normal;
            return true;
        }
        else
        {
            groundNormal = Vector3.zero;
            return false;
        }
    }
}
