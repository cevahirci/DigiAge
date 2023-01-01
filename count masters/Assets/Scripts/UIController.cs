using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject startScreen,loseScreen;
    public bool isStarted, isFinish;

    private void Start()
    {
        startScreen.SetActive(true);
        isStarted = false;
        isFinish = false;
    }

    public void StartButton()
    {
        isStarted = true;
        startScreen.SetActive(false);
    }

    public void ReplayButton()
    {
        SceneManager.LoadScene(0);
    }

    public void Finish()
    {
        isFinish = true;
        loseScreen.SetActive(true);
    }
}
