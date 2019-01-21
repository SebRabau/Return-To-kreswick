using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public void toMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    public void toGame()
    {
        FindObjectOfType<AudioController>().StopMusic();
        Application.LoadLevel("Game");
    }

    public void toOptions()
    {
        Application.LoadLevel("Options");
    }
}
