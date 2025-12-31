using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private float _horizontal;
    private float _vertical;
    public Vector2 Direction { get; private set; }
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        Direction = new Vector2(_horizontal, _vertical);
    }
    private void FixedUpdate()
    {
        float sqrtLenght = Direction.sqrMagnitude;
        if (sqrtLenght > 1)
        {
            Direction = Direction / Mathf.Sqrt(sqrtLenght);
        }
        _rb.MovePosition(_rb.position + Direction * (_speed * Time.deltaTime));
    }
}
