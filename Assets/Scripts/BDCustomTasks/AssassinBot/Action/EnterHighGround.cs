using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class EnterHighGround : Action
{
    public override TaskStatus OnUpdate()
    {
        Transform highGround = GameObject.Find("High Ground").transform;

        transform.position = highGround.Find("Standing Spot").position;

        return TaskStatus.Success;
    }
}