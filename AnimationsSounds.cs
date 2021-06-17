using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsSounds : MonoBehaviour
{
   AudioSource AS;
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stepsSounds(){
        AS.Play();

    }
}
