using UnityEngine;

public class InputCompositeRoot : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerInputController _controller;

    private void Awake()
    {
        _controller.Init(_mover);
    }
}
