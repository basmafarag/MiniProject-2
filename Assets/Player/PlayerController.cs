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
    bool choose = true;
    public GameObject KillerObject;
    public GameObject VictimObject;
    Animator victim;
    Animator killer;
    public Canvas Choice1;
    public Canvas congratulations;
    bool killingKiller = false;
    bool saveMohsen = false;
    bool leaveMohsen = false;
    public GameObject sword;


    //bool for the decision if with a sword or nottt TODO
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

        movemenet();
        if (true)
        {
            LeaveMohsen();
            SaveMohsen();
        }

        if (Input.GetMouseButton(0))
        {
            anim.Play("handAttack");

        }
    }

    void SaveMohsen()
    {
        if ((Input.GetKeyUp(KeyCode.R) || saveMohsen) && !leaveMohsen)
        {
            saveMohsen = true;
            withSword = true;
            Choice1.gameObject.SetActive(false);
            if (this.gameObject.transform.position.x > -12f)
        {
            if (!killingKiller)
            {
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
