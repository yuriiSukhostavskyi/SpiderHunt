using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicHeroMover : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private CameraTarget _cameraTarget;
    [SerializeField] private Arrow _arrow;
    [SerializeField] private Gun _gun;
    [SerializeField] private MoveLikeSpider _moveLikeSpider;
    [SerializeField] private FakeJoystick _fakeJoystick;

    private float _speed;
    private float _joystickDistance;

    private int _layermask = 1 << 0 | 1 << 6; //Default, Platform
    private Ray _ray;
    private RaycastHit _hit;

    private float _movePointCooldown = 3f;
    private float _movePointCooldownLimit = 1.75f;
    private Quaternion _movePointRotation;
    public Hero PublicHero => _hero;
    public Gun PublicGun => _gun;
    public float Speed => _speed;

    private void FixedUpdate()
    {
        MovePhysicHero();
        AddMovePointCooldown();
    }

    private void MovePhysicHero()
    {
        _joystickDistance = Vector3.Magnitude(new Vector3(_joystick.Horizontal, 0, _joystick.Vertical));

        if (_joystickDistance <= 0.05f && _movePointCooldown > _movePointCooldownLimit)
        {
            _speed = 0f;

            if (Grounded())
            {
                _rigidbody.velocity *= 0.96f;

                if (_rigidbody.velocity.magnitude < 0.05f)
                {
                    _rigidbody.velocity = Vector3.zero;
                    _rigidbody.isKinematic = true;
                }
            }
        }

        if (_joystickDistance > 0.05f && _movePointCooldown > _movePointCooldownLimit)
        {
            if (_rigidbody.isKinematic == true)
            {
                _rigidbody.isKinematic = false;
            }

            _speed += 8f;

            if (_rigidbody.velocity.magnitude > 9)
            {
                _rigidbody.velocity *= 0.93f;
            }

            if (_speed + _rigidbody.velocity.magnitude > 14)
            {
                _speed = 14 - _rigidbody.velocity.magnitude;
            }

            float turnSpeed = 14.99f - (_rigidbody.velocity.magnitude + _speed);

            _arrow.transform.rotation = Quaternion.Lerp(_arrow.transform.rotation, Quaternion.LookRotation(new Vector3(_joystick.Horizontal, 0, _joystick.Vertical)) * _cameraTarget.transform.rotation, turnSpeed);

            if (_moveLikeSpider.PublicMoveLikeSpider == false || (_moveLikeSpider.PublicMoveLikeSpider == true &&_gun.Target == null))
            {
                _gun.transform.rotation = _arrow.transform.rotation;
            }
            
        }

        if (_rigidbody.velocity.magnitude < 14 && _movePointCooldown > _movePointCooldownLimit)
        {
            //_rigidbody.velocity += _arrow.transform.forward * _speed;

            if (_moveLikeSpider.PublicMoveLikeSpider == false)
            {
                _rigidbody.velocity += _arrow.Direction * _speed;
            }
            if (_moveLikeSpider.PublicMoveLikeSpider == true && _fakeJoystick.Push == true)
            {
                _rigidbody.velocity = _arrow.Direction * 5.5f; // 7
            }
        }
        
    }

    public void ResetMovePointCooldown(Quaternion rotation)
    {
        _movePointCooldown = 0;
        _movePointRotation = rotation;
    }

    private void AddMovePointCooldown()
    {
        _movePointCooldown += Time.fixedDeltaTime;
        if (_movePointCooldown < _movePointCooldownLimit)
        {
            transform.rotation = _movePointRotation;
        }
    }

    public void SetExtraSpeed()
    {
        _rigidbody.isKinematic = false;
        _rigidbody.velocity = transform.forward * 50;
        //_rigidbody.AddExplosionForce(100000, transform.position - transform.forward, 100);
    }

    public bool Grounded()
    {
        _ray = new Ray(transform.position, -Vector3.up);
        if (Physics.Raycast(_ray.origin, _ray.direction, out _hit, 1.25f, _layermask, QueryTriggerInteraction.Ignore))
        {
            return true;
        }
        else return false;
    }
}
