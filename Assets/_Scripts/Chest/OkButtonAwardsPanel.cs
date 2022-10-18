using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkButtonAwardsPanel : MonoBehaviour
{
    [SerializeField] private AwardsPanel _awardsPanel;
    public void PointerDown()
    {
        _awardsPanel.TakeAwards();
    }
}
