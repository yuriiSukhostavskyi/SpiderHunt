using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject _vfx;
    [SerializeField] private GameObject _portalObject;
    [SerializeField] private Collider _trigger;

    private void OnEnable()
    {
        ProgressPanel.OnActivatePortal += ActivatePortal;
    }

    private void ActivatePortal()
    {
        Invoke(nameof(ActivatePortalAction), 1.5f);
    }

    private void ActivatePortalAction()
    {
        _portalObject.SetActive(true);
        _trigger.enabled = true;

        Invoke(nameof(EnableEffect), 0.1f);
    }

    private void EnableEffect()
    {
        Instantiate(_vfx, transform.position + Vector3.up * 0.5f, Quaternion.Euler(90, 0, 0));
        Sound.Instance.StartSound();
    }

    public void UsePortal()
    {
        Instantiate(_vfx, transform.position + Vector3.up * 0.5f, Quaternion.Euler(90, 0, 0));

        Sound.Instance.PortalSound();
        Vibration.Instance.MiddleVibrate();

        _portalObject.transform.DOScale(Vector3.zero, 0.5f);
    }

    private void OnDisable()
    {
        ProgressPanel.OnActivatePortal -= ActivatePortal;
    }
}
