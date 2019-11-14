using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoombieScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PlayerObject;
    public GameObject KillerObject;
    public GameObject VictimObject;
    GameObject player;
    Animator anim;
    Animator victim;
    Animator killer;
    Animator pop;
    Vector3 movedir = Vector3.zero;
    int speed = 1;
    CharacterController controller;
    float gravity = 8;
    float timeLeft = 2.0f;


    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        player = GameObject.FindWithTag("Player");
        pop = PlayerObject.GetComponent<Animator>();
        killer = KillerObject.GetComponent<Animator>();
        victim = VictimObject.GetComponent<Animator>();

    }

    void Update() 
    {
        int test = killer.GetInteger("condition");
        int test1 = victim.GetInteger("condition");
       // Debug.Log(player.transform.position.x);
        if (test == 1 && player.transform.position.x > -23 && player.transform.position.x < -20)    //test : withSword
        {
            PlayerKill();
        }
        else 
            if((test1 == 1) && player.transform.position.x > -23 && player.transform.position.x < -20) //needs to be checked
            {
                zoombieKill();
            }

    }


    public void zoombieKill()
    {

        if (this.gameObject.transform.position.x < -24) { 
            controller.Move(movedir * Time.deltaTime);
            movedir.y -= gravity * Time.deltaTime;
            movedir = new Vector3(0, 0, 1);
            movedir *= speed;
            movedir = transform.TransformDirection(movedir);

        }
        else
        {
            anim.SetInteger("condition", 0);
            //Debug.Log(pop.GetInteger("condition"));
            //pop.SetInteger("condition", 5);
            //Debug.Log(pop.GetInteger("condition"));

        }



    }

    public void PlayerKill()
    {

        if (this.gameObject.transform.position.x < -24)
        {
            controller.Move(movedir * Time.deltaTime);
            movedir.y -= gravity * Time.deltaTime;
            movedir = new Vector3(0, 0, 1);
            movedir *= speed;
            movedir = transform.TransformDirection(movedir);

        }
        else
        {
            timeLeft -= Time.deltaTime;
            anim.SetInteger("condition", 3);

            if (timeLeft < 0)
            {
                //pop.SetInteger("condition", 2);
                anim.SetInteger("condition", 2);
            }

        }

    }




}
