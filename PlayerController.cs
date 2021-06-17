using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
  
   public CharacterController controller;
   public float speed=6;
   private float gravity = 20f;
   private float verticalSpeed =0;
   
   public Transform cameraHolder;
   public float mouseSens = 2f;
   public float upLİmit = -50;
   public float downLİmit = 50;
   public Animator anim;
   public GameObject bullet;
   public GameObject firepoint;
   //public float fireRate= 1f;
    //private float fireCountDown = 0f;
   public float playerHealth = 100f;
   public float energy = 100f;
   public Text hp;
   public Text b_stats;
   public Text enemy_stats;
   public Image energyBar;


   public float totalBullet=100f;
   AudioSource audio0;
   public AudioClip ates;
    public AudioClip take_spanws;
   public AudioClip steps;
   public ParticleSystem muzzleflash;

   public DeadMenu dead;

   public static int sceneNumber;
   float startTime;
   float timePressed;

   public Camera tpsCam;
   

   



   void Start()
    {
        anim = GetComponent<Animator>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        audio0=GetComponent<AudioSource> ();
    }



    void Update()
    {
        Move();
        Rotate();
        Faster();
        Aim();
        Fire();

        HP();
        b_stats.text="Mermi " + totalBullet.ToString();
        enemy_stats.text="Düşman "+  Level.enemyCount.ToString();

        if(energy < 100) energy+= 1 * Time.deltaTime;
        energyBar.fillAmount = energy/100;

        

    }
    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        

        /*if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) )
        {
            startTime = Time.time;
        }
         if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) )
        {
             timePressed = Time.time - startTime;
        }
         if(timePressed > 0.1 )
        {
            audio0.PlayOneShot(steps);
            timePressed=0;
        }*/
        


        if(controller.isGrounded)
         {
             verticalSpeed = 0;
             anim.SetBool("isJump",false);

            if (Input.GetKeyDown(KeyCode.Space) && energy >= 6f)
            {
                verticalSpeed=7;
                anim.SetBool("isJump",true);

                energy-=5f;
                energyBar.fillAmount = energy/100;
            
            }
        }
        
        else verticalSpeed-= gravity * Time.deltaTime;

       
       
        Vector3 gravityMove = new Vector3(0,verticalSpeed,0);
        Vector3 move = transform.forward*verticalMove+ transform.right * horizontalMove;
    
        controller.Move(speed * Time.deltaTime * move + gravityMove * Time.deltaTime);
         

        anim.SetBool("isWalking",verticalMove !=0 || horizontalMove !=0);
        
    
    }
    private void Rotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        transform.Rotate(0,horizontalRotation *mouseSens,0);
        cameraHolder.Rotate(-verticalRotation * mouseSens,0,0);

        Vector3 currentRotation = cameraHolder.localEulerAngles;
        if(currentRotation.x>180) currentRotation.x-=360;
        currentRotation.x = Mathf.Clamp(currentRotation.x , upLİmit,downLİmit);
        cameraHolder.localRotation = Quaternion.Euler(currentRotation);
    }
    private void Faster()
    {
        
        if(Input.GetKeyDown(KeyCode.LeftShift) && energy >= 3f){
            
            speed=11;
            anim.SetBool("isRunning", true);
            energy-= 3 * Time.deltaTime;
            energyBar.fillAmount = energy/100;

        }
         if(Input.GetKeyUp(KeyCode.LeftShift)){
            
            speed=6;
            anim.SetBool("isRunning", false);

        }
        
        
    }

    private void Aim()
    {
        if (Input.GetMouseButton(1) && anim.GetBool("isWalking")!=true) // sag tıka basılı tutunca aim acsin ama yürürken aim alamasin
        {
             anim.SetBool("isAiming", true);
        }
        if (Input.GetMouseButtonUp(1)) // sag tiki birakinca aim kapasin
        {
             anim.SetBool("isAiming", false);
        }
    }

    private void Fire()
    {
        if (Input.GetMouseButtonUp(0) && anim.GetBool("isAiming")==true && totalBullet>0 && energy >= 2f )
        {
            anim.SetBool("isFire", true );

            energy-=2f;
            energyBar.fillAmount = energy/100;

            audio0.PlayOneShot(ates);
            muzzleflash.Play();
             totalBullet-=1;
            //attack();
            shoot();

        }
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("isFire",false);
        }
    }

  /*  private void attack()
    {
        if (totalBullet>0)
        {
            GameObject p_bulllet = Instantiate(bullet,firepoint.transform.position,firepoint.transform.rotation);
            p_bulllet.GetComponent<Rigidbody>().AddForce(transform.forward * Time.deltaTime * 80000f ,ForceMode.Impulse);
            totalBullet-=1;
        }
        
    }*/
    private void shoot()
    {
        RaycastHit hit;
       if( Physics.Raycast(tpsCam.transform.position, tpsCam.transform.forward, out hit,35f))
       {
           EnemyAI enemy = hit.transform.GetComponent<EnemyAI>();
           if (enemy!=null)
           {
               enemy.takeDamage(10f);
           }
       }
    }

    public void TakeDamage()
    {
        playerHealth-=10;
        if(playerHealth<=0)
            {
                //dead.charIsDead=true;
                DeadMenu.charIsDead=true;
                
                Destroy(gameObject);

            }

    }


     private void OnTriggerEnter(Collider other)
    {
     
        if (other.CompareTag("BulletSpawn"))
        {
           totalBullet+=10;
           audio0.PlayOneShot(take_spanws);
        }
         if (other.CompareTag("HeartSpawn"))
        {
           playerHealth+=5;
           audio0.PlayOneShot(take_spanws);
        }
        if (other.CompareTag("EnergySpawn"))
        {     
            audio0.PlayOneShot(take_spanws);
            energy+=50f;
            if(energy>100)energy=100f;
            energyBar.fillAmount = energy/100;
        }
        

    }
    public void HP(){

        hp.text=playerHealth.ToString()+" HP";
        if (playerHealth>70)
        {
             hp.color=Color.green;
        }
        if (playerHealth<=70 && playerHealth>40)
        {
             hp.color=Color.yellow;
        }
        if (playerHealth<=40)
        {
             hp.color=Color.red;
        }


    }

    
   

}
