using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.LightningBolt;

public class CheckpointManager : MonoBehaviour {
    private int currentCheckpoint;
    public GameObject checkpoint1;
    public GameObject checkpoint2;
    public GameObject checkpoint3;
    public GameObject checkpoint4;
    public GameObject checkpoint5;
    public GameObject checkpoint6;
    public GameObject checkpoint7;
    public GameObject checkpoint8;
    public GameObject robotObject;
    public Player robotScript;
    public Battery batteryScript;
    public PlayerControllerScript playerControllerScript;
    public CameraFollow cameraScript;
    public GameObject box1;
    private Vector3 box1pos;
    public GameObject box2;
    private Vector3 box2pos;
    public GameObject box3;
    private Vector3 box3pos;
    public GameObject box4;
    private Vector3 box4pos;
    public GameObject box5;
    private Vector3 box5pos;
    public GameObject box6;
    private Vector3 box6pos;
    public ButtonScript button1;
    public TrapDoorScript trapDoor1;
    public ButtonScript button2;
    public TrapDoorScript trapDoor2;
    public ButtonScript button3;
    public TrapDoorScript trapDoor3;
    public ButtonScript button4;
    public TrapDoorScript trapDoor4;
    public LightningBoltScript p115;
    public LightningBoltScript p152;
    public LightningBoltScript p23;
    public LightningBoltScript p333;
    public LightningBoltScript p3336;
    public LightningBoltScript p364;
    public LightningBoltScript p45;
    public LightningBoltScript p555;
    public LightningBoltScript p556;
    public LightningBoltScript p665;
    public LightningBoltScript p657;
    public LightningBoltScript p78;


    // Start is called before the first frame update
    void Start() {
        box1pos = box1.transform.position;
        box2pos = box2.transform.position;
        box3pos = box3.transform.position;
        box4pos = box4.transform.position;
        box5pos = box5.transform.position;
        box6pos = box6.transform.position;

        resetPowerline();
    }

    // Update is called once per frame
    void Update() {
        if (currentCheckpoint >= 1) {
            p115.enabled = true;
            p152.enabled = true;
        } 
        if (currentCheckpoint > 2) {
            p23.enabled = true;
        } 
        if (currentCheckpoint > 4) {
            p333.enabled = true;
            p3336.enabled = true;
            p364.enabled = true;
        } 
        if (currentCheckpoint > 5) {
            p45.enabled = true;
        }
        if (currentCheckpoint > 6) {
            p555.enabled = true;
            p556.enabled = true;
        }
        if (currentCheckpoint > 7) {
            p665.enabled = true;
            p657.enabled = true;
            p78.enabled = true;
        }
    }

    public void reloadLevels() {
        // Set all boxes, buttons and trap doors back to their original state
        robotScript.SetRobotEnabled(true);
        playerControllerScript.robotEnabled = true;
        batteryScript.SetRobotEnabled(true);
        cameraScript.SetRobotEnabled(true);
        playerControllerScript.resetCharge();
        box1.transform.position = box1pos;
        box2.transform.position = box2pos;
        box3.transform.position = box3pos;
        box4.transform.position = box4pos;
        box5.transform.position = box5pos;
        box6.transform.position = box6pos;
        button1.SetButtonStatus(false);
        trapDoor1.SetTrapDoorStatus(false);
        button2.SetButtonStatus(false);
        trapDoor2.SetTrapDoorStatus(false);
        button3.SetButtonStatus(false);
        trapDoor3.SetTrapDoorStatus(false);
        button4.SetButtonStatus(false);
        trapDoor4.SetTrapDoorStatus(false);
        resetPowerline();
    }

    public void returnToCheckpoint() {
        switch (currentCheckpoint) {
            case 1:
                robotObject.transform.position = new Vector3(-48.2f, 0.5f, 0f);
                break;
            case 2:
                robotObject.transform.position = checkpoint2.transform.position;
                break;
            case 3:
                robotObject.transform.position = checkpoint3.transform.position;
                break;
            case 4:
                robotObject.transform.position = checkpoint4.transform.position;
                break;
            case 5:
                robotObject.transform.position = new Vector3(126f, -1.20f, 0f);
                // robotObject.transform.position = checkpoint5.transform.position;
                break;
            case 6:
                robotObject.transform.position = new Vector3(155f, -3.3f, 0f);
                // robotObject.transform.position = checkpoint6.transform.position;
                break;
            case 7:
                robotObject.transform.position = new Vector3(202f, -3.3f, 0f);
                // robotObject.transform.position = checkpoint7.transform.position;
                break;
            case 8:
                robotObject.transform.position = new Vector3(255f, -1.5f, 0f);
                // robotObject.transform.position = checkpoint8.transform.position;
                break;
        }

    }

    public void setCheckpoint(int checkpoint) {
        if (checkpoint > currentCheckpoint) {
            currentCheckpoint = checkpoint;
        }
    }

    public void Restart() {
        currentCheckpoint = 1;
    }

    public void resetPowerline() {
        p115.enabled = false;
        p152.enabled = false;
        p23.enabled = false;
        p333.enabled = false;
        p3336.enabled = false;
        p364.enabled = false;
        p45.enabled = false;
        p555.enabled = false;
        p555.enabled = false;
        p556.enabled = false;
        p665.enabled = false;
        p657.enabled = false;
        p78.enabled = false;
    }
}
