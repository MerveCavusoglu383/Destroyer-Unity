using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSceneName : MonoBehaviour
{
    public static int sceneSet = 2;
    
    // Start is called before the first frame update
    public void setSceneName(int S){
        PlayerController.sceneNumber = S;

    }
}
