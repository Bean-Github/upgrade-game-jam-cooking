using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    private Quaternion _initialRotation;

    void Start()
    {
        _initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        transform.rotation = _initialRotation;
    }
}

