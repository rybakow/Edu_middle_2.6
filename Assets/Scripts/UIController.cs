using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Button LoadFromServerButton;
    public GameObject FirstPanel;
    public Button ContinueGameButton;

    public Text healthValueTextUI;
    public Text firstAidValueTextUI;

    private void Start()
    {
        Time.timeScale = 0;
        ContinueGameButton.interactable = true;
    }

    void FixedUpdate()
    {
        LoadFromServerButton.interactable = GoogleDriveFunctions.LastUploadedFile != null ? true : false;
        
        healthValueTextUI.text = GameManager.Health.ToString();
        firstAidValueTextUI.text = GameManager.FirstAidCount.ToString();
    }

    public void NewGame()
    {
        FirstPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ContinueGame()
    {
        ServerTools.LoadStats(true);
        NewGame();
        Time.timeScale = 1;
    }

    public void LoadGame()
    {
        ServerTools.LoadStats();
        Time.timeScale = 1;
    }
}
