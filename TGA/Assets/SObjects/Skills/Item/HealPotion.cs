using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "skills/healPotion")]
public class HealPotion : Skill
{
    private Player player;
    public override void Activate()
    {
        player = Player.FindObjectOfType<Player>();
        player.hp += Random.Range(30, 60);
    }
}
