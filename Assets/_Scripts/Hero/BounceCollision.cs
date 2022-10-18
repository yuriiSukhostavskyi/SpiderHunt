using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceCollision : MonoBehaviour
{
    [SerializeField] private GameObject _wallVFX;
    [SerializeField] private Hero _hero;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Wall _))
        {
            Sound.Instance.WallSound();
            Vibration.Instance.ShortVibrate();

            Instantiate(_wallVFX, collision.contacts[0].point, Quaternion.identity);

            _hero.transform.DOKill(true);

            _hero.transform.localScale = new Vector3(1f, 1f, 1f);
            _hero.transform.DOShakeScale(0.2f, 0.4f, 15, 90, true);
        }
    }
}
