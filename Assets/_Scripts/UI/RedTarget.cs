using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTarget : MonoBehaviour
{
    [SerializeField] private GameObject _image;

    private Vector3 _angle;
    private float _scaleDelta = 0.03f;

    private void OnEnable()
    {
        FinishAction.OnFinished += DeactivateImage;
    }

    public void ActivateImage()
    {
        _image.SetActive(true);
    }

    public void DeactivateImage()
    {
        _image.SetActive(false);
    }

    private void FixedUpdate()
    {
        _angle.y += 3.5f;
        transform.rotation = Quaternion.Euler(_angle.x, _angle.y, _angle.z);

        transform.localScale += new Vector3(_scaleDelta, _scaleDelta, _scaleDelta);

        if (transform.localScale.x > 1.3f || transform.localScale.x < 0.95f)
        {
            _scaleDelta *= -1;
        }
    }

    public void SetImageScale(Vector3 value)
    {
        _image.gameObject.transform.localScale = value;
    }

    private void OnDisable()
    {
        FinishAction.OnFinished -= DeactivateImage;
    }
}
