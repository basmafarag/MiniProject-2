using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoombieScript : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    Vector3 movedir = Vector3.zero;
    int speed = 1;
    CharacterController controller;
    float gravity = 8;
    float timeLeft = 10.0f;


    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();



    }

    void Update() 
    {
        killZoombie();

        if (gameObject.GetComponent<PlayerController>().withSword == false)    //TODO
        {

            killPlayer();
        }
        else
        {
           killZoombie();
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
