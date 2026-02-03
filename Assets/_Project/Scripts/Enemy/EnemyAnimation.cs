using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private bool _isWalking = false;
    private bool _isDying = false;
    private Vector2 _direction;
    private Animator _animation;
    private Enemy _enemy;
    private LifeController _enemyLife;
    private void Awake()
    {
        _animation = GetComponentInChildren<Animator>();
        _enemy = GetComponent<Enemy>();
        _enemyLife = GetComponent<LifeController>();
    }
    private void FixedUpdate()
    {
        _direction = _enemy.Direction.normalized;
        _isWalking = _direction != Vector2.zero;
        _animation.SetBool("isWalking", _isWalking);

        if (_isWalking)
        {
            _animation.SetFloat("hSpeed", _direction.x);
            _animation.SetFloat("vSpeed", _direction.y);
        }
        if (_enemyLife.IsAlive() == false)
        {
            _isDying = true;
            _animation.SetBool("isDying", _isDying);
            _isDying = false;
        }
    }
}
