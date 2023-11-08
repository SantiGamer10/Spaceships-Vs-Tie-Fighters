using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private Transform _firePoint;

    [SerializeField]
    private float _timeBetweenShots;

    private bool _fireContinuously;
    private bool _fireSingle;
    private float _lastFireTime;

    void Update()
    {
        if (_fireContinuously || _fireSingle)
        {
            float timeSinceLastFire = Time.time - _lastFireTime;

            if (timeSinceLastFire >= _timeBetweenShots)
            {
                FireLaser();

                _lastFireTime = Time.time;
                _fireSingle = false;

            }
        }
    }

    public void FireLaser()
    {
        if (Input.GetButtonDown("Fire"))
        {
            GameObject newlaser = Instantiate(_laserPrefab);
            newlaser.transform.position = _firePoint.position;
        }
    }

    private void OnFire(InputValue inputValue)
    {
        _fireContinuously = inputValue.isPressed;

        if (inputValue.isPressed)
        {
            _fireSingle = true;
        }
    }
}
