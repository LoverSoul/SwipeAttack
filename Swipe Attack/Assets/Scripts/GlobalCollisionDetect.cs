using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCollisionDetect : MonoBehaviour
{
    public bool lazer;
    public bool player;
    public bool sphere;

    PlayerController contr;

    void Start()
    {
        contr = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerController>();
    } 

    void OnTriggerExit2D(Collider2D col)
    {
        if (sphere)
        {
            if (col.tag == "Enemy")
            {
                if (!col.GetComponent<Enemy>().dead)
                {
                    contr.dead = true;
                }
            }
 
        }
        if (lazer)
            {
                if (col.tag == "Enemy")
                {
                transform.localScale = new Vector2(transform.localScale.x, contr.radius/2-1);

            }

        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (lazer)
        {
            if (col.tag == "Enemy")
            {
                    float dist = Vector2.Distance(transform.position, col.transform.position) / 100;
                    if (dist > contr.radius / 2 -1)
                        dist = contr.radius / 2 -1;
                    transform.localScale = new Vector2(transform.localScale.x, dist);

                    col.GetComponent<Enemy>().wasHit = true;
                
               
               
            }
        }
    }
        void OnTriggerEnter2D(Collider2D col)
    {

        if (player)
        {
            if (col.tag == "Enemy")
            {
               GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerController>().dead = true;
            }
        }


    }
}
