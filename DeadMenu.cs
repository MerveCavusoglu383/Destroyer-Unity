using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public static bool charIsDead = false;
    public GameObject deadMenuUI;

   void Start(){

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

   }

    void Update()
    {
        if (charIsDead)
        {   
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            deadMenuUI.SetActive(true);
            Time.timeScale = 0f;
            
                  
        }
    }
    public void RestartMap()
    {   
        charIsDead=false;
        deadMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(PlayerController.sceneNumber);
        
        
    }

    public void LoadMenu()
    {   
        charIsDead=false;
        deadMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    
}
