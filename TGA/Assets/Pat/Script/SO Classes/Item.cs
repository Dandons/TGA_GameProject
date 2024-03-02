using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items")]
public class Item : ScriptableObject
{
    [SerializeField] Skill skill;
    [SerializeField] bool stackable;
    public int maxStack{get;}
    public float cooldown{get;}
    public string id{get;}
    public Sprite sprite{get;}
    public void UseItem(){
        skill.Activate();
    }
}
