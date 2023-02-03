using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {
    public Player player;
    public CameraFollow camera;
    private float health;
    public float maxHealth;

    // Start is called before the first frame update
    void Start() {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update() {
       
    }

    public void resetHealth() {
        health = maxHealth;
    }
}
