using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterShot : MonoBehaviour
{
    [SerializeField] float speed = 15f;
    [SerializeField] float destroyTime = 5f;
    [SerializeField] GameObject playerBullet;

    public void Launch(Vector3 direction)
    {
        direction.Normalize();
        GetComponent<Rigidbody>().velocity = direction * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);
        
        
        
            
    }

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

}
