using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour {

    public GameObject player;
    public GameObject pivot;
    bool onRoot = false;

    // Start is called before the first frame update
    void Start() {
        GetComponent<HingeJoint2D>().enabled = false;
        pivot.GetComponent<DistanceJoint2D>().enabled = false;
    }

    // Update is called once per frame
    void Update() {
        if (onRoot) {
            GetComponent<LineRenderer>().positionCount = 2;
            List<Vector3> pos = new List<Vector3>();
            pos.Add(player.GetComponent<Transform>().position);
            pos.Add(pivot.GetComponent<Transform>().position);
            GetComponent<LineRenderer>().SetPositions(pos.ToArray());
        } else {
            GetComponent<LineRenderer>().positionCount = 0;
        }
    }

    public void enable(Vector3 playerPosition, Vector3 pivotPosition) {
        onRoot = true;
        // GetComponent<HingeJoint2D>().enabled = true;
        pivot.GetComponent<DistanceJoint2D>().enabled = true;
        pivot.GetComponent<DistanceJoint2D>().distance = Vector3.Distance(playerPosition, pivotPosition);
    }

    public void disable() {
        onRoot = false;
        GetComponent<HingeJoint2D>().enabled = false;
        pivot.GetComponent<DistanceJoint2D>().enabled = false;
    }

    public void SetPivot(GameObject newPivot) {
        pivot = newPivot;
    }
}
