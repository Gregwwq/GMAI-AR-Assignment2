using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Target Bot")]
public class Scream : Action
{
    public override TaskStatus OnUpdate()
    {
        GameObject[] targetBots = GameObject.FindGameObjectsWithTag("Target");

        foreach(GameObject bot in targetBots)
        {
            if (bot != gameObject)
            {
                bot.GetComponent<BehaviorTree>().SetVariable("Chasing", (SharedBool)true);
            }
        }

        return TaskStatus.Success;
    }
}