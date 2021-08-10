using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGoalP2 : MonoBehaviour
{
    [Header("References for this Object")]
    public BallMovement ball;

    /// <summary>
    /// Collider detection to trigger events
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            if (ball.P1 == true)
            {
                FindObjectOfType<AUDIO_MANAGER>().Play("ScoreGoal");
                GameObject.Find("GameManager").GetComponent<GameManager>().P1Scores();
            }
            else if (ball.P2 == true)
            {
                FindObjectOfType<AUDIO_MANAGER>().Play("ScoreGoal");
                GameObject.Find("GameManager").GetComponent<GameManager>().P1Scores();
            }
            else if (ball.P1 == false && ball.P2 == false)
            {
                Debug.Log("NoPlayerhasTouchtheBall");
                ball.ResetBallPosition();
            }

        }

    }
}
