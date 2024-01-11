using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (SceneManager.loadedSceneCount == 1)
            {
                SceneManager.LoadScene("Map" , LoadSceneMode.Additive);
            }
        } 
    }
}
