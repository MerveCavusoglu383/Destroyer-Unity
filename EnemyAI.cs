using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update

    NavMeshAgent agent;
    Animator anim;
    public GameObject destination;
    public float followRange = 30f;
    public float attackRange = 20f;

    public GameObject bullet;
    public GameObject firepoint;

    public float fireRate= 1f;
    private float fireCountDown = 0f;

    public float enemyHealt = 100f;

    public Image healthBar;
    AudioSource audio00;
    public AudioClip atesEnemy;
    public GameObject enemyCam;
    public static bool IsDead = false;

    
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        audio00=GetComponent<AudioSource> ();
        
        
    }

    // Update is called once per frame
    void Update()
    {   
       destination=GameObject.FindGameObjectWithTag("Player");

       //Debug.DrawRay(firepoint.transform.position, firepoint.transform.forward * 50, Color.red);
       

        

        if (destination!=null) // karakterimiz yaşıyor olduğu sürece düşmanın yapacakları
        {
             float distance = Vector3.Distance(destination.transform.position , transform.position);
            

            if ( distance < followRange && distance > attackRange) // karakter düşmanın görüş alanına girmişse
            {   
           
                agent.SetDestination(destination.transform.position);
            
                 rotationFollow();
                 anim.SetBool("isWalking",true);
                 anim.SetBool("isFire",false);
            
            
            }

            if (distance<followRange  && distance < attackRange) // karakter düşmanın atak alanına girmişse
            {
                rotationFollow();
                agent.SetDestination(transform.position);
                anim.SetBool("isFire",true);
                anim.SetBool("isWalking",false);
            if(fireCountDown<=0f)
            {
                //attack();
                shoot();
                fireCountDown = 1f / fireRate;
            }
            fireCountDown-=Time.deltaTime;



             }

            if ( distance > followRange  && distance > attackRange) // karakter düşmana çok uzaksa
            {
                //rotationFollow();
                anim.SetBool("isWalking",false);
                anim.SetBool("isFire",false);
                agent.SetDestination(transform.position);
            }
            
        }

       
             
        
    }

    /*private void OnDrawGizmosSelected()
     {
          Gizmos.color = Color.yellow;
          Gizmos.DrawSphere(transform.position, followRange);

     }*/

    

    public void rotationFollow() // düşmanın oyuncuya yönelmesi
    {
        Vector3 way = (destination.transform.position-transform.position).normalized;   // oyunucu ile arasındaki vektörün normali
        Quaternion follow = Quaternion.LookRotation(new Vector3(way.x,0f,way.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,follow,Time.deltaTime * 5f);
    }


   /* private void attack()
    {
        GameObject e_bulllet = Instantiate(bullet,firepoint.transform.position,firepoint.transform.rotation);
        e_bulllet.GetComponent<Rigidbody>().AddForce(transform.forward * Time.deltaTime * 20000f ,ForceMode.Impulse);

        audio00.PlayOneShot(atesEnemy);
    }*/
    private void shoot()
    {
        audio00.PlayOneShot(atesEnemy);
        RaycastHit hit;
       if( Physics.Raycast(enemyCam.transform.position, enemyCam.transform.forward, out hit,50f))
       {
           PlayerController player = hit.transform.GetComponent<PlayerController>();
           if (player!=null)
           {
               player.TakeDamage();
           }
       }
    }

    public void takeDamage(float amount)
    {
        enemyHealt-=amount;
        healthBar.fillAmount = enemyHealt/100f;
        if(enemyHealt<=0)
            {   
                Level.enemyCount-=1;
                IsDead = true;
                Destroy(gameObject);
            }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            enemyHealt-=25;
            healthBar.fillAmount = enemyHealt/100f;
            

            if(enemyHealt<=0)
            {   
                Level.enemyCount-=1;
                Destroy(gameObject);
            }

        }
    }*/
    

}
