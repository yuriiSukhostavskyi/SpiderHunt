using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScaler : MonoBehaviour
{
    [SerializeField] private PhysicHeroMover _physicHeroMover;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject _ball;
    [SerializeField] private MoveLikeSpider _moveLikeSpider;

    private Vector3 _ballAngle;
    
    private void FixedUpdate()
    {
        ScaleBall();
    }

    private void ScaleBall()
    {
        if (_rigidbody.velocity.magnitude > 0)
        {
            _ballAngle.y = Quaternion.LookRotation(_rigidbody.velocity.normalized).eulerAngles.y;
        }

        _ball.transform.rotation = Quaternion.Euler(_ballAngle.x, _ballAngle.y, _ballAngle.z);

        float scale = (_rigidbody.velocity.magnitude + 8) / 20;//18

        if (_moveLikeSpider.PublicMoveLikeSpider == true)
        {
            scale = 0;
        }

        if (scale < 0.85f && _physicHeroMover.Grounded())
        {
            _ball.transform.localScale = new Vector3(scale, scale, scale);
        }

        else if (scale >= 0.85f)
        {
            _ball.transform.localScale = new Vector3(scale / ((_rigidbody.velocity.magnitude + 15) / 20), scale, scale);

            _ballAngle.x += _rigidbody.velocity.magnitude;
            _ball.transform.rotation = Quaternion.Euler(_ballAngle.x, _ballAngle.y, _ballAngle.z);
        }
    }
}
