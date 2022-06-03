using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Target Bot")]
public class ChaseAssassinBot : Action
{
    public SharedFloat Speed, RotateSpeed;

    Transform assassin;

    public override void OnAwake()
    {
        assassin = GameObject.Find("AssassinBot").transform;
    }

    public override TaskStatus OnUpdate()
    {
        if (Vector3.Distance(transform.position, assassin.position) < 1f)
        {
            return TaskStatus.Success;
        }

        Chase();

        return TaskStatus.Running;
    }

    void Chase()
    {
        // setting the target rotation to face the assassin
        Quaternion lookRotation = Quaternion.LookRotation((assassin.position - transform.position), Vector3.up);

        // moving towards the assassin
        transform.position =
            Vector3.MoveTowards(transform.position, assassin.position, Speed.Value * Time.deltaTime);

        // smoothly rotating towards the target rotation
        transform.rotation =
            Quaternion.RotateTowards(transform.rotation, lookRotation, RotateSpeed.Value * Time.deltaTime);
    }
}