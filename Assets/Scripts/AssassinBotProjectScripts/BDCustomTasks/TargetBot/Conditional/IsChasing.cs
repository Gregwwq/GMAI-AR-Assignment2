using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Target Bot")]
public class IsChasing : Conditional
{
    public SharedBool Chasing;
    
    public override TaskStatus OnUpdate()
    {
        return Chasing.Value ? TaskStatus.Success : TaskStatus.Failure;
    }
}