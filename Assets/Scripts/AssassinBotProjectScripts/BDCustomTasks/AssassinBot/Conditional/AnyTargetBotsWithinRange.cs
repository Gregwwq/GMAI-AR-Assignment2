using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class AnyTargetBotsWithinRange : Conditional
{
    public override TaskStatus OnUpdate()
    {
        GameObject[] targetBots = GameObject.FindGameObjectsWithTag("Target");

        foreach (GameObject bot in targetBots)
        {
            // if any one of the target bots are within 15m, return success
            if (Vector3.Distance(transform.position, bot.transform.position) <= 15)
            {
                return TaskStatus.Success;
            }
        }

        return TaskStatus.Failure;
    }
}