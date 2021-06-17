using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y1 : MonoBehaviour
{
   public GameObject thePlayer;

   void OnTriggerEnter(Collider other ){

      if(other.gameObject.tag=="Player")
      {
         thePlayer.transform.position = new Vector3( thePlayer.transform.position.x, thePlayer.transform.position.y+3,  thePlayer.transform.position.z-98);
      }
      
      
   }
}
