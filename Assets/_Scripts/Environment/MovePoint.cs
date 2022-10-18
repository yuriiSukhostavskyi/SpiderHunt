using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private float x, y;
    [SerializeField] private GameObject _vfx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PhysicHeroMover physicHeroMover))
        {
            Instantiate(_vfx, transform.position + Vector3.up * 0.1f, Quaternion.Euler(90, 0, 0));

            //Sound.Instance.MovePointSound();
            //Vibration.Instance.ShortVibrate();

            physicHeroMover.ResetMovePointCooldown(transform.rotation);

            physicHeroMover.transform.position = new Vector3(transform.position.x, physicHeroMover.transform.position.y, transform.position.z);
            physicHeroMover.transform.rotation = transform.rotation;
            physicHeroMover.SetExtraSpeed();
        }
    }

    private void FixedUpdate()
    {
        x += Time.deltaTime * 1.2f;
        if (x > 1) { x -= 1; }
        if (y > 1) { y -= 1; }

        _material.mainTextureOffset = new Vector2(x, y);
    }
}
