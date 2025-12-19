using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private string _hSpeed = "hSpeed";
    private string _vSpeed = "vSpeed";
    private Animator _animation;

    private PlayerController player;
    private Vector2 _direction;
    private bool _isWalk = false;

    private void Awake()
    {
        _animation = GetComponentInChildren<Animator>();
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        _direction = player.Direction;
        if (_direction != Vector2.zero)
        {
            _isWalk = true;
        }
        _animation.SetBool("isWalk", _isWalk);
        if (_isWalk)
        {
            _animation.SetFloat(_hSpeed, _direction.x);
            _animation.SetFloat(_vSpeed, _direction.y);
        }
    }
}
