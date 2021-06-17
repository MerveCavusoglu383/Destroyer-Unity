using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthSpawn : MonoBehaviour
{
   

    
    void Update()
    {
         transform.Rotate(new Vector3(0f,0f,100f)*Time.deltaTime);
    }
     void OnTriggerEnter(Collider other ){

      if(other.gameObject.tag=="Player")
      {
          Destroy(gameObject,0.05f);
      }
   }
}
