using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCube : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    public Rigidbody PublicRigidbody => _rigidbody;
}
