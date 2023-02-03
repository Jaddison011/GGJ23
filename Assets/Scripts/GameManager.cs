using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Player player;
    
    private void Awake() {
        Application.targetFrameRate = 60;
    }


    public void Pause() {
        // Time.timeScale = 0f;
    }

    public void Exit() {
        Application.Quit();
    }
    
}
