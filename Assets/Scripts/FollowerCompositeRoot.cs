using UnityEngine;

public class FollowerCompositeRoot : MonoBehaviour
{
    [SerializeField] private Follower _follower;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _follower.Init(_player);
    }
}
