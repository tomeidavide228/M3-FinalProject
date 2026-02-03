using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _damage = 10;
    private float _speed = 5f;
    private float _lifeSpan = 1.5f;
    private Vector2 _direction;
    private LifeController _enemyLife;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _rb.velocity = _direction * _speed;
    }
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
        Destroy(this.gameObject, _lifeSpan);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _enemyLife = collision.GetComponent<LifeController>();
        }
        if (_enemyLife != null)
        {
            _enemyLife.TakeDamage(_damage);
        }
    }
}
