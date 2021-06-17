using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       // Destroy(gameObject,0.5f); // mermiyi 1 saniye sonra oyundan yok et.
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    
}
