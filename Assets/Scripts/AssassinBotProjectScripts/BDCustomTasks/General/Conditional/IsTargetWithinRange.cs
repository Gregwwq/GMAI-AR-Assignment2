using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Movement")]
public class IsTargetWithinRange : Conditional
{
    public SharedGameObject Target;
    public float Range;

    public override TaskStatus OnUpdate()
    {
        float dist = Vector3.Distance(transform.position, Target.Value.transform.position);
        
        return dist <= Range ? TaskStatus.Success : TaskStatus.Failure;
    }
}