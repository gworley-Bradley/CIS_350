using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinPickup : MonoBehaviour
{
    private UIManager uiManager;

    private void Start()
    {
        uiManager = GameObject.FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && SceneManager.GetActiveScene().name == "Introduction")
        {
            uiManager.tutCoin++;
            Debug.Log(uiManager.tutCoin);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Player") && SceneManager.GetActiveScene().name == "MyFirstPersonPlayer")
        {
            uiManager.mainCoins++;
            Destroy(gameObject);
        }
    }
}
