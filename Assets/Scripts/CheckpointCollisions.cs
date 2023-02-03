using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCollisions : MonoBehaviour {
    public CheckpointManager checkpointManager;
    private int checkpointNum;

    // Start is called before the first frame update
    void Start() {
        if (gameObject.CompareTag("Checkpoint1")) {
            checkpointNum = 1;
        }
        if (gameObject.CompareTag("Checkpoint2")) {
            checkpointNum = 2;
        }
        if (gameObject.CompareTag("Checkpoint3")) {
            checkpointNum = 3;
        }
        if (gameObject.CompareTag("Checkpoint4")) {
            checkpointNum = 4;
        }
        if (gameObject.CompareTag("Checkpoint5")) {
            checkpointNum = 5;
        }
        if (gameObject.CompareTag("Checkpoint6")) {
            checkpointNum = 6;
        }
        if (gameObject.CompareTag("Checkpoint7")) {
            checkpointNum = 7;
        }
        if (gameObject.CompareTag("Checkpoint8")) {
            checkpointNum = 8;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.CompareTag("Player")) {
            checkpointManager.setCheckpoint(checkpointNum);
        }
    }
}
