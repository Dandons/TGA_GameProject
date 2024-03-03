using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =("Weapon/profile"))]
public class WeaponProfile : ScriptableObject 
{
    [HideInInspector]public enum AttackType{
        Melee,
        Range
    }
    [HideInInspector] public enum WeaponType{
        Bow,
        Sword,
        Polearm,
        Dagger,
        NoWeapon
    }
    public WeaponType weaponType;
    public AttackType attackType;
    public Skill lightAttack;
    public Skill heavyAttack;
    public Skill block;
    public Skill[] skill = new Skill[4];
}
