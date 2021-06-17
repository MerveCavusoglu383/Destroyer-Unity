using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{

    public void Lv1Finish()
    {
        LevelManager.Lv2 = true;
    }
    public void Lv2Finish()
    {
        LevelManager.Lv3 = true;
    }
}
