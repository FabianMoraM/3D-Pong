using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    [Header("References for this Object")]
    public float speed;
    private Rigidbody rb;
    private Vector3 dir;
    public bool P1;
    public bool P2;

    [Header("UI Objects")]
    public Text p1ForceText;
    public Text p2ForceText;

    private float timeElapsedP1;
    private float timeElapsedP2;


    private void Awake()
    {
        P1 = false;
        P2 = false;
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        ResetBallPosition();
    }
    public void ResetBallPosition()
    {
        P1 = false;
        P2 = false;
        rb.position = Vector3.zero;
        rb.velocity = Vector3.zero;
        AddInitialBallMovement();

    }

  /// <summary>
  /// Shooting Mechanic hold a buttom down to make the ball go faster the moment the player touches the ball
  ///if button not press the moment the player touches the ball it will with the current Force...
  /// </summary>
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {

            timeElapsedP1 += Time.deltaTime;
            if (timeElapsedP1 >= 5)
            {
                timeElapsedP1 = 5;
            }
            p1ForceText.text = timeElapsedP1.ToString();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            timeElapsedP2 += Time.deltaTime;
            if (timeElapsedP2 >= 5)
            {
                timeElapsedP2 = 5;
            }
            p2ForceText.text = timeElapsedP2.ToString();
            timeElapsedP2 += Time.deltaTime;
        }
        else
        {
            timeElapsedP1 = 1;
            timeElapsedP2 = 1;
        }


    }
    /// <summary>
    /// Creating a Random direction for the ball can move differently every time the ball is reset
    /// </summary>
    void AddInitialBallMovement()
    {

        float x = Random.value<0.5 ? -1 : 1;
        float z = Random.value <0.5? Random.Range(-1,-0.5f) : Random.Range(0.5f, 1);
        
        dir = new Vector3(x, z);
        rb.AddForce(dir * speed);

    }
    /// <summary>
    /// Collider detection to trigger events
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "LeftPaddle")
        {
            FindObjectOfType<AUDIO_MANAGER>().Play("Hit Ball");
            Debug.Log("BounceBackright");
           // rb.AddForce(-dir *speed* addSpeed);
            P1 = true;
            P2 = false;
            FindObjectOfType<AUDIO_MANAGER>().Play("Hit Ball");

        }
        else if (other.tag == "RightPaddle")
        {
            FindObjectOfType<AUDIO_MANAGER>().Play("Hit Ball");
            Debug.Log("BounceBackleft");
           // rb.AddForce(dir * speed * addSpeed);
            P2 = true;
            P1 = false;
            
        }

    }
    /// <summary>
    /// To add Force to the ball each time it touches the player or the walls
    /// </summary>
    /// <param name="force"></param>

    public void AddForce(Vector3 force)
    {
        if (P1 == true)
        {
            rb.AddForce(force * timeElapsedP1);
        }
        else if(P2== true)
        {
            rb.AddForce(force * timeElapsedP2);
        }
        else
        {
            rb.AddForce(force);
        }
        
    }
}
