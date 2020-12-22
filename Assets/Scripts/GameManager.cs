using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
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
    [SerializeField] private Button godMode;
    [SerializeField] private GameObject shoot;
    [SerializeField] private Text BestScore;
    [SerializeField] private Text Score;
    [SerializeField] private Text Coins;
    [SerializeField] private GameObject player_;
    [SerializeField] private GameObject terrainGeneration;
    [SerializeField] private List<Pool> poolMoveObjects;
    [SerializeField] private List<GameObject> prefabWater;
    void Start ()
    {
        poolMoveObjects[0] = GameObject.Find("PoolCars1").GetComponent<Pool>();
        poolMoveObjects[1] = GameObject.Find("PoolCars2").GetComponent<Pool>();
        poolMoveObjects[2] = GameObject.Find("PoolLogs1").GetComponent<Pool>();
        poolMoveObjects[3] = GameObject.Find("PoolLogs2").GetComponent<Pool>();
        soundOn.GetComponent<Button>().onClick.AddListener(SoundOn);
        soundOff.GetComponent<Button>().onClick.AddListener(SoundOff);
        play.GetComponent<Button>().onClick.AddListener(StartGame);
        restart.GetComponent<Button>().onClick.AddListener(RestartGame);
        godMode.GetComponent<Button>().onClick.AddListener(GodMode);
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
        SetComponents(true);
        if (PlayerPrefs.GetInt("level") > 2)
            shoot.SetActive(true);
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
        int finalScore = MovePlayer._score;
        int coins_ = PlayerPrefs.GetInt("sum_Coins") + MovePlayer._coins;
        Score.text = "Score: " + MovePlayer._score;
        Coins.text = "Coins: " + coins_;
        PlayerPrefs.SetInt("sum_Coins", coins_);
        player_.SetActive(false);
        terrainGeneration.SetActive(false);
        gameCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        textCanvas.SetActive(true);
        startCanvas.SetActive(false);
        
        if (PlayerPrefs.GetInt("key_Score") < MovePlayer._score)
        {
            BestScore.text = "Best: " + MovePlayer._score;
            PlayerPrefs.SetInt("key_Score", finalScore);
        }

        int level = PlayerPrefs.GetInt("level");
        level++;
        PlayerPrefs.SetInt("level", level);
    }

    public void GodMode()
    {
        
        if (player_.GetComponent<MovePlayer>().godMode == false)
        {
            SetComponents(false);
            player_.GetComponent<MovePlayer>().godMode = true;
        }
        else
        {
            SetComponents(true);
            player_.GetComponent<MovePlayer>().godMode = false;
        }
    }

    private void SetComponents(bool temp)
    {
        for (int i = 0; i < prefabWater.Count; i++)
        {
            prefabWater[i].GetComponent<BoxCollider>().isTrigger = temp;
        }

        GameObject[] triggerObj = GameObject.FindGameObjectsWithTag("Trigger");
        foreach (var go in triggerObj)
        {
            go.GetComponent<BoxCollider>().isTrigger = temp;
        }
        for (int j = 0; j < poolMoveObjects.Count; j++)
        {
            for (int i = 0; i < Pool.count; i++)
            {
                poolMoveObjects[j].Get(i).GetComponent<BoxCollider>().enabled = temp;
            }
        }
    }
}

/*
GameObject.FindWithTag("Trigger").GetComponent<BoxCollider>().isTrigger = temp;
*/