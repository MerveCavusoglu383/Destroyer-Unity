using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public static bool Lv1, Lv2, Lv3;
    public Button Lv1Button, Lv2Button, Lv3Button;
    void Start()
    {
        Lv1 = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Lv2 == true)
        {
            Lv2Button.interactable = true;
        }
        if (Lv3 == true)
        {
            Lv3Button.interactable = true;
        }
        
    }
}
