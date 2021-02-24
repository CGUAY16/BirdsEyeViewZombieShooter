using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCam : MonoBehaviour
{
    // Variables
    [SerializeField] float nearCamHeight;
    [SerializeField] float middleCamHeight;
    [SerializeField] float farCamHeight;

    float xPos;
    float yPos;
    float zPos;
    Vector3 camInitialPos;
    public GameObject camTarget;
    Vector3 offset;
    int cameraSettingNum;
    float zAxisOffset = 1.5f;

    public float damping = 1;

    // Start is called before the first frame update
    void Start()
    {
        cameraSettingNum = 0;
        xPos = camTarget.transform.position.x;
        yPos = camTarget.transform.position.y + nearCamHeight;
        zPos = camTarget.transform.position.z - zAxisOffset;
        camInitialPos = new Vector3(xPos , yPos , zPos);

        transform.position = camInitialPos;

        offset = transform.position - camTarget.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2)){
            //Change Cam view to near player cam, then to middle cam and then far cam
            //So player can cycle through the cam views.
            if(cameraSettingNum == 0)
            {
                FromNearToMid();
                cameraSettingNum = 1;
            }
            else if (cameraSettingNum == 1)
            {
                FromMidToFar();
                cameraSettingNum = 2;
            }
            else
            {
                FromFarToNear();
                cameraSettingNum = 0;
            }
        }
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = camTarget.transform.position + offset;
        transform.position = desiredPosition;

        // applies smooth transition between current pos of cam with damping and desired pos without the damp.
        Vector3 lerpPos = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);
        transform.position = lerpPos;

        transform.LookAt(camTarget.transform.position);
    }

    void FromNearToMid()
    {
        xPos = camTarget.transform.position.x;
        yPos = camTarget.transform.position.y + middleCamHeight;
        zPos = camTarget.transform.position.z - (zAxisOffset + 1.5f);
        camInitialPos = new Vector3(xPos, yPos, zPos);

        transform.position = camInitialPos;

        offset = transform.position - camTarget.transform.position;
    }

    void FromMidToFar()
    {
        xPos = camTarget.transform.position.x;
        yPos = camTarget.transform.position.y + farCamHeight;
        zPos = camTarget.transform.position.z - (zAxisOffset + 3f);
        camInitialPos = new Vector3(xPos, yPos, zPos);

        transform.position = camInitialPos;

        offset = transform.position - camTarget.transform.position;
    }

    void FromFarToNear()
    {
        xPos = camTarget.transform.position.x;
        yPos = camTarget.transform.position.y + nearCamHeight;
        zPos = camTarget.transform.position.z - zAxisOffset;
        camInitialPos = new Vector3(xPos, yPos, zPos);

        transform.position = camInitialPos;

        offset = transform.position - camTarget.transform.position;
    }
}
