using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoorScript : MonoBehaviour {

    private bool trapDoorOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTrapDoorStatus(bool trapDoorStatus) {
        if (!trapDoorOpen && trapDoorStatus) {
            // Close to open aka open trap door
            trapDoorOpen = trapDoorStatus;
            transform.position = new Vector3(transform.position.x, transform.position.y + 1000, transform.position.z);
        }
        if (trapDoorOpen && !trapDoorStatus) {
            // Open to close aka close trap door
            trapDoorOpen = trapDoorStatus;
            transform.position = new Vector3(transform.position.x, transform.position.y - 1000, transform.position.z);
        }
    }

}
