using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Gun : MonoBehaviour
{
    [SerializeField] private RedTarget _redTarget;
    [SerializeField] private Hero _hero;

    private List<Chest> _chestList = new List<Chest>();
    private List<Chest> _visibleChestList = new List<Chest>();

    private List<GameObject> _enemyList = new List<GameObject>();
    private List<GameObject> _visibleEnemyList = new List<GameObject>();

    private List<Barrel> _barrelList = new List<Barrel>();
    private List<Barrel> _visibleBarrelList = new List<Barrel>();

    //private List<Turret> _turretList = new List<Turret>();
    //private List<Turret> _visibleTurretList = new List<Turret>();

    private GameObject _target;

    private int _layermask = 1 << 6| 1 << 7 | 1 << 8 | 1 << 12 | 1 << 13 | 1 << 17; //Platform, Obstacle, enemy, chest, Barrel, Turret
    private Ray _ray;
    private RaycastHit _hit;

    public GameObject Target => _target;

    

    public void AddChest(Chest chest)
    {
        _chestList.Add(chest);
    }
    public void AddEnemy(Enemy enemy)
    {
        _enemyList.Add(enemy.gameObject);
    }
    public void AddBarrel(Barrel barrel)
    {
        _barrelList.Add(barrel);
    }
    public void AddTurret(Turret turret)
    {
        _enemyList.Add(turret.gameObject);
    }

    public void DecreaseChest(Chest chest)
    {
        _chestList.Remove(chest);
    }
    public void DecreaseEnemy(Enemy enemy)
    {
        _enemyList.Remove(enemy.gameObject);
    }
    public void DecreaseBarrel(Barrel barrel)
    {
        _barrelList.Remove(barrel);
    }
    public void DecreaseTurret(Turret turret)
    {
        _enemyList.Remove(turret.gameObject);
    }

    private void FixedUpdate()
    {
        _target = null;
        FindNearestChest();
        //FindNearestTurret();
        FindNearestEnemy();
        FindNearestBarrel();
        RotateToNeares();
    }

    private void FindNearestChest()
    {
        _visibleChestList.Clear();

        for (int i = 0; i < _chestList.Count; i++)
        {
            _ray = new Ray(transform.position, _chestList[i].transform.position - transform.position);
            if (Physics.Raycast(_ray.origin, _ray.direction, out _hit, 50, _layermask, QueryTriggerInteraction.Ignore))
            {
                if (_hit.collider.TryGetComponent(out Chest chest) && chest == _chestList[i])
                {
                    _visibleChestList.Add(_chestList[i]);
                }
            }
        }

        if (_visibleChestList.Count > 0)
        {
            _target = _visibleChestList.OrderBy(x => Vector3.Distance(_hero.transform.position, x.transform.position)).FirstOrDefault().gameObject;
        }
    }

    private void FindNearestEnemy()
    {

        _visibleEnemyList.Clear();

        for (int i = 0; i < _enemyList.Count; i++)
        {
            _ray = new Ray(transform.position, _enemyList[i].transform.position - transform.position + Vector3.up *0.3f);
            if (Physics.Raycast(_ray.origin, _ray.direction, out _hit, 50, _layermask, QueryTriggerInteraction.Ignore))
            {
                if (_hit.collider.gameObject == _enemyList[i])
                {
                    _visibleEnemyList.Add(_enemyList[i]);
                }
            }
        }

        if (_visibleEnemyList.Count > 0)
        {
            _target = _visibleEnemyList.OrderBy(x => Vector3.Distance(_hero.transform.position, x.transform.position)).FirstOrDefault().gameObject;
        }
    }

    private void FindNearestBarrel()
    {

        _visibleBarrelList.Clear();

        for (int i = 0; i < _barrelList.Count; i++)
        {
            _ray = new Ray(transform.position, _barrelList[i].transform.position - transform.position + Vector3.up * 0.3f);
            if (Physics.Raycast(_ray.origin, _ray.direction, out _hit, 50, _layermask, QueryTriggerInteraction.Ignore))
            {
                if (_hit.collider.TryGetComponent(out Barrel barrel) && barrel == _barrelList[i])
                {
                    _visibleBarrelList.Add(_barrelList[i]);
                }
            }
        }

        if (_visibleBarrelList.Count > 0)
        {
            _target = _visibleBarrelList.OrderBy(x => Vector3.Distance(_hero.transform.position, x.transform.position)).FirstOrDefault().gameObject;
        }
    }

    /*private void FindNearestTurret()
    {

        _visibleTurretList.Clear();

        for (int i = 0; i < _turretList.Count; i++)
        {
            _ray = new Ray(transform.position, _turretList[i].transform.position - transform.position + Vector3.up * 0.3f);
            if (Physics.Raycast(_ray.origin, _ray.direction, out _hit, 16, _layermask, QueryTriggerInteraction.Ignore))
            {
                if (_hit.collider.TryGetComponent(out Turret turret) && turret == _turretList[i])
                {
                    _visibleTurretList.Add(_turretList[i]);
                }
            }
        }

        if (_visibleTurretList.Count > 0)
        {
            _target = _visibleTurretList.OrderBy(x => Vector3.Distance(_hero.transform.position, x.transform.position)).FirstOrDefault().gameObject;
        }
    }*/

    private void RotateToNeares()
    {
        if (_target != null)
        {
            _redTarget.ActivateImage();
            _redTarget.transform.position = _target.transform.position;
            _redTarget.SetImageScale(_target.transform.localScale);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(_target.transform.position.x, _target.transform.position.y + 0.4f, _target.transform.position.z) - transform.position), 0.1f);
        }

        if (_target == null)
        {
            if (_redTarget != null)
            {
                _redTarget.DeactivateImage();
            }
        }
    }
}
