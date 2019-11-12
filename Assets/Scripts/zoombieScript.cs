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
    Vector3 movedir = Vector3.zero;
    int speed = 1;
    CharacterController controller;
    float gravity = 8;
    float timeLeft = 10.0f;


    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        player = PlayerObject.GetComponent<GameObject>();
        killer = KillerObject.GetComponent<Animator>();
        victim = VictimObject.GetComponent<Animator>();

    }

    void Update() 
    {
        killZoombie();
        int test = killer.GetInteger("condition");
        int test1 = victim.GetInteger("condition");

        if (test == 1)    //TODO
        {
            // if test = 1 then it means you saved mohsen ang got the sword so kill zombie 
            killZoombie();
            Debug.Log("zombie died!!");
        }
        else 
            if((test1 == 1) && (player.transform.position.x == transform.position.x)) //needs to be checked
            {
                Debug.Log("player died!!");
                killPlayer();
            }

    }


    public void killPlayer()
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
            Debug.Log("dfdskfhdsfhdkfjhdkfhadkfhadkjfhadkjfhad");

        }

    }

    public void killZoombie()
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
                anim.SetInteger("condition", 2);
            }
            

        }

    }




}
