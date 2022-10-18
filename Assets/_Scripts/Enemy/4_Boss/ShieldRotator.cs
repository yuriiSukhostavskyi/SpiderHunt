using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRotator : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.rotation *= Quaternion.Euler(0, 1.5f, 0);
    }
}
