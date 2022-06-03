using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class GoTowardsTargetBots : Action
{
    public SharedFloat Speed, RotateSpeed;

    bool done;
    Vector3 targetLocation;

    public override void OnStart()
    {
        done = false;

        Debug.Log("searching for a target bot to assassinate");
    }

    public override TaskStatus OnUpdate()
    {
        GameObject[] targetBots = GameObject.FindGameObjectsWithTag("Target");

        float x = 0f;
        float z = 0f;

        foreach (GameObject bot in targetBots)
        {
            // adding the total x and z positions of all the target bots
            x += bot.transform.position.x;
            z += bot.transform.position.z;
        }

        // gettting the average x and z positions of all the target bots
        x /= targetBots.Length;
        z /= targetBots.Length;

        // setting the average position as the target location
        targetLocation = new Vector3(x, transform.position.y, z);

        Move();

        return TaskStatus.Running;
    }

    public override void OnEnd()
    {
        if (done)
        {

        }
    }

    void Move()
    {
        // setting the target rotation
        Quaternion lookRotation = Quaternion.LookRotation((targetLocation - transform.position), Vector3.up);

        // using Vector3.MoveTowards() to move from the current location to the target position
        transform.position =
            Vector3.MoveTowards(transform.position, targetLocation, Speed.Value * Time.deltaTime);

        // using Quaternion.RotateTowards() to smoothly rotate towards the target rotation
        transform.rotation =
            Quaternion.RotateTowards(transform.rotation, lookRotation, RotateSpeed.Value * Time.deltaTime);
    }
}