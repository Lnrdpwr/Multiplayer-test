using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2d;
    private Vector2 _input;

    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isLocalPlayer) return;

        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        _rigidbody2d.velocity = _input.normalized * _speed;
    }
}
