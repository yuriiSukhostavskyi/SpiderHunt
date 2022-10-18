using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private PhysicHeroMover _physicHeroMover;
    [SerializeField] private Arrow _arrow;
    [SerializeField] private Gun _gun;

    [SerializeField] private CinemachineVirtualCamera _runCamera;
    [SerializeField] private CinemachineVirtualCamera _fightCamera;

    private bool _finish = false;

    private void Start()
    {
        FinishAction.OnFinished += SetToStart;
    }

    private void Update()
    {
        if (_finish == false)
        {
            if (_gun.Target == null)
            {
                /*if (_rigidbody.velocity.magnitude > 0.5f && _rigidbody.velocity.magnitude < 6f)
                {
                    transform.position += (_physicHeroMover.transform.position - transform.position + _gun.transform.forward * 1.8f) / 32.5f * Time.deltaTime * 50;
                }
                else if (_rigidbody.velocity.magnitude > 6 && _rigidbody.velocity.magnitude < 15)
                {
                    transform.position += (_physicHeroMover.transform.position - transform.position + _arrow.transform.forward * 4.0f) / 22.5f * Time.deltaTime * 50;
                }
                if (_rigidbody.velocity.magnitude > 15) // movePoint
                {
                    transform.position += (_physicHeroMover.transform.position - transform.position + _gun.transform.forward * 5.8f) / 12.5f * Time.deltaTime * 50;
                }*/
                if (_rigidbody.velocity.magnitude < 6)
                {
                    transform.position += (_physicHeroMover.transform.position - transform.position + _arrow.transform.forward * 1.8f) / 25f * Time.deltaTime * 50;
                }
                if (_rigidbody.velocity.magnitude > 6)
                {
                    transform.position += (_physicHeroMover.transform.position - transform.position + _arrow.transform.forward * 2.8f) / 10f * Time.deltaTime * 50;
                }

                if (_runCamera.Priority == 0)
                {
                    _runCamera.Priority = 100;
                    _fightCamera.Priority = 0;
                }

            }

            if (_gun.Target != null)
            {
                transform.position += (_physicHeroMover.transform.position - (_physicHeroMover.transform.position - _gun.Target.transform.position) / 2.5f - transform.position) / 25f * Time.deltaTime * 50;
                if (_fightCamera.Priority == 0)
                {
                    _runCamera.Priority = 0;
                    _fightCamera.Priority = 100;
                }
            }

            transform.position = new Vector3(transform.position.x, _physicHeroMover.transform.position.y, transform.position.z);
        }
    }

    private void SetToStart()
    {
        _finish = true;

        Vector3 roundVector = new Vector3(Mathf.Round(transform.position.x / 8) * 8, -1.5f, Mathf.Round(transform.position.z / 8) * 8);
        transform.DOMove(roundVector, 2f);
    }

    private void OnDisable()
    {
        FinishAction.OnFinished -= SetToStart;
    }
}
