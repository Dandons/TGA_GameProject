using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : Singleton<WeaponManager>
{
    public float animationFactor = 0;
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
    void Update()
    {
        this.GetComponent<Animator>().SetFloat("weaponFactor", animationFactor);
    }
    public void ChangeWeapon(WeaponProfile.WeaponType weapon)
    {
        StartCoroutine(OnChangingWeapon(weapon,animationFactor));
    }

    public IEnumerator OnChangingWeapon(WeaponProfile.WeaponType weapon, float currentFactor)
    {
        currentWeapon = WeaponProfile.WeaponType.NoWeapon;
        float targetFactor = 0;
        if (weapon == WeaponProfile.WeaponType.Sword) { targetFactor = 0; }
        if (weapon == WeaponProfile.WeaponType.Bow) { targetFactor = 1; }
        if (weapon == WeaponProfile.WeaponType.Polearm) { targetFactor = 2; }
        if (weapon == WeaponProfile.WeaponType.Dagger) { targetFactor = 3; }
        if (currentFactor < targetFactor)
        {
            for (int i = 0; i < (targetFactor - currentFactor) * 100; i++)
            {
                yield return new WaitForSeconds(0.5f/((targetFactor - currentFactor) * 100));
                animationFactor+=0.01f;
            }
        }
        else if(currentFactor>targetFactor)
        {
            for (int i = 0; i < ((targetFactor - currentFactor)+4) * 100; i++)
            {
                yield return new WaitForSeconds(0.5f/(((targetFactor - currentFactor)+4)*100));
                animationFactor+=0.01f;
                if(animationFactor>=4){animationFactor=0;}
            }

        }
        animationFactor=targetFactor;
        currentWeapon = weapon;
    }
}
