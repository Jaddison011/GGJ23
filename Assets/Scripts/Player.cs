using UnityEngine;
using System.Collections;
 
 public class Player : MonoBehaviour {
     //Variables
     public float speed = 6.0F;
     public float jumpSpeed = 8.0F; 
     private Vector3 moveDirection = Vector3.zero;
     
     public Rigidbody2D rb;
     public float buttonTime = 0.5f;
     public float jumpHeight = 5;
     bool isGrounded = true;

    //  public Animator animator;
     private SpriteRenderer spriteRenderer;


    //  public AudioSource walk1;
    //  public AudioSource walk2;

     void FixedUpdate() {
        //Feed moveDirection with input.
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        moveDirection = transform.TransformDirection(moveDirection);
        //Multiply it by speed.
        moveDirection *= speed;

        //Making the character move
        transform.position += moveDirection * Time.deltaTime;
     }

     private void Update() {
        // animator.SetBool("Jumping", !isGrounded);

        if(moveDirection.x != 0) {
            // animator.SetBool("Moving", true);
            // if (!walk2.isPlaying && !walk1.isPlaying) {
            //     walk1.Play();
            //     walk2.PlayDelayed(0.5f);
            // }
        } else {
            // animator.SetBool("Moving", false);
        }

        // if(Input.GetAxis("Horizontal") > 0) {
        //     spriteRenderer.flipX = false;
        // } 
        // if(Input.GetAxis("Horizontal") < 0) {
        //     spriteRenderer.flipX = true;
        // } 


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            
            float jumpForce = Mathf.Sqrt(jumpHeight * jumpSpeed * (rb.gravityScale));

            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            FindObjectOfType<GameManager>().Pause();
        }
     }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.GetType() == typeof(BoxCollider2D)) {
            // do stuff only for the box collider
            if(collision.gameObject.CompareTag("Floor")) {
                isGrounded = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.GetType() == typeof(BoxCollider2D)) {
            // do stuff only for the box collider
            if(collision.gameObject.CompareTag("Floor")) {
                isGrounded = false;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D collision) {
        isGrounded = true;
    }

    void OnTriggerExit2D(Collider2D collision) {
        isGrounded = false;
    }

    private void Start() {
        // spriteRenderer = GetComponent<SpriteRenderer>();
        // animator.SetBool("Jumping", false);
        // animator.SetBool("Moving", false);
    }
 }