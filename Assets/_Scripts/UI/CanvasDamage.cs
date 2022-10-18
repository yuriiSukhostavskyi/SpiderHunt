using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CanvasDamage : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private HeroSettings _heroSettings;

    public void ShowDamage(Vector3 position, float enemyScale = 1)
    {
        Vector3 random = new Vector3(Random.Range(-0.45f, 0.25f), 0, Random.Range(-0.25f, 0.45f));
        transform.position = position + random + (Vector3.up * (enemyScale * 1.5f - 1.5f));

        _text.gameObject.SetActive(true);

        _text.text ="-" + Saves.Get.GetFloat(Keys.Damage).ToString();

        transform.DOKill(true);
        transform.DOShakeScale(0.2f, 0.4f, 15, 90, true);

        Invoke(nameof(DeactivateText), 0.3f);
    }

    private void DeactivateText()
    {
        _text.gameObject.SetActive(false);
    }
}
