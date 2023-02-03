using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.LightningBolt;

public class PowerCoreScript : MonoBehaviour {

    private bool charging;
    public PlayerControllerScript playerControllerScript;
    public LightningBoltScript lightningBoltEditor;
    
    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.CompareTag("Player")) {
            playerControllerScript.SetChargingStatus(true);
            lightningBoltEditor.SetEnabled(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if(collider.gameObject.CompareTag("Player")) {
            playerControllerScript.SetChargingStatus(false);
            lightningBoltEditor.SetEnabled(false);
        }
    }
}


// should charge the robot when the robot is enabled and in range