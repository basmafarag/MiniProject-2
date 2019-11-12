using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    float speed = 6;
    Animator anim;
    float gravity = 8;
    Vector3 movedir = Vector3.zero;
    CharacterController controller;
    float rotSpeed = 80;
    float rot = -34f;
    float rotatedir = 0;
    bool choose = true;
    public GameObject KillerObject;
    public GameObject VictimObject;
    Animator victim;
    Animator killer;
    public Canvas Choice1;
    public Canvas Choice2;
    public Canvas congratulations;
    bool killingKiller = false;
    bool saveMohsen = false;
    bool leaveMohsen = false;
    bool RRoom = false;
    bool LRoom = false;
    public GameObject sword;


    // TODO
    public bool withSword;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        killer = KillerObject.GetComponent<Animator>();
        victim = VictimObject.GetComponent<Animator>();
        Choice1.gameObject.SetActive(true);
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        //movemenet();
        if (true)
        {
            LeaveMohsen();
            SaveMohsen();
            LeftRoom();
            RightRoom();
        }

        if (Input.GetMouseButton(0))
        {
            anim.Play("handAttack");

        }
    }

    void SaveMohsen()
    {
        if ((Input.GetKeyUp(KeyCode.H) || saveMohsen) && !leaveMohsen)
        {
            saveMohsen = true;
            withSword = true;
            Choice1.gameObject.SetActive(false);

            if (this.gameObject.transform.position.x > 2f)
            {
                if (!killingKiller)
                {
                    controller.Move(movedir * Time.deltaTime);
                    anim.SetInteger("condition", 1);
                    movedir = new Vector3(0, 0, 1);
                    movedir *= speed;
                    movedir = transform.TransformDirection(movedir);
                }
            }
            else
            {
                if (!killingKiller)
                {
                    anim.SetInteger("condition", 0);
                    movedir = new Vector3(0, 0, 0);
                    anim.SetInteger("condition", 2);
                    StartCoroutine(KillerDie());
                    killingKiller = true;

                }
                

            }
        }

    }

    IEnumerator KillerDie()
    {
        yield return new WaitForSeconds(2);
        killer.SetInteger("condition", 1);
        yield return new WaitForSeconds(1);
        anim.SetInteger("condition", 0);
        victim.SetInteger("condition", 2);
        choose = false;
        saveMohsen = false;
        sword.SetActive(true);
        congratulations.gameObject.SetActive(true);

        yield return new WaitForSeconds(2);
        congratulations.gameObject.SetActive(false);
        Choice2.gameObject.SetActive(true);

    }



    void LeaveMohsen()
    {

        if (Input.GetKeyUp(KeyCode.Q) && !saveMohsen)
        {

            leaveMohsen = true;
            withSword = false;
            Choice1.gameObject.SetActive(false);
            killer.SetInteger("condition", 2);

            StartCoroutine(VictimDie());

        }
       

    }

    IEnumerator VictimDie()
    {
        yield return new WaitForSeconds(2);
        victim.SetInteger("condition", 1);
        killer.SetInteger("condition", 0);
        choose = false;
        leaveMohsen = false;

        yield return new WaitForSeconds(2);
        congratulations.gameObject.SetActive(false);
        Choice2.gameObject.SetActive(true);

    }

    void LeftRoom()
    {
        //bosbos room
        if ((Input.GetKeyUp(KeyCode.L) || LRoom) && !RRoom)
        {
            LRoom = true;
            Choice2.gameObject.SetActive(false);
            //Debug.Log("you chose left room, lucky");

            if (transform.position.x > -22f)
            {
                rot = -112f;
                transform.eulerAngles = new Vector3(0, rot, 0);
                controller.Move(movedir * Time.deltaTime);
                anim.SetInteger("condition", 1);
                movedir = new Vector3(0, 0, 1);
                movedir *= speed;
                movedir = transform.TransformDirection(movedir);

            }
            else
            {
                rot = -90f;
                transform.eulerAngles = new Vector3(0, rot, 0);
                RRoom = false;
                anim.SetInteger("condition", 0);
                movedir = new Vector3(0, 0, 0);
                movedir = transform.TransformDirection(movedir);
            }

            if (transform.position.x < -20f)
            {
                rot = -90f;
                transform.eulerAngles = new Vector3(0, rot, 0);
            }

        }
    }

    void RightRoom()
    {
        //fawzy room
        if ((Input.GetKeyUp(KeyCode.R) || RRoom) && !LRoom)
        {
            RRoom = true;
            Choice2.gameObject.SetActive(false);
            //Debug.Log("you chose right room, unlucky");
            
            if (transform.position.x > -27f)
            {
                rot = -67f;
                transform.eulerAngles = new Vector3(0, rot, 0);
                controller.Move(movedir * Time.deltaTime);
                anim.SetInteger("condition", 1);
                movedir = new Vector3(0, 0, 1);
                movedir *= speed;
                movedir = transform.TransformDirection(movedir);
                
            }
            else
            {
                rot = -90f;
                transform.eulerAngles = new Vector3(0, rot, 0);
                RRoom = false;
                anim.SetInteger("condition", 0);
                movedir = new Vector3(0, 0, 0);
                movedir = transform.TransformDirection(movedir);
            }

            if (transform.position.x < -20f)
            {
                rot = -90f;
                transform.eulerAngles = new Vector3(0, rot, 0);
            }
        }

    }

    void movemenet()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("condition", 1);
            movedir = new Vector3(0, 0, 1);
            movedir *= speed;
            movedir = transform.TransformDirection(movedir);

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("condition", 0);
            movedir = new Vector3(0, 0, 0);
            movedir *= speed;

        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetInteger("condition", 1);
            movedir = new Vector3(0, 0, -1);
            movedir *= speed;
            movedir = transform.TransformDirection(movedir);

        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetInteger("condition", 0);
            movedir = new Vector3(0, 0, 0);
            movedir *= speed;

        }
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);
        controller.Move(movedir * Time.deltaTime);
        movedir.y -= gravity * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        
            Debug.Log("asdasd");
      
    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("asdasd");
       
    }
}
