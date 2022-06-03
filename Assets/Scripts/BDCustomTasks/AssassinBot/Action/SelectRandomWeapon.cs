using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Assassin Bot")]
public class SelectRandomWeapon : Action
{
    public SharedArsenal Weapon;
    public SharedInt ThrowingKnives, SniperBullets;

    float elap;
    int choice;

    public override void OnStart()
    {
        elap = 0f;
        
        // getting a random choice as an integer
        choice = Random.Range(0, 3);

        Debug.Log("choosing a weapon to use");
    }

    public override TaskStatus OnUpdate()
    {
        if (elap >= 1f)
        {
            Select();
            return TaskStatus.Success;
        }
        else
        {
            elap += Time.deltaTime;
            return TaskStatus.Running;
        }
    }

    void Select()
    {
        switch (choice)
        {
            case 0:
                Weapon.Value = Arsenal.Sword;
                Debug.Log("sword equipped");
                break;
            
            case 1:
                // checking if there are throwing knives left to use
                if (ThrowingKnives.Value < 1)
                {
                    Debug.Log("ran out of throwing knives, selecting another weapon");
                    choice = Random.Range(0, 2) == 0 ? 0 : 2;
                    Select();
                    return;
                }

                Weapon.Value = Arsenal.ThrowingKnife;
                Debug.Log("throwing knives equipped");
                break;
            
            case 2:
                //checking if there are sniper bulletes left to use
                if(SniperBullets.Value < 1)
                {
                    Debug.Log("ran out of sniper bullets, selecting another weapon");
                    choice = Random.Range(0, 2);
                    Select();
                    return;
                }

                Weapon.Value = Arsenal.Sniper;
                Debug.Log("sniper equipped");
                break;
        }
    }
}