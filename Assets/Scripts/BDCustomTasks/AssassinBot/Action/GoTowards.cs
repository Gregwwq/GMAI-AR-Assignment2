using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Movement")]
public class GoTowards : Action
{
    public SharedGameObject Target;
    public SharedFloat Speed, RotateSpeed;

    bool done;

    public override void OnStart()
    {
        done = false;
    }

    public override TaskStatus OnUpdate()
    {
        if (Vector3.Distance(transform.position, Target.Value.transform.position) < 0.001f)
        {
            done = true;
            return TaskStatus.Success;
        }
        else
        {
            Move();
            return TaskStatus.Running;
        }
    }

    public override void OnEnd()
    {
        if (done)
        {
            Debug.Log("arrived");
        }
    }

    void Move()
    {
        // setting the target rotation
        Quaternion lookRotation = Quaternion.LookRotation((Target.Value.transform.position - transform.position), Vector3.up);

        // using Vector3.MoveTowards() to move from the current location to the target position
        transform.position =
            Vector3.MoveTowards(transform.position, Target.Value.transform.position, Speed.Value * Time.deltaTime);

        // using Quaternion.RotateTowards() to smoothly rotate towards the target rotation
        transform.rotation =
            Quaternion.RotateTowards(transform.rotation, lookRotation, RotateSpeed.Value * Time.deltaTime);
    }
}