using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

    public bool hoveredOver = false;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnMouseEnter() {
        hoveredOver = true;
        player.SetHovering(true);
    }

    void OnMouseExit() {
        hoveredOver = false;
        player.SetHovering(false);
    }
}
