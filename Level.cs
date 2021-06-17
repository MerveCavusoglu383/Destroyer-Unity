using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
   
    public static int enemyCount;// düşman sayısını diğer scriptlerden almak için static değişken
    GameObject[] gameObjects; // düşman sayısını tutan dizi
    public GameObject levelFinishUI;

    void Start(){
        
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = gameObjects.Length;
    }

    void Update()
    {
        if(enemyCount==0)
        {
           // SceneManager.LoadScene(1);
            levelFinishUI.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;

        }
    }

    public void Next_Level()
    {
        
        levelFinishUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }
     public void Lv1Finish()
    {
        LevelManager.Lv2 = true;
        
    }
    public void Lv2Finish()
    {
        LevelManager.Lv3 = true;
    }

    }
