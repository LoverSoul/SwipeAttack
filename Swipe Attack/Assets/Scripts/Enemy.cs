using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public bool dead = false;
    [Header("Movement Control")]
    public int pointsForKill = 5;
    public float speed = 5f;
    [Range(1, 3)]
    public int tier;
    public float padding = 10f;
    public GameObject enemyVisualBase; 
    [Header("Hit Control")]
    public float hitTimer = 0.5f;
    public GameObject[] myBodies;
    public bool wasHit;
    [HideInInspector]
    public int hitCount;
    float timer;

    void Start()
    {
        hitCount = tier;
        timer = hitTimer;
        if (tier > 1)
        {
            GetComponent<BoxCollider2D>().offset = new Vector2(0,100*hitCount/1.5f);
          //  GetComponent<BoxCollider2D>().size = new Vector2(100, 100 * hitCount);
        }
        myBodies = new GameObject[tier];
        float b = transform.eulerAngles.z * Mathf.Deg2Rad;
        float y = Mathf.Cos(b);
        float x = Mathf.Sin(b);
        for (int a = 0; a < tier; a++)
        {
            GameObject tr = Instantiate(enemyVisualBase, transform);
            tr.transform.rotation = transform.rotation;
            tr.transform.localPosition = new Vector3(-((x*transform.localScale.x) * a), -((-100 * transform.localScale.y*1.5f - padding) * a));
            myBodies[a] = tr;
        }
    }

    // Update is called once per frame
    void Update()
    {//Если z=0 то transform.up, если z= -90 - transform.right, 90 - left, 180 - down;
        Movement();
        CollectHits();
    }

    void Movement()
    {
        float b = transform.eulerAngles.z * Mathf.Deg2Rad;
        float y = Mathf.Cos(b);
        float x = Mathf.Sin(b);
        Vector3 v = new Vector3(-x, y, 0);

        transform.position += v * speed;
    }

    void CollectHits()
    {

        if (wasHit)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                if (hitCount > 0)
                {
                    hitCount--;
                    Destroy(myBodies[hitCount]);
                    GetComponent<BoxCollider2D>().offset = new Vector2(0, 100 * hitCount / 2);

                    if (hitCount == 1)
                    {
                        GetComponent<BoxCollider2D>().offset = new Vector2(0,0);
                    }
                    wasHit = false;
                    timer = hitTimer;
                }

            }

            if (hitCount <= 0)
            {
                dead = true;
                GivePoints();
                Destroy(gameObject);

            }
        }
    }

    void GivePoints()
    {
        GameObject gameContr = GameObject.FindGameObjectWithTag("GameController");

        //Lazer Debug
        gameContr.GetComponent<PlayerController>().lazer.transform.localScale = new Vector2(.1f, gameContr.GetComponent<PlayerController>().radius / 2 -1);

        gameContr.GetComponent<ScoreConfig>().scoreInGame += pointsForKill;
        gameContr.GetComponent<ScoreConfig>().ShowScoreToPlayer();
    }


}
