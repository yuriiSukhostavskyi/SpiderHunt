using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _time;
    [SerializeField] private GameObject _redArrow;

    private PhysicHeroMover _physicHeroMover;
    private bool _canMove = false;

    public void CanMove(PhysicHeroMover physicHeroMover)
    {
        _canMove = true;
        _physicHeroMover = physicHeroMover;
    }

    private void FixedUpdate()
    {
        if (_canMove == true)
        {
            _time += Time.fixedDeltaTime;

            if (_time > 1.25f && _time < 3.5f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.LookRotation(new Vector3(_physicHeroMover.transform.position.x, 0, _physicHeroMover.transform.position.z) -
                new Vector3(transform.position.x, 0, transform.position.z), Vector3.up),
                0.035f);
            }
            if (_time > 3.0f && _time < 3.75f)
            {
                if (_redArrow.activeSelf == false)
                {
                    _redArrow.SetActive(true);
                }
            }

            if (_time > 3.75f)
            {
                _redArrow.SetActive(false);
                _rigidbody.AddForce(transform.forward * 3500, ForceMode.Force);
                _time = 0;
            }
        }
    }
}
