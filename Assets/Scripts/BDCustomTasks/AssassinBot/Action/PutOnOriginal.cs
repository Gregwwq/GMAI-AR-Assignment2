using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class PutOnOriginal : Action
{
    public SharedBool InvisActive;

    GameObject original, disguise, invisible;

    public override void OnAwake()
    {
        original = transform.Find("Original").gameObject;
        disguise = transform.Find("Disguise").gameObject;
        invisible = transform.Find("Invisible").gameObject;
    }

    public override TaskStatus OnUpdate()
    {
        original.SetActive(true);
        disguise.SetActive(false);
        invisible.SetActive(false);

        InvisActive.Value = false;
        
        return TaskStatus.Success;
    }
}