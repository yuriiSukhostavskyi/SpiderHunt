using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTail : MonoBehaviour
{
    [SerializeField] private List<Tail> _tailList = new List<Tail>();

    private List<Vector3> _positionHistory = new List<Vector3>();

    private int Gap = 9; // delta
    private float _bodySpeed = 25;

    private void Start()
    {
        for (int i = 12 * 2; i > 0; i--)
        {
            _positionHistory.Insert(0, transform.position - transform.forward * i / 2);
        }
    }

    private void FixedUpdate()
    {
            _positionHistory.Insert(0, transform.position);

            int index = 0;

            foreach (var body in _tailList)
            {
                Vector3 point = _positionHistory[Mathf.Min(index * Gap, _positionHistory.Count - 1)];
                Vector3 moveDirection = point - body.transform.position;

                body.transform.position += moveDirection * _bodySpeed * Time.fixedDeltaTime;
                body.transform.LookAt(point);
                index++;
            }
    }
}
