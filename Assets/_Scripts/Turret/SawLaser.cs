using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawLaser : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _radius;

    private Vector3 _currentPosition;
    private Vector3 _firstPosition;
    private Vector3 _secondPosition;

    private void OnEnable()
    {
        _lineRenderer.enabled = true;
        DrawCircle(80, _radius);
    }

    private void DrawCircle(int steps, float radius)
    {
        _lineRenderer.positionCount = steps + 2;

        for (int currentStep = 0; currentStep < steps; currentStep++)
        {
            float circumferenceProgress = (float)currentStep / steps; // steps

            float currentRadian = circumferenceProgress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);

            float x = xScaled * radius;
            float y = yScaled * radius;

            _currentPosition = new Vector3(x, 0.7f, y);

            _lineRenderer.SetPosition(currentStep, _currentPosition);

            if (currentStep == 0)
            {
                _firstPosition = _currentPosition;
            }
            if (currentStep == 1)
            {
                _secondPosition = _currentPosition;
            }
        }

        _lineRenderer.SetPosition(steps, _firstPosition);
        _lineRenderer.SetPosition(steps + 1, _secondPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyDieAction enemyDieAction))
        {
        }
    }
}
