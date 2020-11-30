using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject startCanvas;
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject textCanvas;
    [SerializeField] private Camera cameraMove;
    [SerializeField] private Button play;
    [SerializeField] private Button restart;
    [SerializeField] private Button soundOn;
    [SerializeField] private Button soundOff;
    [SerializeField] private Text BestScore;
    [SerializeField] private Text Score;
    [SerializeField] private Text Coins;
    [SerializeField] private GameObject player_;
    [SerializeField] private GameObject terrainGeneration;
    void Start ()
    {
        soundOn.GetComponent<Button>().onClick.AddListener(SoundOn);
        soundOff.GetComponent<Button>().onClick.AddListener(SoundOff);
        play.GetComponent<Button>().onClick.AddListener(StartGame);
        restart.GetComponent<Button>().onClick.AddListener(RestartGame);
    }

    private void SoundOn()
    {
        soundOff.interactable = true;
        soundOn.interactable = false;
        AudioListener.pause = false;
        PlayerPrefs.SetInt("sound", 1);
    }
    private void SoundOff()
    {
        soundOn.interactable = true;
        soundOff.interactable = false;
        AudioListener.pause = true;
        PlayerPrefs.SetInt("sound", 0);
    }
    
    private void StartGame()
    {
        cameraMove.GetComponent<MoveCamera>().enabled = true;
        player_.SetActive(true);
        terrainGeneration.SetActive(true);
        gameCanvas.SetActive(true);
        startCanvas.SetActive(false);
        textCanvas.SetActive(false);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name,LoadSceneMode.Single);
    }
    private void Awake()
    {
        BestScore.text = "Best: " + PlayerPrefs.GetInt("key_Score");
        Coins.text = "Coins: " + PlayerPrefs.GetInt("sum_Coins");
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            SoundOn();
        }
        else
        {
            SoundOff();
        }
    }
    
    public void GameOver()
    {
        int finalScore = Player._score;
        int coins_ = PlayerPrefs.GetInt("sum_Coins") + Player._coins;
        Score.text = "Score: " + Player._score;
        Coins.text = "Coins: " + coins_;
        PlayerPrefs.SetInt("sum_Coins", coins_);
        player_.SetActive(false);
        terrainGeneration.SetActive(false);
        gameCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        textCanvas.SetActive(true);
        startCanvas.SetActive(false);
        
        if (PlayerPrefs.GetInt("key_Score") < Player._score)
        {
            BestScore.text = "Best: " + Player._score;
            PlayerPrefs.SetInt("key_Score", finalScore);
        }
    }
}
