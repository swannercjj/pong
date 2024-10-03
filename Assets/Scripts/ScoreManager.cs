using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Ball ball;
    [SerializeField] int leftScore = 0;
    [SerializeField] int rightScore = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        ball.LeftGoalScoredEvent += LeftGoalScored;
        ball.RightGoalScoredEvent += RightGoalScored;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LeftGoalScored()
    {
        rightScore++;
    }

    void RightGoalScored()
    {
        leftScore++;
    }
}
