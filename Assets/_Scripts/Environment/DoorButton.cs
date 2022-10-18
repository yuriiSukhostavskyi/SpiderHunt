using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private float _progress;

    [SerializeField] private Renderer _renderer_1;
    [SerializeField] private Renderer _renderer_2;
    [SerializeField] private Material _greyMaterial_1;
    [SerializeField] private Material _greyMaterial_2;
    [SerializeField] private Material _yellowMaterial_1;
    [SerializeField] private Material _yellowMaterial_2;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out KeyTriggerForButton _))
        {
            _door.SetProgress(_progress);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out KeyTriggerForButton _))
        {
            _renderer_1.material = _yellowMaterial_1;
            _renderer_2.material = _yellowMaterial_2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out KeyTriggerForButton _))
        {
            _renderer_1.material = _greyMaterial_1;
            _renderer_2.material = _greyMaterial_2;
        }
    }
}
