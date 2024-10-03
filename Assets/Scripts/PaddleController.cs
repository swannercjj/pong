using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    // allows Unity editor to see even if private
    [SerializeField] Rigidbody2D leftPaddle;
    [SerializeField] Rigidbody2D rightPaddle;
    [SerializeField] float paddleSpeed;
    // [SerializeField] float ballSpeed;
    // Update is called once per frame
    void Update()
    {
        int leftVelocity = 0;
        int rightVelocity = 0;

        leftPaddle.velocity = Vector2.zero;
        rightPaddle.velocity = Vector2.zero;

        // paddle velocities
        // not if else to get all of inputs at the same time
        if (Input.GetKey(KeyCode.W))
        {
            leftVelocity++;
        }
        if (Input.GetKey(KeyCode.S))
        {
            leftVelocity--;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rightVelocity++;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rightVelocity--;
        }

        leftPaddle.velocity = new Vector2(0, leftVelocity * paddleSpeed);
        rightPaddle.velocity = new Vector2(0, rightVelocity * paddleSpeed);
    }
}
