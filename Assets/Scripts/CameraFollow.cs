using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform robot;
    public Transform battery;
    private bool robotEnabled = false;

    // Update is called once per frame
    void Update () {
        if (robotEnabled) {
            // transform.position = robot.transform.position + new Vector3(0, 1, -5);
            transform.position = new Vector3(robot.transform.position.x, -0.55f, -5);
        }
        if (!robotEnabled) {
            // transform.position = battery.transform.position + new Vector3(0, 1, -5);
            transform.position = new Vector3(battery.transform.position.x, -0.55f, -5);
        }
    }

    public void SetRobotEnabled(bool enabled) {
        robotEnabled = enabled;
    }
}