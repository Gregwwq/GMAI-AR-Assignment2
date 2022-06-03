using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class DeployDecoys : Action
{
    public SharedBool DecoyActive;
    public SharedInt DecoyCount;

    bool done;

    GameObject decoyPrefab;

    float elap;
    int numOfDecoys;

    public override void OnAwake()
    {
        decoyPrefab = (GameObject) Resources.Load("Prefabs/Decoy", typeof(GameObject));        
    }

    public override void OnStart()
    {
        done = false;
        elap = 0f;
        numOfDecoys = 0;

        Debug.Log("deploying 6 decoys");
    }

    public override TaskStatus OnUpdate()
    {
        if (numOfDecoys >= 6)
        {
            DecoyCount.Value--;
            DecoyActive.Value = true;
            return TaskStatus.Success;
        }
        
        if (elap >= 0.2f)
        {
            DeployDecoy();
        }
        else elap += Time.deltaTime;

        return TaskStatus.Running;
    }

    public override void OnEnd()
    {
        if (done)
        {
            Debug.Log("all decoys have been deployed");
            Debug.Log(DecoyCount.Value + " decoy skill charges left");
        }
    }

    void DeployDecoy()
    {
        Debug.Log("deploying a decoy");

        // instantiating a decoy at the assassins current location
        GameObject decoy = GameObject.Instantiate(decoyPrefab, transform.position, Quaternion.identity);

        decoy.transform.localScale = transform.localScale / 2;

        decoy.GetComponent<BehaviorTree>().SetVariableValue("Self", decoy);

        numOfDecoys++;
        elap = 0f;
    }
}