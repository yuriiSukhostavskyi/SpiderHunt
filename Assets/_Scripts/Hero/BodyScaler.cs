using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BodyScaler : MonoBehaviour
{
    [SerializeField] private GameObject _body;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private PhysicHeroMover _physicHeroMover;
    [SerializeField] private FakeJoystick _fakeJoystick;
    [SerializeField] private MoveLikeSpider _moveLikeSpider;

    private void OnEnable()
    {
        Silver.OnSilverCatch += SilverScale;
    }

    private void SilverScale()
    {
        transform.DOKill(true);

        transform.DOShakeScale(0.2f, 0.4f, 15, 90, true);
    }

    private void FixedUpdate()
    {
        ScaleBody();
    }

    private void ScaleBody()
    {
        //float scale = (11 - _rigidbody.velocity.magnitude) / 8;
        float scale = (15 - _rigidbody.velocity.magnitude) / 8;

        if (scale > 1)
        {
            scale = 1;
        }

        if (_physicHeroMover.Grounded() == false)
        {
            scale = 0.1f;
        }

        if (scale < 0.1f)
        {
            scale = 0.1f;
        }

        if (scale > 0.1f && _physicHeroMover.Speed > 2)
        {
            scale = 0.1f;
        }

        if (_moveLikeSpider.PublicMoveLikeSpider == true)
        {
            scale = 1;
        }

        _body.transform.localScale = new Vector3(scale, scale, scale);
    }

    private void OnDisable()
    {
        Silver.OnSilverCatch -= SilverScale;
    }
}
