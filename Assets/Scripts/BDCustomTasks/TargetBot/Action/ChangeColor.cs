using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Target Bot")]
public class ChangeColor : Action
{
    public enum Colour{ Green, Red, Blue, Black }
    public Colour color;

    GameObject head, body;

    public override void OnAwake()
    {
        // assigning the respective parts of the target bot
        head = transform.Find("Head").gameObject;
        body = transform.Find("Body").gameObject;
    }

    public override TaskStatus OnUpdate()
    {
        switch (color)
        {
            case Colour.Green:
                Change(Color.green);
                break;

            case Colour.Red:
                Change(Color.red);
                break;

            case Colour.Blue:
                Change(Color.blue);
                break;

            case Colour.Black:
                Change(Color.black);
                break;
        }
        return TaskStatus.Success;
    }

    // function to change the color of the target bot except for its wheels
    public void Change(Color _color)
    {
        head.GetComponent<Renderer>().material.color = _color;
        body.GetComponent<Renderer>().material.color = _color;

        Renderer[] renderers = body.GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            renderer.material.color = _color;
        }
    }
}