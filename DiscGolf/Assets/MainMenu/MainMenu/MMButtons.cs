using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MMButtons : MonoBehaviour {

    public void PlayGame()
    {
        Application.LoadLevel("Scene2");
    }

    public void Options()
    {
        Application.LoadLevel("Scene3");
    }

    public void Back()
    {
        Application.LoadLevel("Scene1");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
