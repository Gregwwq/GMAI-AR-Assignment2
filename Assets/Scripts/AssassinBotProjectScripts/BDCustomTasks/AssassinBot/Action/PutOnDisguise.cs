using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class PutOnDisguise : Action
{
    public SharedInt DisguiseCount;

    bool done;

    GameObject original, disguise, invisible;

    float elap;

    public override void OnAwake()
    {
        original = transform.Find("Original").gameObject;
        disguise = transform.Find("Disguise").gameObject;
        invisible = transform.Find("Invisible").gameObject;
    }

    public override void OnStart()
    {
        done = false;
        elap = 0f;

        Debug.Log("putting on a disguise...");
    }

    public override TaskStatus OnUpdate()
    {
        // adding a slight delay to signify putting on of the disguise
        if(elap >= 1f)
        {
            original.SetActive(false);
            disguise.SetActive(true);
            invisible.SetActive(false);

            DisguiseCount.Value--;

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
            Debug.Log("disguise done");
            Debug.Log(DisguiseCount.Value + " disguise left");
        }
    }
}