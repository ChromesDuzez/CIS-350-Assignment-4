/* 
 * Zach Wilson
 * CIS 350 Assignment 4
 * This script manages the scoreboard and the win condition
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreboard;
    public int WinCondition;
    public PlayerControllerX playerControllerScript;

    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        if (scoreboard == null)
        {
            scoreboard = FindObjectOfType<Text>();
        }

        if (playerControllerScript == null)
        {
            playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerX>();
        }

        scoreboard.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            scoreboard.text = "Score: " + score;
        }

        if (playerControllerScript.gameOver && !won)
        {
            scoreboard.text = "You Lose!" + "\n" + "Press R to Try Again!";
        }

        //Win Condition: 10 points
        if (score >= WinCondition)
        {
            playerControllerScript.gameOver = true;
            won = true;

            //playerControllerScript.StopRunning();

            scoreboard.text = "You Win!" + "\n" + "Press R to Try Again!";
        }

        if (playerControllerScript.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
