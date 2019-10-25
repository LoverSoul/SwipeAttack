using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {//Если z=0 то transform.up, если z= -90 - transform.right, 90 - left, 180 - down;
        float b = transform.eulerAngles.z * Mathf.Deg2Rad;
        float y = Mathf.Cos(b);
        float x = Mathf.Sin(b);
        Vector3 v = new Vector3(-x, y, 0);

        transform.position += v * speed;
    }

    
}
