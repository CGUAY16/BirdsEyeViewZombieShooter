using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRotation : MonoBehaviour
{
    [SerializeField] float rotatePUp = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.Rotate(0, rotatePUp, 0); 
    }
}
