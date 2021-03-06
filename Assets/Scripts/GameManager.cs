﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject[] levelArray;

    private int actualLevel;
    public static bool changeLevel = false;

    public static int enemiesKilled = 0;

    public static int playerLife = 1;

    public static bool playerDiesRestart = false;

    void Awake(){
        if(instance != null){
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        actualLevel = 0;
    }

    void LateUpdate(){
        if(playerLife <= 0){
            playerDiesRestart = true;
        }
        if(playerDiesRestart){
            Restart();
        }

        if(changeLevel){
            levelArray[actualLevel].SetActive(false);
            if(actualLevel < 2){
                actualLevel++;
            }
            else{
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                actualLevel = 0;
                changeLevel = false;
            }
            levelArray[actualLevel].SetActive(true);
            changeLevel = false;
        }
    }

    void Restart(){
       SceneManager.LoadScene(0);

    }
}
