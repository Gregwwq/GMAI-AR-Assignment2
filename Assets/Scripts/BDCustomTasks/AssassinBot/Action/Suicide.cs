using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class Suicide : Action
{
    public SharedGameObject EliminationTarget;
    public SharedBool InvisActive, DecoyActive;

    bool done;

    GameObject original, disguise, invisible, dead;

    public override void OnAwake()
    {
        original = transform.Find("Original").gameObject;
        disguise = transform.Find("Disguise").gameObject;
        invisible = transform.Find("Invisible").gameObject;
        dead = transform.Find("Dead").gameObject;
    }

    public override void OnStart()
    {
        done = false;
        
        Debug.Log("assassin has been caught, committing suicide to protect its secrets...");
    }

    public override TaskStatus OnUpdate()
    {
        original.SetActive(false);
        disguise.SetActive(false);
        invisible.SetActive(false);
        dead.SetActive(true);

        EliminationTarget.Value = null;
        InvisActive.Value = false;
        DecoyActive.Value = false;
        done = true;
        return TaskStatus.Success;
    }

    public override void OnEnd()
    {
        if (done)
        {
            Debug.Log("SUICIDE: assassin bot is dead");
        }
    }
}