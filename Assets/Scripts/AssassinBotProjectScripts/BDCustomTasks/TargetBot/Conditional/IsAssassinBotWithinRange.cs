using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Target Bot")]
public class IsAssassinBotWithinRange : Conditional
{
    public float Range;

    public override TaskStatus OnUpdate()
    {
        Transform assassin = GameObject.Find("AssassinBot").transform;

        float dist = Vector3.Distance(transform.position, assassin.position);
        
        return dist <= Range ? TaskStatus.Success : TaskStatus.Failure;
    }
}