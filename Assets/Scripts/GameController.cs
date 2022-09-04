using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public bool playState = false;
    public GameObject instructionPanel;
    public GameObject scorePanel;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Play()
    {
        playState = true;
        instructionPanel.SetActive(false);
        scorePanel.SetActive(true);
    }
}
