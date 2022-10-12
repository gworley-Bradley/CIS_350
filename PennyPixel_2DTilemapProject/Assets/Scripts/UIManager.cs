/*
 * (Gavin Worley)
 * (Assignment 5A)
 * (Brief description of the code in the file.
 *  Controls the UI and the score of the game, also, 
 *locks the final object until the rest have been picked up)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public Text scoreText;
    public int score = 0;

    public PlayerPlatformerController playerControllerScript;
    private GameObject lastGem;

    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        lastGem = GameObject.FindGameObjectWithTag("lastGem");
        if (scoreText == null)
        {
            scoreText = FindObjectOfType<Text>();
        }

        if (playerControllerScript == null)
        {
            playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPlatformerController>();
        }

        scoreText.text = "Score: 0";

    }

    // Update is called once per frame
    void Update()
    {
        if (!won)
        {
            scoreText.text = "Score: " + score;
        }

        if (score >= 31)
        {
            won = true;
            scoreText.text = "You Win!" + "\n" + "Press R to Try Again!";
        }

        if (playerControllerScript.gameOver && !won)
        {
            scoreText.text = "You Lose!" + "\n" + "Press R to Try Again";
        }

        if ((won || playerControllerScript.gameOver) && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (score >= 30)
        {
            lastGem.GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
