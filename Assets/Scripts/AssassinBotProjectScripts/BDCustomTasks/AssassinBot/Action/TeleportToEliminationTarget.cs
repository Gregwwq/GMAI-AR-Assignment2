using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class TeleportToEliminationTarget : Action
{
    public SharedGameObject EliminationTarget;

    bool done;
    float elap;

    public override void OnStart()
    {
        done = false;
        elap = 0f;

        Debug.Log("teleporting to target");
    }

    public override TaskStatus OnUpdate()
    {
        if (elap >= 0.3f)
        {
            Teleport();
            done = true;
            return TaskStatus.Success;
        }
        else
        {
            elap += Time.deltaTime;
            return TaskStatus.Running;
        }
    }

    void Teleport()
    {
        // setting the assassin bot's position to slightly infront of the elimination target
        transform.position = (EliminationTarget.Value.transform.position + EliminationTarget.Value.transform.forward);

        // making the assassin bot face the elimination target
        transform.eulerAngles = EliminationTarget.Value.transform.eulerAngles + (180f * Vector3.up);
    }

    public override void OnEnd()
    {
        if (done)
        {
            Debug.Log("brandishing the sword...");
        }
    }
}