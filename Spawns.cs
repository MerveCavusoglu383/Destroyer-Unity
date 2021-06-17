using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
    public GameObject bulletSpawn;
    public GameObject healthSpawn;
    public GameObject energySpawn;

    public float randX1 ;
     public float randX2 ;
    public  float randZ1;
     public float randZ2 ; 
     public float randX3 ; 
     public float randZ3 ; 
     int bullet_counter=2;
     int heart_counter=2;

     int energy_counter=2;

     float limit=1;
    void Start()
    { 
        
            InvokeRepeating("spawn_bullet",1.0f,limit);
            InvokeRepeating("spawn_heart",1.0f,limit);
            InvokeRepeating("spawn_energy",1.0f,limit);
       
    } 
   
    void spawn_bullet(){

        if(bullet_counter == 0){
           CancelInvoke("spawn_bullet"); 
        }  
    
         randX1=Random.Range(-45,+45);
         randZ1=Random.Range(-45,+45);
         Instantiate(bulletSpawn,new Vector3(randX1,1f,randZ1), Quaternion.Euler(new Vector3(-60f,0f,0f)) );
         bullet_counter--;
         

    }
    void spawn_heart(){

        if(heart_counter == 0){
           CancelInvoke("spawn_heart"); 
        }  
    
        randX2=Random.Range(-45,+45);
        randZ2=Random.Range(-45,+45);
        Instantiate(healthSpawn,new Vector3(randX2,1.5f,randZ2), Quaternion.Euler(new Vector3(-90f,0f,0f)) );
        heart_counter--;
    }

    void spawn_energy(){

        if(energy_counter == 0){
           CancelInvoke("spawn_energy"); 
        }  
    
        randX3=Random.Range(-45,+45);
        randZ3=Random.Range(-45,+45);
        Instantiate(energySpawn,new Vector3(randX3,1.7f,randZ3), Quaternion.Euler(new Vector3(-90f,0f,0f)) );
        energy_counter--;
    }

        
    
   
}
