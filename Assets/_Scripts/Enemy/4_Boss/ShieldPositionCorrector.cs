using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPositionCorrector : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private void Update()
    {
        if (_target.activeSelf == true)
        {
            transform.position = _target.transform.position;
        }
        if (_target.activeSelf == false)
        {
            gameObject.SetActive(false);
        }
    }
}
