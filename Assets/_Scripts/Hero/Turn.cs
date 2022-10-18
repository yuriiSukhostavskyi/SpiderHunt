using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Gun _gun;

    private float _time = 0;

    private void Update()
    {
        if (_rigidbody.velocity.magnitude < 1 && _gun.Target == null)
        {
            _time += Time.deltaTime;

            if (_time <= 0.6f)
            {
                transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + 0.3f, transform.eulerAngles.z);
            }
            if (_time > 0.6f)
            {
                transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y - 0.3f, transform.eulerAngles.z);
            }
            if (_time > 1.2f)
            {
                _time = 0;
            }
        }
    }
}
