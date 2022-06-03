using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Target Bot")]
public class Die : Action
{
    public override TaskStatus OnUpdate()
    {
        // getting a random direction to topple, left or right
        // and toppling in that respective directions
        int side = Random.Range(0, 2);
        switch(side)
        {
            case 0:
                transform.eulerAngles =  transform.eulerAngles + (90f * Vector3.forward);
                break;
            
            case 1:
                transform.eulerAngles =  transform.eulerAngles - (90f * Vector3.forward);;
                break;
        }

        // alleviating the target bot abit to prevent it from clipping into the ground
        transform.position = new Vector3(transform.position.x, 0.4f, transform.position.z);

        gameObject.tag = "DeadTarget";

        return TaskStatus.Success;
    }
}