using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1LeftPaddle : Paddle
{
    [Header("References For this Object and Others")]
    private Vector3 dir;
    public bool player1WantsToPlay;
    public Rigidbody ball;

    /// <summary>
    /// Movement of the left Paddle (player1) if not in Menu
    /// </summary>
    void Update()
    {
        if (player1WantsToPlay ==true )
        {
            if (Input.GetKey(KeyCode.W))
            {

                dir = Vector3.forward;
            }
            else if (Input.GetKey(KeyCode.S))
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
            player1WantsToPlay = false;
        }


    }
    /// <summary>
    ///AI system if TitleScreen is on so Computer plays against Computer while player chooses...
    /// </summary>
    private void FixedUpdate()
    {
        if (player1WantsToPlay == true)
        {
            if (dir.sqrMagnitude > 0)
            {
                rb.AddForce(dir * speed);
            }
        }
        else if (player1WantsToPlay == false)
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
