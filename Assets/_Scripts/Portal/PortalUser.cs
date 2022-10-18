using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalUser : MonoBehaviour
{
    [SerializeField] private FinishAction _finishAction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Portal portal))
        {
            _finishAction.Finish(FinishAction.FinishEnum.VICTORY);

            gameObject.SetActive(false);

            portal.UsePortal();
        }
    }

    
}
