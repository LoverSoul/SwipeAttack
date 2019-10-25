using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Preferences")]
    public GameObject player;
    public GameObject lazer;
    public GameObject centerObject;
    public float tapOnScreenDistance;
    public AnimationCurve speedIncrease;
    public float speed;
    public float radius;
    float currentAngle = -1.57f;
    bool active;
    bool leftRight;
    [Header("Visual Elements")]
    public GameObject circleElement;
    float currentDistance;
    float timer;
    float drag;

    [Header("Preferences")]
    public GameObject dragScreen;
    Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        circleElement.transform.localScale = new Vector3(radius, radius, 1);
     
        lazer.transform.localScale = new Vector3(lazer.transform.localScale.x, radius/2-1, lazer.transform.localScale.z);


    }

    // Update is called once per frame
    void Update()
    {
        DragConfiguer();
        Movement();
    }

    void DragConfiguer()
    {
        if (active)
        {
            Vector3 pinPos = Input.mousePosition;
            pinPos.y = dragScreen.transform.position.y;
            currentDistance = Vector3.Distance(startPosition, pinPos);

            if (currentDistance > tapOnScreenDistance)
            {
                Vector3 v = startPosition - pinPos;
                if (v.x > 0)
                    leftRight = false;
                else
                    leftRight = true;
            }
           
        }
    }

    void Movement()
    {
        if (active)
        {
            drag = AnimationCurveSet(speedIncrease);
            if (leftRight)
                currentAngle += drag / 10 * Time.deltaTime;
            else
                currentAngle -= drag / 10 * Time.deltaTime;
        }
        else
            if (timer > 0)
        {
            drag = AnimationCurveSet(speedIncrease);
            if (leftRight)
                currentAngle += drag / 10 * Time.deltaTime;
            else
                currentAngle -= drag / 10 * Time.deltaTime;
        }
        float x = Mathf.Cos(currentAngle) * radius * 50 + centerObject.transform.position.x;
        float y = Mathf.Sin(currentAngle) * radius * 50 + centerObject.transform.position.y;

        player.transform.position = new Vector2(x, y);
        Vector3 rot = (centerObject.transform.position - player.transform.position);
        player.transform.up = rot;
       
    }

    float AnimationCurveSet(AnimationCurve curve)
    {
            float curveAmount = curve.Evaluate(timer);
            Keyframe frame = curve[curve.length - 1];
            float keyframeTime = frame.time;
        if (currentDistance > tapOnScreenDistance)
        {
            if (timer < keyframeTime)
            {
                timer += Time.deltaTime;
            }
            else
                timer = keyframeTime;
        }
        else
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime*2;
            }
            else
                timer = 0;
        }
            return speed * curveAmount;
        
    }

    void Reset()
    {
        currentDistance = tapOnScreenDistance;
    }

    public void Tap()
    {
        if (!active)
        {
            startPosition = new Vector2(Input.mousePosition.x, dragScreen.transform.position.y);
            active = true;
        }


    }

    public void DeselectTap()
    {
        active = false;
        Reset();
    }
}