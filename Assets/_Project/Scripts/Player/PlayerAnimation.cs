using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private string _hSpeed = "hSpeed";
    private string _vSpeed = "vSpeed";
    private bool _isWalking = false;
    private bool _isDying = false;
    private Vector2 _direction;
    private Animator _animation;
    private PlayerController _player;
    private LifeController _playerLife;
    private void Awake()
    {
        _animation = GetComponentInChildren<Animator>();
        _player = GetComponent<PlayerController>();
        _playerLife = GetComponent<LifeController>();
    }
    private void Update()
    {
        _direction = _player.Direction;
        if (_direction != Vector2.zero)
        {
            _isWalking = true;
        }
        else
        {
            _isWalking = false;
        }
        _animation.SetBool("isWalking", _isWalking);

        if (_isWalking)
        {
            _animation.SetFloat(_hSpeed, _direction.x);
            _animation.SetFloat(_vSpeed, _direction.y);
        }

        if (_playerLife.IsAlive() == false)
        {
            _isDying = true;
            _animation.SetBool("isDying", _isDying);
        }
    }
}
