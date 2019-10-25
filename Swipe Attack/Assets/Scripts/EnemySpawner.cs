using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Parameters")]
    public Transform spawnPosition;
    public AnimationCurve spawnCurve;
    public GameObject[] enemyPrefabs = new GameObject[3];
    float timer;
    bool spawnEnemy;
    int x;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
       AnimationCurveReach(spawnCurve);
        SpawnEnemy();
    }

    void AnimationCurveReach(AnimationCurve curve)
    {
        float curveAmount = curve.Evaluate(timer);
        
            if (x == curve.length - 1)
            {
                x = 0;
                timer = 0;
            }
            else
            {

                Keyframe frame = curve[x];
                float keyframeTime = frame.time;
                if (timer < keyframeTime)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    spawnEnemy = true;
                    x++;
                }
            }
        

      

        
    }

    void SpawnEnemy()
    {
        if (spawnEnemy)
        {
            int b = Random.Range(0, enemyPrefabs.Length);
            GameObject enemy = Instantiate(enemyPrefabs[b],transform);
            enemy.transform.position = spawnPosition.transform.position;
            enemy.transform.eulerAngles = new Vector3(0,0, Random.Range(0, 360));
            spawnEnemy = false;
        }
    }
}
