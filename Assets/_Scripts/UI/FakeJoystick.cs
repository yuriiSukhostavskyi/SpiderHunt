using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeJoystick : MonoBehaviour
{
    [SerializeField] private GameObject _fakeJoystick;
    [SerializeField] private FinishAction _finishAction;

    private bool _push = false;
    public bool Push => _push;

    public void PointerDown()
    {
        _fakeJoystick.SetActive(false);
        _push = true;
    }

    public void PointerUp()
    {
        if (_finishAction.FinishBool == false)
        {
            _fakeJoystick.SetActive(true);
        }
        _push = false;
    }
}
