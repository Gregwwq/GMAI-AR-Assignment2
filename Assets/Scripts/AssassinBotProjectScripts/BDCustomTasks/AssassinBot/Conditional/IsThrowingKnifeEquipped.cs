using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class IsThrowingKnifeEquipped : Conditional
{
    public SharedArsenal Weapon;

    public override TaskStatus OnUpdate()
    {
        return Weapon.Value == Arsenal.ThrowingKnife ? TaskStatus.Success : TaskStatus.Failure;
    }
}