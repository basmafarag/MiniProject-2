using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoombie : MonoBehaviour
{

    Animator anim;
    Animator Zoombie;


    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        if (gameObject.GetComponent<PlayerController>().withSword = false)
        {

            move();
            killZoombies();
        }
        else
        {
            move();
            killPlayer();
        }

    }


    public void move()
    {

    }
    public void killZoombies()
    {

    }

    public void killPlayer()
    {

    }


}
