using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField] float duration = 1f;
    [SerializeField] float delayMultiplier;


    void OnTriggerEnter(Collider playerCol)
    {
        var playerOb = playerCol.GetComponent<PlayerWeapon>();
        if (playerOb)
        {
            Debug.Log("powerup Has been picked up!");
            playerOb.AddPowerup(this);
            GetComponent<Collider>().enabled = false;
            StartCoroutine(DisableAfterDelay(playerOb));
            Debug.Log("object bye bye");
            Destroy(this);
            //To Disable renderers for each child of gameobject parent, put them in list and disable them one by one
        }


    }

    IEnumerator DisableAfterDelay(PlayerWeapon pw)
    {
        yield return new WaitForSeconds(duration);
        pw.RemovePowerup(this);
        
    }

    public float DelayMultiplier => delayMultiplier;
}
