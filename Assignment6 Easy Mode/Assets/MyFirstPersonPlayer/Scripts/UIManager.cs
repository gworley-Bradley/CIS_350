using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : GameManager
{
    public GameObject[] hiddenExits;
    public Text scoreText;
    public int tutEnemies = 0;
    public int tutCoin = 0;
    public int mainEnemies = 0;
    public int mainCoins = 0;

    public bool won = false;
    public bool tutWon = false;

    // Start is called before the first frame update
    void Start()
    {
        if (scoreText == null)
        {
            scoreText = FindObjectOfType<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!tutWon && SceneManager.GetActiveScene().name == "Introduction")
        {
            scoreText.text = "Coins: " + tutCoin + "\n" + "Enemies: " + tutEnemies;
        }
        if (tutWon && SceneManager.GetActiveScene().name == "Introduction")
        {
            scoreText.text = "You Win!" + "\n" + "Press R to Advance to Level 1!";
        }

        if (tutWon && Input.GetKeyDown(KeyCode.R) && SceneManager.GetActiveScene().name == "Introduction")
        {
            tutCoin = 0;
            tutEnemies = 0;
            tutWon = false;

            AsyncOperation ao = SceneManager.LoadSceneAsync("MyFirstPersonPlayer", LoadSceneMode.Single);
            ao = SceneManager.UnloadSceneAsync("Introduction");
        }
        if (!won && SceneManager.GetActiveScene().name != "Introduction")
        {
            scoreText.text = "Coins: " + mainCoins + "\n" + "Enemies: " + mainEnemies;
        }
        if (won && SceneManager.GetActiveScene().name != "Introduction")
        {
            scoreText.text = "You Win!" + "\n" + "Press R to Try Again!";
        }

        if (won && Input.GetKeyDown(KeyCode.R) && SceneManager.GetActiveScene().name != "Introduction")
        {
            AsyncOperation ao = SceneManager.LoadSceneAsync("Main Menu", LoadSceneMode.Single);
        }


        if (mainCoins == 5 && mainEnemies == 10)
        {
            hiddenExits = GameObject.FindGameObjectsWithTag("Final");
            for (int i = hiddenExits.Length - 1; i >= 0; i--)
            {
                Destroy(hiddenExits[i].gameObject);
            }
        }

        if (tutCoin == 1 && tutEnemies == 3)
        {
            tutWon = true;
        }


    }
}
