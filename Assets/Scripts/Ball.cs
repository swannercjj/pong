using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] float ballBaseSpeed;
    [SerializeField] Rigidbody2D rb;

    Vector2 ballSpeed;

    public event Action LeftGoalScoredEvent = delegate { };
    public event Action RightGoalScoredEvent = delegate { };


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNewBall());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LaunchBall()
    {
        float xVel = Random.Range(0, 2) * 2 - 1;    // x dirction?
        float yVel = Random.Range(0.2f, 1f) * Random.Range(0, 2) * 2 - 1;    // y angle
        ballSpeed = ballBaseSpeed * new Vector2(xVel, yVel).normalized;
        rb.velocity = ballSpeed;
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Left Goal")){
            Debug.Log("left goal scored");
            LeftGoalScoredEvent();
        }
        if (collider.CompareTag("Right Goal")){
            Debug.Log("right goal scored");
            RightGoalScoredEvent();
        }
        StartCoroutine(SpawnNewBall());
    }

    IEnumerator SpawnNewBall()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        rb.velocity = Vector2.zero;
        transform.position = Vector3.zero;

        yield return new WaitForSeconds(1f); // pause for one second

        // blink for ball to start moving
        for (int i = 0; i < 3; i++) {
            yield return new WaitForSeconds(0.25f);
            GetComponent<SpriteRenderer>().enabled = false; // disappear
            yield return new WaitForSeconds(0.25f);
            GetComponent <SpriteRenderer>().enabled = true; // appear
        }

        yield return new WaitForSeconds (1f);
        LaunchBall();
    }
}
