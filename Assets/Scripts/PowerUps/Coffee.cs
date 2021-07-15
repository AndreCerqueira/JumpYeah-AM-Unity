using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : PowerUp
{
    // O cafe salta mais alto.

    protected override void OnTriggerEnter2D(Collider2D other) {
        
        base.OnTriggerEnter2D(other);

        if (other.CompareTag("Player")) {
            Player player = other.GetComponent<Player>();

            if (player.playerState == Player.state.normal) {
                player.playerState = Player.state.cafe;
                player.StartCoroutine(player.resetState());
            }
        }
    }
}
