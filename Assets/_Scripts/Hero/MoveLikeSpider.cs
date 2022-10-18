using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLikeSpider : MonoBehaviour
{
    private bool _moveLikeSpider; // true

    public bool PublicMoveLikeSpider => _moveLikeSpider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Key _))
        {
            _moveLikeSpider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Key _))
        {
            _moveLikeSpider = false;
        }
    }
}
