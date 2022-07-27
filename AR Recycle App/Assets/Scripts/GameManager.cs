using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject instructionsPanel;
    public GameObject gameOverPanel;
    public float timer;
    public Camera bladeCamera;
    public TMP_Text gameOverText;

    public void StartGame()
    {
        SceneManager.LoadScene("RecycleNinja");
        AudioManager.instance.PlayMusic();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void StartObjectRecognition()
    {
        SceneManager.LoadScene("Object Recognition");
    }
    public void OpenInstructions()
    {
        instructionsPanel.SetActive(true);
    }
    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);
    }

    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "RecycleNinja" && Timer.instance.timeValue == 0)
        {
            gameOverText.text = "WELL DONE! \n\n You have got " + Score.instance.totalScore.ToString() + " points!";
            bladeCamera.enabled = false;
            gameOverPanel.SetActive(true);
            AudioManager.instance.StopMusic();
        }
    }
}
