using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bolumsistemi : MonoBehaviour
{
   
  public void bolum_ac(string bolum_ismi)
  {
      SceneManager.LoadScene(bolum_ismi);
  }
}
