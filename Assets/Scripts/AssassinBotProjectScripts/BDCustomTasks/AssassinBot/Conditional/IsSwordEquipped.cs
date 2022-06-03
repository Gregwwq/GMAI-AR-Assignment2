using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class IsSwordEquipped : Conditional
{
    public SharedArsenal Weapon;

    public override TaskStatus OnUpdate()
    {
        return Weapon.Value == Arsenal.Sword ? TaskStatus.Success : TaskStatus.Failure;
    }
}