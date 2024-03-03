using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items")]
public class Item : ScriptableObject
{
    [SerializeField] Skill skill;
    [SerializeField] bool stackable;
    public int maxStack;
    public float cooldown;
    public string id;
    public Sprite sprite;
    public void UseItem(){
        skill.Activate();
    }
}
