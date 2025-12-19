using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private float _h;
    private float _v;
    public Vector2 Direction { get; private set; }
    private Rigidbody2D _rb;
    private CircleCollider2D _collider;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");
        Direction = new Vector2(_h, _v);
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
