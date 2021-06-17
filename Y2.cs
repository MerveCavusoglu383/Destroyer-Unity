using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y2 : MonoBehaviour
{
    // Start is called before the first frame update
     public GameObject thePlayer;

   void OnTriggerEnter(Collider other ){

      if(other.gameObject.tag == "Player")
      {
         thePlayer.transform.position = new Vector3( thePlayer.transform.position.x, thePlayer.transform.position.y+3,  thePlayer.transform.position.z+98);
      }
      
      
   }
}
