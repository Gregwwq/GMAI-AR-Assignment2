using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class RunAway : Action
{
    public SharedBool InvisActive, DecoyActive;
    public SharedFloat Speed, RotateSpeed;

    bool done;

    GameObject[] targetBots;
    Vector3 centralLocation, nearest;

    public override void OnStart()
    {
        done = false;

        Debug.Log("running away...");
    }

    public override TaskStatus OnUpdate()
    {
        targetBots = GameObject.FindGameObjectsWithTag("Target");

        FindNearestTarget();
        if (Vector3.Distance(transform.position, nearest) > 25f && !DecoyActive.Value)
        {
            done = true;
            InvisActive = false;
            return TaskStatus.Success;
        }

        FindCentralPointOfTargets();
        Run();

        return TaskStatus.Running;
    }

    public override void OnEnd()
    {
        if (done)
        {
            Debug.Log("escaped successfully");
        }
    }

    // function to calculate and set the average central location of all alive target bots
    void FindCentralPointOfTargets()
    {
        float x = 0f;
        float z = 0f;

        foreach (GameObject bot in targetBots)
        {
            // adding total x and z position of all alive target bots
            x += bot.transform.position.x;
            z += bot.transform.position.z;
        }

        // dividing to get average x and z position of all alive target bots
        x /= targetBots.Length;
        z /= targetBots.Length;

        // setting the average central location of the target bots
        centralLocation = new Vector3(x, transform.position.y, z);
    }

    void Run()
    {
        // setting the target location to be slightly infront of the assassin bot
        // when it is facing away from the average central location of the target bots
        Vector3 moveLocation = transform.position + (transform.position - centralLocation);

        // setting the target rotation
        Quaternion lookRotation = Quaternion.LookRotation((moveLocation - transform.position), Vector3.up);

        // moving towards the target location
        transform.position =
            Vector3.MoveTowards(transform.position, moveLocation, Speed.Value * Time.deltaTime);
        
        // smoothly rotating towards the target rotation
        transform.rotation =
            Quaternion.RotateTowards(transform.rotation, lookRotation, RotateSpeed.Value * Time.deltaTime);
    }

    // function to find the nearest target bot to the assassin bot
    void FindNearestTarget()
    {
        // setting the inital closest distance to the largest possible
        float closestDist = Mathf.Infinity;

        foreach (GameObject bot in targetBots)
        {
            float dist = Vector3.Distance(transform.position, bot.transform.position);

            // checking if the distance between this target bot and the assassin bot is the smallest
            if (dist < closestDist)
            {
                // setting the cloesest target and the closest distance value
                nearest = bot.transform.position;
                closestDist = dist;
            }
        }
    }
}