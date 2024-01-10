using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : ScriptableObject
{
    public enum TargetType{
        auto,
        directional,
        self
    }
    public TargetType targetType;
    public float actionSoeed;
    public float staUsage;
    public float baseDmg;
    public float dmgAmplifier;
    public float shootSpeed;
    public float buffDuration;
    public float coolDown;
    public virtual void Activate(float actionSoeed,float damage,float dmgAmplifier,GameObject target){}
    public virtual void Activate(float actionSoeed,float damage,float dmgAmplifier){}
    public virtual void Activate(){}
}
