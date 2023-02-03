using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    private float length;
    private float startPos;
    public GameObject camera;
    public float parallaxScale;

    // Start is called before the first frame update
    void Start() {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startPos = transform.position.x;
    }

    void FixedUpdate() {
        float distance = (camera.transform.position.x * parallaxScale);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
        
    }
}
