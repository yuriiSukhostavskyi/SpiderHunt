using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private float _positionY;
    private float _progress = 0;
    private float _time;
    private bool _start = false;

    private void OnEnable()
    {
        
    }

    public void SetProgress(float progress)
    {
        _progress += progress;
    }

    private void FixedUpdate()
    {
        _time += Time.fixedDeltaTime;
        if (_time > 3 && _start == false)
        {
            _start = true;
            _positionY = transform.position.y;
        }

        if (_start == true)
        {
            _progress -= 0.07f;
            if (_progress < 0)
            {
                _progress = 0;
            }

            if (_progress > 0.99f)
            {
                _progress = 0.99f;
            }

            transform.position = new Vector3(transform.position.x, _positionY - _progress, transform.position.z);
        }
    }
}
