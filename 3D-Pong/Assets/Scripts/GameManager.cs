using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int P1Score;
    private int P2Score;
    public string sceneNameToLoad;

    [Header("UI Objects")]
    public Text p1ScoreText;
    public Text p2ScoreText;
    public GameObject TitleScreen;
    public GameObject P1Mode;
    public GameObject VsMode;

    [Header("Game Objects")]
    public GameObject StartWalls;
    public GameObject Goals;

    [Header("OtherScripts")]
    public BallMovement ball;
    public PlayerComputerPaddleRight player2;
    public PlayerComputerPaddleRight player2_1;
    public PlayerComputerPaddleRight player2_2;
    public P1LeftPaddle player1;
    public P1LeftPaddle player1_1;
    public P1LeftPaddle player1_2;
    private void Awake()
    {
        
    }
    private void Start()
    {
        player1_2.player1WantsToPlay = false;
        player1_1.player1WantsToPlay = false;
        player1.player1WantsToPlay = false;
        player2.player2WantsToPlay = false;
        TitleScreen.gameObject.SetActive(true);
        P1Mode.gameObject.SetActive(false);
        VsMode.gameObject.SetActive(false);
        StartWalls.gameObject.SetActive(true);
        Goals.gameObject.SetActive(false);
    }
    /// <summary>
    /// To restart the Ball in case it gets Stuck and as well be able to restart the 
    /// game if necesary and escape the game...
    /// </summary>
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            ball.ResetBallPosition();
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }

    /// <summary>
    /// /This is to add the Scores for the different Players
    /// </summary>
    public void P1Scores()
    {
        Debug.Log("P1 Scored...");
        P1Score+=1;
        p1ScoreText.text = P1Score.ToString();
        ball.ResetBallPosition();
    }
    public void P2Scores()
    {
        Debug.Log("P2 Scored...");
        P2Score+=1;
        p2ScoreText.text = P2Score.ToString();
        ball.ResetBallPosition();
    }
    /// <summary>
    /// This part of the Script is for to turn Objects on or off after getting of the Menu,
    /// as well by doing this makes the Computer while your in the menu nor able to score
    /// just play in the background..
    /// </summary>
    public void Play()
    {
        P1Mode.gameObject.SetActive(true);
        VsMode.gameObject.SetActive(true);
    }
    public void P1Modes()
    { 

        TitleScreen.gameObject.SetActive(false);
        StartWalls.gameObject.SetActive(false);
        Goals.gameObject.SetActive(true);
        player1_2.player1WantsToPlay = true;
        player1_1.player1WantsToPlay = true;
        player1.player1WantsToPlay = true;
        ball.ResetBallPosition();
    }
    public void P2Modes()
    {
        TitleScreen.gameObject.SetActive(false);
        StartWalls.gameObject.SetActive(false);
        Goals.gameObject.SetActive(true);
        player1_2.player1WantsToPlay = true;
        player1_1.player1WantsToPlay = true;
        player1.player1WantsToPlay = true;
        player2.player2WantsToPlay = true;
        player2_1.player2WantsToPlay = true;
        player2_2.player2WantsToPlay = true;
        ball.ResetBallPosition();
    }


}
