using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    private Quaternion _initialRotation;

    void Start()
    {
        _initialRotation = Quaternion.identity;
    }

    void LateUpdate()
    {
        transform.rotation = _initialRotation;
    }
}

