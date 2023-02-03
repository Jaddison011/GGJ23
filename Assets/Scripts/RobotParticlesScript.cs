using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotParticlesScript : MonoBehaviour {
    private ParticleSystem settings;
    private ParticleSystem.MainModule main;

    // Start is called before the first frame update
    void Start() {
        settings = GetComponent<ParticleSystem>();
        main = settings.main;
    }

    // Update is called once per frame
    void Update() {

        
    }

    public void updateParticleColour(bool robotEnabled) {
        if (robotEnabled) {
            main.startColor = new Color(0.5490196f, 0.9529412f, 1f, 1f); //140, 243, 255, 255
        }
        if (!robotEnabled) {
            main.startColor = new Color(0.86f, 0.244f, 0.202f, 0.8235294f);
        }
    }
}
