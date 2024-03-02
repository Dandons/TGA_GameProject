using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : ScriptableObject
{
    public enum TargetType
    {
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
    [HideInInspector]
    public bool avaible
    {
        get
        {
            if (Time.time >= coolDownTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
    protected float coolDownTime;
    public void SetCoolDown()
    {
        coolDownTime = Time.time + coolDown;
    }
    public virtual void Activate(float actionSoeed, float damage, float dmgAmplifier, GameObject target) 
    { 
        SetCoolDown();
    }
    public virtual void Activate(float actionSoeed, float damage, float dmgAmplifier) 
    { 
        SetCoolDown();
    }
    public virtual void Activate() 
    { 
        SetCoolDown();
    }
}
