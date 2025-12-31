using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _fireStart;
    private float _fireRate = 1.5f;
    private float _fireRange = 8f;
    private float _fireTimer;
    private Vector2 _direction = Vector2.down;
    private void Update()
    {
        Direction();
        Shooting();
    }
    private void Fire()
    {
        Bullet bullet = Instantiate(_bulletPrefab, _fireStart.position, Quaternion.identity);
        bullet.SetDirection(_direction);
    }
    private void Direction()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (direction != Vector2.zero)
        {
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                _direction = new Vector2(Mathf.Sign(direction.x), 0);

            }
            else
            {
                _direction = new Vector2(0, Mathf.Sign(direction.y));

            }
        }
        _fireStart.localPosition = _direction * 0.5f;
    }
    private void Shooting()
    {
        _fireTimer += Time.deltaTime;

        if (_fireTimer < _fireRate)
        {
            return;
        }

        if (FindEnemy() != null)
        {
            Fire();
            _fireTimer = 0f;
        }
    }
    private GameObject FindEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            if (Vector2.Distance(transform.position, enemy.transform.position) <= _fireRange)
            {
                return enemy;
            }
        }
        return null;
    }
}