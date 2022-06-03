using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Target Bot")]
public class IsAlive : Conditional
{
    public SharedBool Alive;
    
    public override TaskStatus OnUpdate()
    {
        return Alive.Value ? TaskStatus.Success : TaskStatus.Failure;
    }
}