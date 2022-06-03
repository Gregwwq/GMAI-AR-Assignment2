using UnityEngine;
using BehaviorDesigner.Runtime;

public enum Arsenal { None, Sword, ThrowingKnife, Sniper };

[System.Serializable]
public class SharedArsenal : SharedVariable<Arsenal>
{
    Arsenal Weapon;
    public static implicit operator SharedArsenal(Arsenal value)
    {
        return new SharedArsenal { Weapon = value };
    }
}