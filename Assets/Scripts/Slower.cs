using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slower : Enemy
{
    [SerializeField] float _slowAmount = .05f;
    protected override void PlayerImpact(Player player) {
        // base.PlayerImpact(player);
        TankController controller = player.GetComponent<TankController>();
        //cap how much speed the player can lose
        if(controller != null && controller.MaxSpeed > (_slowAmount + 0.01f)){
            controller.MaxSpeed -= _slowAmount;
        }
    }
}
