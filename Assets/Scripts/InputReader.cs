using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField] private PlayerMovement characterMovement;
    [SerializeField] private PlayerShoot laserShooter;

    public void SetMovementValue(InputAction.CallbackContext inputContext)
    {
        Vector2 inputValue = inputContext.ReadValue<Vector2>();
        characterMovement.SetDirection(inputValue);
        Debug.Log($"{gameObject.name}: Event risen. Value: {inputValue}");
    }

    public void FireLaser(InputAction.CallbackContext inputContext)
    {
        if (inputContext.started)
        {
            if (laserShooter != null)
            {
                laserShooter.FireLaser();
            }
            else
            {
                Debug.LogError(message: $"{name}: Laser is null! </3");
                return;
            }
        }
    }
}
