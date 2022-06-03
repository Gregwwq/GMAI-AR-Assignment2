using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;

public class ClickToCatchAssassin : MonoBehaviour
{
    List<GameObject> assassinParts;

    void Start()
    {
        AddParts();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                foreach (GameObject part in assassinParts)
                {
                    if (hit.transform.gameObject == part)
                    {
                        GlobalVariables.Instance.SetVariable("Caught", (SharedBool)true);
                    }
                }
            }
        }
    }

    void AddParts()
    {
        Transform assassin = GameObject.Find("AssassinBot").transform;

        assassinParts =  new List<GameObject>();

        // Original
        assassinParts.Add(assassin.Find("Original").Find("Head").gameObject);
        assassinParts.Add(assassin.Find("Original").Find("Body").gameObject);

        assassinParts.Add(assassin.Find("Original").Find("Body").Find("Arm1").gameObject);
        assassinParts.Add(assassin.Find("Original").Find("Body").Find("Arm2").gameObject);

        assassinParts.Add(assassin.Find("Original").Find("Wheels").Find("Wheel1").gameObject);
        assassinParts.Add(assassin.Find("Original").Find("Wheels").Find("Wheel2").gameObject);
        assassinParts.Add(assassin.Find("Original").Find("Wheels").Find("Wheel3").gameObject);
        assassinParts.Add(assassin.Find("Original").Find("Wheels").Find("Wheel4").gameObject);

        // Disguise
        assassinParts.Add(assassin.Find("Disguise").Find("Head").gameObject);
        assassinParts.Add(assassin.Find("Disguise").Find("Body").gameObject);

        assassinParts.Add(assassin.Find("Disguise").Find("Body").Find("Arm1").gameObject);
        assassinParts.Add(assassin.Find("Disguise").Find("Body").Find("Arm2").gameObject);

        assassinParts.Add(assassin.Find("Disguise").Find("Wheels").Find("Wheel1").gameObject);
        assassinParts.Add(assassin.Find("Disguise").Find("Wheels").Find("Wheel2").gameObject);
        assassinParts.Add(assassin.Find("Disguise").Find("Wheels").Find("Wheel3").gameObject);
        assassinParts.Add(assassin.Find("Disguise").Find("Wheels").Find("Wheel4").gameObject);

        // Invisible
        assassinParts.Add(assassin.Find("Invisible").Find("Head").gameObject);
        assassinParts.Add(assassin.Find("Invisible").Find("Body").gameObject);

        assassinParts.Add(assassin.Find("Invisible").Find("Body").Find("Arm1").gameObject);
        assassinParts.Add(assassin.Find("Invisible").Find("Body").Find("Arm2").gameObject);

        assassinParts.Add(assassin.Find("Invisible").Find("Wheels").Find("Wheel1").gameObject);
        assassinParts.Add(assassin.Find("Invisible").Find("Wheels").Find("Wheel2").gameObject);
        assassinParts.Add(assassin.Find("Invisible").Find("Wheels").Find("Wheel3").gameObject);
        assassinParts.Add(assassin.Find("Invisible").Find("Wheels").Find("Wheel4").gameObject);
    }
}
