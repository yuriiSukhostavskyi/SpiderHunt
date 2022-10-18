using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfSaw : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;

    private Vector3 _currentPosition;

    private void OnEnable()
    {
        _lineRenderer.enabled = true;
        DrawCircle(40, 1.2f);
    }

    private void DrawCircle(int steps, float radius)
    {
            _lineRenderer.positionCount = 21;

            for (int currentStep = 0; currentStep < 21; currentStep++)
            {
                float circumferenceProgress = (float)currentStep / steps;

                float currentRadian = circumferenceProgress * 2 * Mathf.PI;

                float xScaled = Mathf.Cos(currentRadian);
                float yScaled = Mathf.Sin(currentRadian);

                float x = xScaled * radius;
                float y = yScaled * radius;

                _currentPosition = new Vector3(x, 0.7f, y);

                _lineRenderer.SetPosition(currentStep, _currentPosition );
            }

    }
}
