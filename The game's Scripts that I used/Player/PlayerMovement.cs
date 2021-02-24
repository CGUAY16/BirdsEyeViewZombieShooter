using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = default;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 characterMovementVec = new Vector3(horizontal, 0f, vertical);
        characterMovementVec *= Time.deltaTime * speed;


        transform.Translate(characterMovementVec, Space.World);
    }
}
