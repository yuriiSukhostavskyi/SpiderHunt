using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Hero _hero;

    [SerializeField] private GameObject _front;
    [SerializeField] private GameObject _back;

    private int _layermask = 1 << 6; //Platform
    private Ray _ray;
    private RaycastHit _hit;

    private Vector3 _direction;
    public Vector3 Direction => _direction;

    private void Update()
    {
        transform.position = _hero.transform.position;
    }

    private void FixedUpdate()
    {
        _front.transform.position = Grounded(new Vector3(_front.transform.position.x, transform.position.y, _front.transform.position.z));
        _back.transform.position = Grounded(new Vector3(_back.transform.position.x, transform.position.y, _back.transform.position.z));

        _direction = (_front.transform.position - _back.transform.position).normalized;
    }

    private Vector3 Grounded(Vector3 position)
    {
        Vector3 newPosition = new Vector3(position.x, _hero.transform.position.y, position.z);
        _ray = new Ray(position + Vector3.up * 5, -Vector3.up);
        if (Physics.Raycast(_ray.origin, _ray.direction, out _hit, 8f, _layermask, QueryTriggerInteraction.Ignore))
        {
            return _hit.point;
        }
        else return position;
    }
}
