using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class EliminateTarget : Action
{
    public SharedGameObject EliminationTarget;
    public SharedArsenal Weapon;
    public SharedInt ThrowingKnives, SniperBullets;

    bool done;
    float elap;

    public override void OnStart()
    {
        done = false;
        elap = 0f;
    }

    public override TaskStatus OnUpdate()
    {
        if (elap >= 0.5f)
        {
            if (Weapon.Value == Arsenal.ThrowingKnife)
            {
                ThrowingKnives.Value--;
                Debug.Log(ThrowingKnives.Value + " throwing knives left");
            }
            else if (Weapon.Value == Arsenal.Sniper)
            {
                SniperBullets.Value--;
                Debug.Log(SniperBullets.Value + " sniper bullets left");
            }

            EliminationTarget.Value.GetComponent<BehaviorTree>().SetVariable("Alive", (SharedBool)false);

            done = true;
            return TaskStatus.Success;
        }
        else
        {
            elap += Time.deltaTime;
            return TaskStatus.Running;
        }
    }

    public override void OnEnd()
    {
        if (done)
        {
            Debug.Log("target has been eliminated");
        }
    }
}