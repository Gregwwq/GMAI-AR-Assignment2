using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Target Bot")]
public class CatchAssassinBot : Action
{
    public SharedBool Caught;

    public override TaskStatus OnUpdate()
    {
        GameObject[] targetBots = GameObject.FindGameObjectsWithTag("Target");

        foreach(GameObject bot in targetBots)
        {
            bot.GetComponent<BehaviorTree>().SetVariable("Chasing", (SharedBool)false);
        }

        Caught.Value = true;
        return TaskStatus.Success;
    }   
}