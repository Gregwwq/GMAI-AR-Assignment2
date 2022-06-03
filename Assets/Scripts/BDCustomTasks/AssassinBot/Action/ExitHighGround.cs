using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class ExitHighGround : Action
{
    public override TaskStatus OnUpdate()
    {
        Transform highGround = GameObject.Find("High Ground").transform;

        transform.position = (highGround.position + (highGround.forward * 3));

        return TaskStatus.Success;
    }
}