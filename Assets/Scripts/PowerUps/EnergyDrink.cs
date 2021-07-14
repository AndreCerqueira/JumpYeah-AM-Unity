using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrink : PowerUp
{
    // O player voa uns segundos

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void OnTriggerEnter2D(Collider2D other) {
        
        base.OnTriggerEnter2D(other);

        if (other.CompareTag("Player")) {
            Player player = other.GetComponent<Player>();

            if (player.playerState == Player.state.normal) {
                player.playerState = Player.state.energetico;
                player.StartCoroutine(player.resetState());
                player.StartCoroutine(player.flyState());
            }
        }
    }
}
