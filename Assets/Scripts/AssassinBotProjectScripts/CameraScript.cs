using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float OffsetX, OffsetY, OffsetZ, XAngleOffset;

    Transform assassin;
    float damping = 5f;

    void Start()
    {
        assassin = GameObject.Find("AssassinBot").transform;
    }

    void Update()
    {
        transform.position = 
            Vector3.Lerp(
                transform.position, 
                assassin.TransformPoint(new Vector3(OffsetX, OffsetY, OffsetZ)),
                damping * Time.deltaTime
            );

        transform.rotation = 
            Quaternion.Slerp(
                transform.rotation,
                Quaternion.Euler(new Vector3(XAngleOffset, assassin.eulerAngles.y, assassin.eulerAngles.z)),
                damping * Time.deltaTime
            );
    }
}
