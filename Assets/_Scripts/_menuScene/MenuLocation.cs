using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuLocation : MonoBehaviour
{
    private void OnEnable()
    {
        transform.position =new Vector3 (0, -11, 0);

        transform.DOMoveY(0, 2.15f);
    }
}
