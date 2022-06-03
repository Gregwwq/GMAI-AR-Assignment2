using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class AreThereTargetBots : Conditional
{
    bool done;

    public override void OnStart()
    {
        done = false;

        Debug.Log("waiting for targets...");
    }

    public override TaskStatus OnUpdate()
    {
        // checking if there are any target bots in the scene
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        if (targets.Length != 0)
        {
            done = true;
            return TaskStatus.Success;
        }
        else return TaskStatus.Failure;
    }

    public override void OnEnd()
    {
        if (done)
        {
            Debug.Log("targets found!");
        }
    }
}