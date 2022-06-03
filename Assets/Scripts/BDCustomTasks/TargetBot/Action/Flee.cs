using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Target Bot")]
public class Flee : Action
{
    public SharedFloat Speed, RotateSpeed;

    Transform assassin;

    public override void OnAwake()
    {
        assassin = GameObject.Find("AssassinBot").transform;
    }

    public override TaskStatus OnUpdate()
    {
        // setting the target location to be slightly infront of the target bot
        // when it is facing away from the assassin bot
        Vector3 targetLocation = transform.position + (transform.position - assassin.position);

        // setting the target rotation to face the target location
        Quaternion lookRotation = Quaternion.LookRotation((targetLocation - transform.position), Vector3.up);

        // moving towards the target location
        transform.position =
            Vector3.MoveTowards(transform.position, targetLocation, Speed.Value * Time.deltaTime);

        // smoothly rotating towards the target rotation
        transform.rotation =
            Quaternion.RotateTowards(transform.rotation, lookRotation, RotateSpeed.Value * Time.deltaTime);

        return TaskStatus.Running;
    }
}