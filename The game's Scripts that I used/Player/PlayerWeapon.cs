using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] float cooldownBetweenEachShot = 0.25f;
    [SerializeField] BlasterShot playerBulletPrefab;
    [SerializeField] LayerMask aimLayerMask;
    [SerializeField] Transform firePoint; 
       
    float bulletShotTime;
    

    // Update is called once per frame
    void Update()
    {

        Aim();

        if (ReadyToFireGun() && (Input.GetKey(KeyCode.Mouse0)) )
        {
            FireGun();
        }


    }

    void Aim()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, aimLayerMask)) {
            var destination = hitInfo.point;
            destination.y = transform.position.y;

            Vector3 direction = destination - transform.position;
            direction.Normalize();
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
    }

    bool ReadyToFireGun() => Time.time >= bulletShotTime;
    

    void FireGun()
    {
        float totalDelay = cooldownBetweenEachShot;
        foreach(var powerup in pUpList)
        {
            totalDelay = totalDelay * (powerup.DelayMultiplier);
        }

        bulletShotTime = Time.time + totalDelay;
        BlasterShot fireBullet = Instantiate(playerBulletPrefab, firePoint.position, transform.rotation);
        fireBullet.Launch(transform.forward);
    }

    //
    // Power Up functions
    //

    List<PowerUp> pUpList = new List<PowerUp>();

    public void AddPowerup(PowerUp powerUp) => pUpList.Add(powerUp);

    public void RemovePowerup(PowerUp powerUp) => pUpList.Remove(powerUp);
}
