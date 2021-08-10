using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComputerPaddleRight : Paddle
{
    [Header("References For this Object and Others")]
    public Rigidbody ball;
    private Vector3 dir;
    public bool player2WantsToPlay;

    [Header("Difficulty Timers")]
    [SerializeField]
    private float timeElapsed; //Present timer for the object
    public float timeToChangeDifficultyNormal = 90f;//these numbers are to put different difficulties!!
    public float timeToChangeDifficultyHard = 180f;
    public float timeToChangeDifficultyExpert = 300f;


    /// <summary>
    /// Movement of the Right Paddle (player2) if Vs mode is activated
    /// if not AI systeam is on and will make the Paddle move faster over time increasing difficulty
    /// </summary>
    void Update()
    {

        if(player2WantsToPlay == true)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {

                dir = Vector3.forward;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                dir = Vector3.back;

            }
            else
            {
                dir = Vector3.zero;
            }
        }
        else
        {
            player2WantsToPlay = false;
            timeElapsed += Time.deltaTime;
        }
        if (timeElapsed >= timeToChangeDifficultyNormal)
        {
            speed = 17;
        }
        if (timeElapsed >= timeToChangeDifficultyHard)
        {
            speed = 20;
        }
        if (timeElapsed >= timeToChangeDifficultyExpert)
        {
            speed = 23;
        }


    }
    /// <summary>
    /// Small AI where is looking at ball position in z and x axis to move the Paddle ( this will only work if Player 1 is playing alone)
    /// Otherwise Player 2 will be able to move the Paddle and deactivate the AI...
    /// </summary>
    void FixedUpdate()
    {
        if(player2WantsToPlay== true)
        {
            if (dir.sqrMagnitude > 0)
            {
                rb.AddForce(dir * speed);
            }
        }
        else if(player2WantsToPlay == false)
        {
            if (ball.position.x > 0f)
            {
                if (ball.position.z > transform.position.z)
                {
                    rb.AddForce(Vector3.forward * speed);
                }
                else if (ball.position.z < transform.position.z)
                {
                    rb.AddForce(Vector3.back * speed);
                }
            }
            else
            {
                if (transform.position.z > 0f)
                {
                    rb.AddForce(Vector3.back * speed);
                }
                else if (transform.position.z < 0f)
                {
                    rb.AddForce(Vector3.forward * speed);
                }
            }
        }


    }

}
