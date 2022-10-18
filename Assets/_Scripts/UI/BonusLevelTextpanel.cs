using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BonusLevelTextpanel : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(MovePanelUp), 2f);
    }

    private void MovePanelUp()
    {
        transform.DOMoveY(4000, 6f); 
    }
}
