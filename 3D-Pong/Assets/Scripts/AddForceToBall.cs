using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceToBall : MonoBehaviour
{
    [Header("Force Added to Ball")]
    public float bounceForce;

    [Header("Difficulty Timers")]
    [SerializeField]
    private float timeElapsed;
    public float timeToChangeDifficultyNormal = 60f;//these numbers are to put different difficulties!!
    public float timeToChangeDifficultyHard = 180f;
    public float timeToChangeDifficultyExpert = 240f;

    private void Update()
    {
        timeElapsed += Time.deltaTime;
    }
    /// <summary>
    /// This part we are getting the exact collision point from the ball
    /// to add a Force on the opposite direction, as well as adding more force over time
    /// to increase difficulty of the game...
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        BallMovement ball = collision.gameObject.GetComponent<BallMovement>();


        if (ball != null)
        {
            Vector3 normal = collision.GetContact(0).normal;
            ball.AddForce(-normal * bounceForce);
        }
        if (timeElapsed >= timeToChangeDifficultyNormal)
        {
            bounceForce = 75;
        }
        if (timeElapsed >= timeToChangeDifficultyHard)
        {
            bounceForce = 125;
        }
        if (timeElapsed >= timeToChangeDifficultyExpert)
        {
            bounceForce = 200;
        }
    }

}
