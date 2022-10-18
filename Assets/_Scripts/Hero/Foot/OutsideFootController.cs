using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideFootController : MonoBehaviour
{
    [SerializeField] private GameObject _center;
    [SerializeField] private OutsideFootController _outsideFootController;

    [SerializeField] private GameObject _foot_1;
    [SerializeField] private GameObject _foot_2;

    [SerializeField] private GameObject _foot_3;
    [SerializeField] private GameObject _foot_4;

    private int _layermask = 1 << 0 | 1 << 6 | 1 << 7; //Default, Platform, Obstacle
    private Ray _ray;
    private RaycastHit _hit;

    private void Update()
    {
        if (Vector3.Magnitude(_center.transform.position - transform.position) > 1)
        {
            Vector3 forward = (_center.transform.position - transform.position).normalized;

            Vector3 oldPosition_1 = transform.position;
            Vector3 newPosition_1 = _center.transform.position + forward;

            transform.position = FootRaycast(newPosition_1);

            Vector3 oldPosition_2 = _outsideFootController.transform.position;
            Vector3 newPosition_2 = transform.position - forward;

            _outsideFootController.transform.position = FootRaycast(newPosition_2);

            _foot_1.transform.position += newPosition_1 - oldPosition_1;
            _foot_1.transform.position = FootRaycast(_foot_1.transform.position);

            _foot_2.transform.position += newPosition_1 - oldPosition_1;
            _foot_2.transform.position = FootRaycast(_foot_2.transform.position);

            _foot_3.transform.position += newPosition_2 - oldPosition_2;
            _foot_3.transform.position = FootRaycast(_foot_3.transform.position);

            _foot_4.transform.position += newPosition_2 - oldPosition_2;
            _foot_4.transform.position = FootRaycast(_foot_4.transform.position);
        }


    }

    private Vector3 FootRaycast(Vector3 position)
    {
        _ray = new Ray(position + Vector3.up * 2.0f, -Vector3.up);
        if (Physics.Raycast(_ray.origin, _ray.direction, out _hit, 100, _layermask, QueryTriggerInteraction.Ignore))
        {
            return _hit.point;
        }
        else return position;
    }
}
