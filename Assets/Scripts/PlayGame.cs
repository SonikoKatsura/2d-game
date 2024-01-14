using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            AudioManager.instance.PlayMusic("Menu");
        }
        else if (SceneManager.GetActiveScene().name == "Lose")
        {
            AudioManager.instance.PlayMusic("Lost_A_Life");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (SceneManager.GetActiveScene().name == "Win")
            {
                SCManager.instance.LoadScene("MainMenu");
            }
            else
            {
                AudioManager.instance.PlayMusic("Stage1");
                SCManager.instance.LoadScene("Level1");
            }
        }
    }
}
