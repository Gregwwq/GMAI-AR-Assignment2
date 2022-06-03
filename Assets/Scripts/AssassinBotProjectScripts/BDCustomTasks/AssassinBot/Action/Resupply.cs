using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class Resupply : Action
{
    public SharedInt disguiseCount, invisCount, decoyCount, throwingKnives, sniperBullets;

    bool done;

    Transform resupplyStation;

    float elap;

    public override void OnAwake()
    {
        resupplyStation = GameObject.Find("Resupply Station").transform;
    }

    public override void OnStart()
    {
        done = false;
        elap = 0f;

        Debug.Log("going to the resupply station");
    }

    public override TaskStatus OnUpdate()
    {

        // delaying for 3 seconds to mimic resupplying process
        if (elap <= 3f)
        {
            Debug.Log("resupplying... time left: " + Mathf.Round(3f - elap) + "s");
            
            elap += Time.deltaTime;
            return TaskStatus.Running;
        }
        else
        {
            disguiseCount.Value = 5;
            invisCount.Value = 5;
            decoyCount.Value = 5;

            sniperBullets.Value = 1;
            throwingKnives.Value = 2;

            done = true;
            return TaskStatus.Success;
        }
    }

    public override void OnEnd()
    {
        if (done)
        {
            Debug.Log("resupply complete");
        }
    }
}