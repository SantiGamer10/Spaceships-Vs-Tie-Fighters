using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _speed; // Variable used to set the ship's speed
    [SerializeField] private Vector2 _velocity = new(0, 0);
    [SerializeField] private Vector2 Min, Max;
    // These 3 variables are basically used to control the player's ship's movemement using either the keyboard or a gamepad.
    [SerializeField] private float _screenBorder;
    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    private Camera _camera;
    public Vector2 _direction;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        HandleMovement();
        MoveShip();
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        _rigidbody.velocity = _direction * _speed;
    }
    private void SetPlayerVelocity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
                    _smoothedMovementInput,
                    _movementInput,
                    ref _movementInputSmoothVelocity,
                    0.1f);

        _rigidbody.velocity = _direction * _speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        AsteroidMovement asAsteroid = other.GetComponent<AsteroidMovement>();
        if (asAsteroid != null)
        {
            Destroy(this);
        }
    }
    private void HandleMovement()
    {
        _velocity = HandleHorizontal(Input.GetAxis("Horizontal"));
        _velocity += HandleVertical(Input.GetAxis("Vertical"));
    }

    private Vector2 HandleVertical(float v) => new(0, Mathf.Clamp(v, -1, 1));
    private Vector2 HandleHorizontal(float h) => new(Mathf.Clamp(h, -1, 1), 0);
    private void MoveShip()
    {
        float newX = transform.position.x + (_velocity.x * _speed * Time.deltaTime);
        float newY = transform.position.y + (_velocity.y * _speed * Time.deltaTime);
        transform.position = new Vector2(newX, newY);
    }
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }
}
