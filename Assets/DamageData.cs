using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element
{
    Fire,
    Ice, 
    Ground,
    Wind
}

public struct DamageData 
{
    public float Damage;
    public Element damageType;
    public DamageData(float Dam,Element type)
    {
        Damage = Dam;
        damageType = type;
    }
}
