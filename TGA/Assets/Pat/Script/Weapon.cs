using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Singleton<Weapon>
{
    public WeaponProfile sword;
    public WeaponProfile bow;
    public WeaponProfile dagger;
    public WeaponProfile polearm;
    private Dictionary<WeaponProfile.WeaponType, WeaponProfile> weapons = new Dictionary<WeaponProfile.WeaponType, WeaponProfile>();
    [HideInInspector] WeaponProfile.WeaponType currentWeapon;
    public Skill LightAttack()
    {
        return weapons[currentWeapon].lightAttack;
    }
    public Skill HeavyAttack()
    {
        return weapons[currentWeapon].heavyAttack;
    }
    public Skill Block()
    {
        return weapons[currentWeapon].block;
    }
    public Skill skill(int skillIndex)
    {
        return weapons[currentWeapon].skill[skillIndex];
    }
    public void ChangeWeapon(WeaponProfile.WeaponType weapon)
    {
        currentWeapon = weapon;
    }
}
