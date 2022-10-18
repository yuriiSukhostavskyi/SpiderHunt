using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairHealth : MonoBehaviour
{
    private void Start()
    {
        Saves.Get.AddFloat(Keys.CurrentHealth, Saves.Get.GetFloat(Keys.TotalHealth));
    }
}
