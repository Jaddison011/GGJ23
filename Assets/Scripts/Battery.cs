using UnityEngine;
using System.Collections;
using System;
 
 public class Battery : MonoBehaviour {
     //Variables
     public float speed = 6.0F;
     public float jumpSpeed = 8.0F; 
     private Vector3 moveDirection = Vector3.zero;
     
     public Rigidbody2D rb;
     public float buttonTime = 0.5f;
     public float jumpHeight = 5;
     bool isGrounded = true;
     private bool robotEnabled = false;

     //public GameObject playerController;
     public PlayerControllerScript playerControllerScript;

     public CheckpointManager checkpointManager;

     public AudioSource batteryRollingAudio;

     void FixedUpdate() {
        if (!robotEnabled) {
            //Feed moveDirection with input.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            //moveDirection = transform.TransformDirection(moveDirection);
            if(Math.Abs(rb.angularVelocity) < 350) {
                rb.AddTorque(-5 * Input.GetAxis("Horizontal"));
            }
            moveDirection *= speed;
            
            //Making the character move
            transform.position += moveDirection * Time.deltaTime;
        }
     }

     private void Update() {
        if (!robotEnabled) {
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
                float jumpForce = Mathf.Sqrt(jumpHeight * jumpSpeed * (rb.gravityScale));
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
            if (Input.GetKeyDown(KeyCode.Escape)) {
                FindObjectOfType<GameManager>().Pause();
            }

            if(moveDirection.x != 0) {
                if (!batteryRollingAudio.isPlaying) {
                    batteryRollingAudio.Play();
                }
            } else {
                if (batteryRollingAudio.isPlaying) {
                    batteryRollingAudio.Pause();
                }
            }
        }
        if (robotEnabled) {
            if (batteryRollingAudio.isPlaying) {
                    batteryRollingAudio.Pause();
                }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Floor")) {
            isGrounded = true;
        }
        if(collision.gameObject.CompareTag("Lava")) {
            checkpointManager.returnToCheckpoint();
            checkpointManager.reloadLevels();
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Floor")) {
            isGrounded = false;
        }
    }

    private void Start() {
        if (robotEnabled) {
            transform.position = new Vector3(1000f, 1000f, 0);
        }
    }

    public void SetRobotEnabled(bool enabled) {
        robotEnabled = enabled;

        if (robotEnabled) {
            //Make battery dissapear
            transform.position = new Vector3(1000f, 1000f, 0);
        }
        if (!robotEnabled) {
            //Make battery appear
            transform.position = playerControllerScript.robot.transform.position;
        }
    }
 }