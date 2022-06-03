using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Decoy")]
public class DecoyBehavior : Action
{
    bool done;
    Vector3 targetLocation;
    float speed, rotateSpeed, elap;

    public override void OnAwake()
    {
        speed = 0.2f;
        rotateSpeed = 200f;
    }

    public override void OnStart()
    {
        done = false;
        elap = 0f;

        SetNewPosition();
    }

    public override TaskStatus OnUpdate()
    {
        if (elap >= 6f)
        {
            return TaskStatus.Success;
        }
        else elap += Time.deltaTime;

        if (Vector3.Distance(transform.position, targetLocation) < 0.001f)
        {
            SetNewPosition();
        }

        Move();

        return TaskStatus.Running;
    }

    void Move()
    {
        // setting the target rotation
        Quaternion lookRotation = Quaternion.LookRotation((targetLocation - transform.position), Vector3.up);

        // using Vector3.MoveTowards() to move from the current location to the target position
        transform.position =
            Vector3.MoveTowards(transform.position, targetLocation, speed * Time.deltaTime);

        // using Quaternion.RotateTowards() to smoothly rotate towards the target rotation
        transform.rotation =
            Quaternion.RotateTowards(transform.rotation, lookRotation, rotateSpeed * Time.deltaTime);
    }

    void SetNewPosition()
    {
        // setting the boundaries of the targt location
        float minX = transform.position.x - 3;
        float maxX = transform.position.x + 3;
        float minZ = transform.position.z - 3;
        float maxZ = transform.position.z + 3;

        // setting the random target location within the boundaries
        targetLocation = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ));
    }
}