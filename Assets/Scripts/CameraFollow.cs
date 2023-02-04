using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 3f, -5);
    }
}