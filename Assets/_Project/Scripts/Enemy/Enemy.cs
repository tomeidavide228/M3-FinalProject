using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 2f;
    private int _damage = 10;
    private float _aggroRange = 5f;
    public Vector2 Direction { get; private set; }
    private GameObject _player;
    private Transform _playerTransform;
    private LifeController _playerLife;
    private LifeController _enemyLife;
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerTransform = _player.transform;
    }
    private void Update()
    {
        if (_player == null)
        {
            Direction = Vector2.zero;
            return;
        }
    }
    private void FixedUpdate()
    {
        if (_player != null)
        {
            float distance = Vector2.Distance(_playerTransform.position, transform.position);
            if (distance > _aggroRange)
            {
                Direction = Vector2.zero;
                return;
            }
            {
                Direction = (_playerTransform.position - transform.position).normalized;
                float sqrtLenght = Direction.sqrMagnitude;
                if (sqrtLenght > 1)
                {
                    Direction = Direction / Mathf.Sqrt(sqrtLenght);
                }
                _rb.MovePosition(_rb.position + Direction * (_speed * Time.deltaTime));
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LifeController player = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<LifeController>();
            if (player != null)
            {
                player.TakeDamage(_damage);
            }
            LifeController enemy = GetComponent<LifeController>();
            enemy.InstantDeath(gameObject);
        }
    }
}