using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class IsCaught : Conditional
{
    public SharedBool Caught;

    public override TaskStatus OnUpdate()
    {
        // return success or failure depending on whether caught is true or false respecitvely
        return Caught.Value ? TaskStatus.Success : TaskStatus.Failure;
    }
}