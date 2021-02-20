using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShottingObject : MonoBehaviour
{
    public Transform firepoint;
    public GameObject arrowPrefab;

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Instantiate(arrowPrefab, firepoint.position, firepoint.rotation);
        }
    }
}
