using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDieAction : MonoBehaviour
{
    [SerializeField] private HeroSettings _heroSettings;
    [SerializeField] private HPBar _hpBar;
    [SerializeField] private DamagePanel _damagePanel;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private HeroShards _heroShards;
    [SerializeField] private FinishAction _finishAction;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject _decal;

    private float _health;
    private bool _dieBool = false;

    private void OnEnable()
    {
        _health = Saves.Get.GetFloat(Keys.CurrentHealth);
        //TakeDamage(99, transform.position);
    }

    public void TakeDamage(float damage, Vector3 position)
    {
        _damagePanel.ShowDamage();

        Sound.Instance.HeroTakeDamageSound();
        Vibration.Instance.MiddleVibrate();

        _rigidbody.isKinematic = false;
        _rigidbody.velocity = (transform.position - position).normalized * 15;

        _health -= damage;
        Saves.Get.AddFloat(Keys.CurrentHealth, Saves.Get.GetFloat(Keys.CurrentHealth) - damage);

        _hpBar.UpdateHPBar(_health, Saves.Get.GetFloat(Keys.TotalHealth), damage);

        if (_health <= 0)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.y < 0)
        {
            Die();
        }
    }

    public void TakeHeal(float heal)
    {
        _health += heal;

        Saves.Get.AddFloat(Keys.CurrentHealth, Saves.Get.GetFloat(Keys.CurrentHealth) + heal);

        if (Saves.Get.GetFloat(Keys.CurrentHealth) > Saves.Get.GetFloat(Keys.TotalHealth))
        {
            Saves.Get.AddFloat(Keys.CurrentHealth, Saves.Get.GetFloat(Keys.TotalHealth));
            _health = Saves.Get.GetFloat(Keys.TotalHealth);
        }

        _hpBar.UpdateHPBar(_health, Saves.Get.GetFloat(Keys.TotalHealth));

        Sound.Instance.HealBoostSound();
        Vibration.Instance.MiddleVibrate();
    }

    public void Die()
    {
        if (_dieBool == false) {

        //Saves.Get.AddInt(Keys.LevelNumber, 0);

        _dieBool = true;

        _finishAction.Finish(FinishAction.FinishEnum.DEFEAT);

        HeroShards newHeroShards = Instantiate(_heroShards, transform.position, transform.rotation);
        newHeroShards.AddRandomExplosion(transform.position);

        Instantiate(_explosion, transform.position, Quaternion.identity);
        Instantiate(_decal, transform.position + Vector3.up * 0.1f, Quaternion.Euler(-90, 0, 0));

        Sound.Instance.ExplosionSound();
        Vibration.Instance.BigVibrate();
        Shake.Instance.ShakeAction();

        gameObject.SetActive(false);
        }
    }
}
