using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(player.transform.position.x, 2.4f, -5);
    }
}