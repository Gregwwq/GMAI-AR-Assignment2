using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Target Bot")]
public class IsEliminationTarget : Conditional
{
    public SharedGameObject EliminationTarget;
    
    public override TaskStatus OnUpdate()
    {
        return EliminationTarget.Value == gameObject ? TaskStatus.Success : TaskStatus.Failure;
    }
}