using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public Player robot;
    public Battery battery; 
    public bool robotEnabled = false;
    public CameraFollow camera;
    private float charge;
    public float maxCharge;
    public float chargeDecayRate;
    public float chargingRate;
    private bool charging = false;
    public ChargeBar chargeBarScript;
    public RobotParticlesScript robotParticlesScript;
    public CheckpointManager checkpointManager;
    public AudioSource chargingAudio;
    public AudioSource powerOnAudio;
    public AudioSource powerOffAudio;
    public AudioSource batteryLowAudio;
    public AudioSource robotDeathAudio;

    // Start is called before the first frame update
    void Start() {
        charge = maxCharge;
    }

    // Update is called once per frame
    void Update() {
       
        //Switching between the robot and the battery
        if (Input.GetKeyDown("e")) {
            if (!robotEnabled && robot.GetBatteryNear()) {
                // print("e was pressed");
                robotEnabled = true;
                robot.SetRobotEnabled(true);
                battery.SetRobotEnabled(true);
                camera.SetRobotEnabled(true);

                powerOnAudio.Stop();
                powerOnAudio.Play();

            } else {
                if (robotEnabled) {
                    robotEnabled = false;
                    robot.SetRobotEnabled(false);
                    battery.SetRobotEnabled(false);
                    camera.SetRobotEnabled(false);
                    powerOnAudio.Stop();
                    powerOffAudio.Stop();
                    powerOffAudio.Play();
                }
            }
        }

        //Charging and charge decay code
        if (charge > 0) {
            //Debug.Log(charging + " charging status");
            if (charging) {
                charge = Math.Min(charge + chargingRate * Time.deltaTime, maxCharge);
                chargeBarScript.updateBar(charge, maxCharge);
                robotParticlesScript.updateParticleColour(robotEnabled);
                if(!chargingAudio.isPlaying) {
                    chargingAudio.Play();
                }
                //Debug.Log(charge + " charging");
            } else {
                chargingAudio.Pause();
                charge = Math.Max(0, charge - chargeDecayRate * Time.deltaTime);  // time to decay fully in seconds = max charge / decay rate
                chargeBarScript.updateBar(charge, maxCharge);
                robotParticlesScript.updateParticleColour(robotEnabled);

                if (charge < (maxCharge/4)) {
                    if (!batteryLowAudio.isPlaying) {
                        batteryLowAudio.Play();
                    }
                }
                //Debug.Log(charge + " loosing charge");
            }
        } else {
            if (batteryLowAudio.isPlaying) {
                batteryLowAudio.Pause();
            }
            if (!robotDeathAudio.isPlaying) {
                robotDeathAudio.Play();
            }

            //Game Over
            Debug.Log("Game Over");
            // Return to last checkpoint
            checkpointManager.returnToCheckpoint();
            checkpointManager.reloadLevels();
            // Reset players charge
        }
    }

    public void SetChargingStatus(bool chargingStatus) {
        charging = chargingStatus;
    }

    public void resetCharge() {
        charge = maxCharge;
    }
}
