using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 10;
    public float moveSpeed;
    public float jumpSpeed;
    public Animator anim;
    public CharacterController player;
    private Vector3 movement;
    public bool jumping=false;
    public GameObject alien;
    public bool isdead=false;

    public Text score1;
    public Text Time1;

    public int score = 0;
    public int time = 0;


    public bool check = false;
    public bool check1 = false;


    public float restartDelay = 5f;
    // Use this for initialization
    void Start () {
        alien = GameObject.FindGameObjectWithTag("alien");
        anim = GetComponent<Animator>();
        player = GetComponent<CharacterController>();
        score1.GetComponent<Text>();
        Time1.GetComponent<Text>();

        
        
    }


    public void UIScore()
    {

        score += 10;
        score1.text = "Score:" + score.ToString();
    }
    void UITime()
    {
        if (check1 == false)
        {
            StartCoroutine(Time_delay());
            Time1.text = "Time:" + time;
        }
        // Update is called once per frame
    }
    IEnumerator Time_delay()
    {
        check1 = true;
        time = time + 1;
        yield return new WaitForSeconds(1f);
        check1 = false;
    }

    // Update is called once per frame
    void Update () {
       

        movement = Vector3.zero;
        movement.x = 1 * moveSpeed * Time.deltaTime;
        movement.z= -Input.GetAxis("Horizontal") * Time.deltaTime*moveSpeed;


        if(player.isGrounded)
        {
            movement.y = 0;
        }
        else
        {
            /*if(jumping==true)
            {*/
                movement.y -= 9.8f * Time.deltaTime;
            //}
         }



        if(Input.GetKeyDown(KeyCode.Space))
        {
            

            anim.SetTrigger("jump");
            changeCentre();
        }

        /*if (Input.GetKeyDown(KeyCode.DownArrow) && !isSliding) // press F to slide
        {
            
            isSliding = true;

        }
        if (isSliding)
        {
            anim.SetBool("slide", true);
            

        }*/

      /*  if(Input.GetKeyDown(KeyCode.S)&& !isSliding)
        {
            anim.SetBool("slide", true);
            isSliding = true;
            anim.SetBool("slide", false);
        }   */
     



        player.Move(movement);



        /*float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(0,0,vertical*Time.deltaTime*playerspeed);
        transform.Rotate(0,horizontal,0);*/
        //anim.SetFloat("speed",vertical);

        UITime();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Picks"))
        {
            other.gameObject.SetActive(false);
            UIScore();
        }
    }
    void changeCentre()
    {
        jumping = true;
        player.center = new Vector3(player.center.x, 1.35f, player.center.z);
    }
    public void DefaultChan()
    {
        jumping = false;
        
        player.center = new Vector3(player.center.x, 0.79f, player.center.z);
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "barrier" && !isdead)
        {
            
            isdead = true;
            moveSpeed = 0;
            anim.SetTrigger("death");
        }
    }
}