using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float del = 2f;
    public float radius = 10f;
    public float force = 700f;
    public GameObject Player;
    public GameObject ExpEff;
    float countdown;
    bool exploded = false;

    // Start is called before the first frame update
    void Start()
    {
        countdown = del;
        GameObject player = Player.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.x <= -27)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0 && !exploded)
            {
                Explode();
                exploded = true;
            }
        }
        
    }

    void Explode()
    {
        //Debug.Log("BOOM");

        for(int i = 0; i < 1;i++)
        {
            Instantiate(ExpEff, transform.position, transform.rotation);
        }
        
        Collider[] colli = Physics.OverlapSphere(transform.position, radius);
        
        foreach (Collider col in colli)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }

        }

        Destroy(gameObject);

        FindObjectOfType<GameMang>().GameOver();

    }
}
