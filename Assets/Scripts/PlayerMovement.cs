using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 1.2f;
    public float RotateSpeed = 180f;
    public float Gravity = 5f;

    Joystick js;

    Transform cam;
    float down;

    void Start()
    {
        js = FindObjectOfType<Joystick>();
        cam = Camera.main.transform;

        down = 1f;
    }

    void Update()
    {
        float hori = js.Horizontal;
        float vert = js.Vertical;

        if(hori != 0 || vert != 0)
        {
            Vector3 right = new Vector3(cam.right.x, 0, cam.right.z);
            Vector3 forward = new Vector3(cam.forward.x, 0, cam.forward.z);
            
            Vector3 move = ((hori * right) + (vert * forward)).normalized;
            move += transform.position;

            transform.position = Vector3.MoveTowards(transform.position, move, Speed * Time.deltaTime);

            Quaternion lookRot = Quaternion.LookRotation((move - transform.position), Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, RotateSpeed * Time.deltaTime);
        }

        // down += 0.1f;
        // if (down > 1) down = 1;

        // Vector3 downVector = transform.position - (down * Vector3.up);

        // float gravity = down < 0 ? 15f : Gravity;

        // if (downVector.y > 0)
        // {
        //     transform.position = Vector3.MoveTowards(transform.position, downVector, gravity * Time.deltaTime);
        // }
        // else
        // {
        //     Vector3 minimumDown = new Vector3(transform.position.x, 0, transform.position.z);

        //     transform.position = Vector3.MoveTowards(transform.position, minimumDown, gravity * Time.deltaTime);
        // }
    }

    public void Jump()
    {
        down = -5f;
    }
}