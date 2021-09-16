using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
            SceneManager.LoadScene(0);

        if(Input.GetKeyDown(KeyCode.Escape))
            Quit();
    }

    void Quit(){
        if(Application.isEditor)
            UnityEditor.EditorApplication.isPlaying = false;
        else
            Application.Quit();
    }
}
