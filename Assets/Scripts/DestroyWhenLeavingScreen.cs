using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenLeavingScreen : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        if (transform.position.y < -7 || transform.position.y > 7)
        {
            Destroy(this.gameObject);
        }
    }
}
