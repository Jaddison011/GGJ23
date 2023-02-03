using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    private bool buttonPressed = false;
    public TrapDoorScript trapDoorScript;

    public SpriteRenderer spriteRenderer;
    public Sprite unpressedButton;
    public Sprite pressedButton;

    public GameObject obstacle;
    public GameObject safeBlocks;
    public GameObject spikes;

    // Start is called before the first frame update
    void Start() {
        spriteRenderer.sprite = unpressedButton;
        buttonPressed = false;
        if (obstacle != null) {
            obstacle.tag = "Lava";
            if (safeBlocks != null) {
                safeBlocks.SetActive(false);
            }
            if (spikes != null) {
                spikes.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update() {
        if (buttonPressed) {
            spriteRenderer.sprite = pressedButton;
        } else {
            spriteRenderer.sprite = unpressedButton;
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Battery") && !(this.CompareTag("CrateButton"))) {
            buttonPressed = !buttonPressed;
            trapDoorScript.SetTrapDoorStatus(buttonPressed);
        }
        if (this.CompareTag("CrateButton") && collision.gameObject.CompareTag("Crate") || (collision.gameObject.CompareTag("Floor") && this.CompareTag("BothButton"))) {   
            buttonPressed = !buttonPressed;
            trapDoorScript.SetTrapDoorStatus(buttonPressed);
            if (!buttonPressed && obstacle != null) {
                obstacle.tag = "Lava";
                if (safeBlocks != null) {
                safeBlocks.SetActive(false);
                }
                if (spikes != null) {
                spikes.SetActive(true);
                }
            }if (buttonPressed && obstacle != null) {
                obstacle.tag = "Floor";
                if (safeBlocks != null) {
                safeBlocks.SetActive(true);
            }
            if (spikes != null) {
                spikes.SetActive(false);
            }
            }
        }
    }

    public void SetButtonStatus(bool buttonStatus) {
        buttonPressed = buttonStatus;

        if (obstacle != null) {
            if (buttonPressed) {
                obstacle.tag = "Floor";
                if (spikes != null) {
                spikes.SetActive(true);
            }
            if (spikes != null) {
                spikes.SetActive(false);
            }
            }
            if (!buttonPressed) {
                obstacle.tag = "Lava";
                if (spikes != null) {
                spikes.SetActive(true);
            }
            if (safeBlocks != null) {
                spikes.SetActive(false);
            }
            }
        }
        
    }
}