using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class IsSniperEquipped : Conditional
{
    public SharedArsenal Weapon;

    public override TaskStatus OnUpdate()
    {
        return Weapon.Value == Arsenal.Sniper ? TaskStatus.Success : TaskStatus.Failure;
    }
}