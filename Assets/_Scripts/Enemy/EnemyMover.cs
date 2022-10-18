using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private EnemySettings _enemySettings;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private EnemyDieAction _enemyDieAction;
    [SerializeField] private EnemyStateMachine _enemyStateMachine;

    private PhysicHeroMover _physicHeroMover;
    private bool _runToHero = false;
    private float _speed;
    private float _coolDownAfterDamage;
    private float _turnSpeed;

    private void OnEnable()
    {
        _speed = _enemySettings.Speed;
        _coolDownAfterDamage = _enemySettings.CoolDownAfterDamage;
        _turnSpeed = _enemySettings.TurnSpeed;

        _navMeshAgent.speed = _speed;
        _navMeshAgent.angularSpeed = _turnSpeed;

        transform.rotation = Quaternion.Euler(0, Random.Range(-180, 180), 0);

        FinishAction.OnFinished += StopMove;
    }

    public void SetHeroTarget(PhysicHeroMover physicHeroMover)
    {
        _physicHeroMover = physicHeroMover;
        _runToHero = true;
        _enemyStateMachine.SetState(EnemyStateMachine.State.Run);
    }

    public void StopMove()
    {
        _runToHero = false;
        _enemyStateMachine.SetState(EnemyStateMachine.State.Idle);
        if (_navMeshAgent.enabled == true)
        {
            _navMeshAgent.SetDestination(transform.position);
            _navMeshAgent.enabled = false;
        }
    }

    public void TakeDamage()
    {
        _runToHero = false;

        if (_navMeshAgent.enabled == true)
        {
            _navMeshAgent.SetDestination(transform.position);
        }

        Invoke(nameof(MoveAfterDamage), _coolDownAfterDamage);
    }

    private void MoveAfterDamage()
    {
        SetHeroTarget(_physicHeroMover);
    }

    private void FixedUpdate()
    {
        if (_runToHero == true && _enemyDieAction.DieBool == false && _physicHeroMover != null)
        {
            _navMeshAgent.SetDestination(_physicHeroMover.transform.position);
        }
    }

    private void OnDisable()
    {
        FinishAction.OnFinished -= StopMove;
    }
}
