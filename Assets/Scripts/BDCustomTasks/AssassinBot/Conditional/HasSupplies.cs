using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class HasSupplies : Conditional
{
    public SharedInt disguiseCount, invisCount, decoyCount;

    bool done;

    public override void OnStart()
    {
        done = false;

        Debug.Log("checking if assassin has enough supplies");
    }

    public override TaskStatus OnUpdate()
    {
        if (disguiseCount.Value == 0 || invisCount.Value  == 0 || decoyCount.Value  == 0)
        {
            done = true;
            return TaskStatus.Failure;
        }
        else return TaskStatus.Success;
    }

    public override void OnEnd()
    {
        if (done)
        {
            Debug.Log("not enough supplies");
        }
    }
}