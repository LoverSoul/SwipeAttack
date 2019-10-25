using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCollisionDetect : MonoBehaviour
{
    public bool lazer;
    public bool player;
    public bool sphere;

    

    void OnTriggerExit2D(Collider2D col)
    {
        if (sphere)
        {
            if (col.tag == "Enemy")
            {
                Debug.Log("Enemy gets away");
            }
               
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (player)
        {
            if (col.tag == "Enemy")
            {
                Debug.Log("Enemy kill player");
            }
        }

        if (lazer)
        {
            if (col.tag == "Enemy")
            {
                Debug.Log("Enemy was killed by Lazer");
            }
        }

    }
}
