using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class AimSniper : Action
{
    public SharedGameObject EliminationTarget;

    float elap;

    Transform head;
    LineRenderer line;

    public override void OnAwake()
    {
        head = transform.Find("Original").Find("Head");
        line = GetComponent<LineRenderer>();
    }

    public override void OnStart()
    {
        elap = 0f;

        line.enabled = true;
    }

    public override TaskStatus OnUpdate()
    {
        if (elap >= 1.9f)
        {
            return TaskStatus.Success;
        }
        else
        {
            Debug.Log("firing in " + Mathf.Round(3f - elap));

            transform.LookAt(new Vector3(EliminationTarget.Value.transform.position.x, transform.position.y, EliminationTarget.Value.transform.position.z));

            Vector3 targetHead = EliminationTarget.Value.transform.Find("Head").position;

            line.SetPosition(0, head.position);
            line.SetPosition(1, targetHead);

            elap += Time.deltaTime;
            return TaskStatus.Running;
        }
    }

    public override void OnEnd()
    {
        line.enabled = false;
    }
}