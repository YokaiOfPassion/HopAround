using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVLManager : MonoBehaviour
{
    public static LVLManager instance;
    public int currentToad;
    public int currentCoins;
    private int tempCoins;
    public GameObject winCanvas;


    public void Start()
    {
        instance = this;
        SoundManager.instance.PlayLevelMusic();
    }

    public void AddToad()
    {
        currentToad++;
    }

    public void AddCoin()
    {
        currentCoins++;
        UiInGameManager.instance.UpdateCoinsTxt();
    }

    public void Win()
    {
        Debug.Log("currentcoin : "+ currentCoins + "Saved coins" + PlayerPrefs.GetInt("Coins"));
        tempCoins = PlayerPrefs.GetInt("Coins") + currentCoins;
        PlayerPrefs.SetInt("Coins", tempCoins);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name+"Clear",1);
        Debug.Log("CoinsAftersave" + PlayerPrefs.GetInt("Coins"));
        if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name+"Toad") < currentToad)
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name+"Toad",currentToad);
        }
        winCanvas.SetActive(true);
    }
}
