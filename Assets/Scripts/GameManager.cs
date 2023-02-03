using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ResumeButton;
    public GameObject RestartButton;
    public GameObject ExitButton;
    public GameObject pauseCanvas;
    public GameObject chargeBar;
    public GameObject titleScreen;

    public CheckpointManager checkpointManager;

    public Player player;
    public Battery battery;

    public AudioSource music;

    private bool batteryOrNot;
    private bool returnedToMenu = false;
    
    private void Awake() {
        Application.targetFrameRate = 60;
        music.Play();
        titleScreenMethod();
    }

    public void Pause() {
        Time.timeScale = 0f;
        player.enabled = false;
        battery.enabled = false;

        pauseCanvas.SetActive(true);
        //ResumeButton.SetActive(true);
        //RestartButton.SetActive(true);
        //ExitButton.SetActive(true);
        music.Pause();
    }

    public void GameOver() {
        checkpointManager.Restart();
        checkpointManager.reloadLevels();
        checkpointManager.returnToCheckpoint();
        music.Play();
    }

    public void ReturnToMenu() {
        returnedToMenu = true;
        titleScreenMethod();
    }

    public void titleScreenMethod() {
        Time.timeScale = 0f;
        player.enabled = false;
        battery.enabled = false;
        titleScreen.SetActive(true);
        chargeBar.SetActive(false);
    }

    public void Play() {
        battery.enabled = true;            
        player.enabled = true;
        Time.timeScale = 1f;
        chargeBar.SetActive(true);
        titleScreen.SetActive(false);
        
        //ResumeButton.SetActive(false);
       // RestartButton.SetActive(false);
       // ExitButton.SetActive(false);
        pauseCanvas.SetActive(false);

        Debug.Log(returnedToMenu);
        if (returnedToMenu) {
            checkpointManager.returnToCheckpoint();
            checkpointManager.reloadLevels();
        }
        music.Play();
    }

    public void Exit() {
        Application.Quit();
    }
    
}
