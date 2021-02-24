using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUpQueue : MonoBehaviour
{

    Queue<PowerUp> powerUpQueue;

    // Start is called before the first frame update
    void Start()
    {
        powerUpQueue = new Queue<PowerUp>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
