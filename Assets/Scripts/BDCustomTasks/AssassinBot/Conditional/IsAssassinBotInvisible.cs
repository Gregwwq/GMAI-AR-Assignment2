using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class IsAssassinBotInvisible : Conditional
{
    public SharedBool InvisActive;
    
    public override TaskStatus OnUpdate()
    {
        return InvisActive.Value ? TaskStatus.Success : TaskStatus.Failure;
    }
}