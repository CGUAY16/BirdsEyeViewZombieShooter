using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastZombie : RegZombie
{
    protected override void Start()
    {
        base.Start();
        zomValue = 500;
    }
}
