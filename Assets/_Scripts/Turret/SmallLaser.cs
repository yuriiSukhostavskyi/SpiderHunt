using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallLaser : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private GameObject _point_1;
    [SerializeField] private GameObject _point_2;

    private void OnEnable()
    {
        _lineRenderer.enabled = true;

        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, _point_1.transform.localPosition);
        _lineRenderer.SetPosition(01, _point_2.transform.localPosition);
    }
}
