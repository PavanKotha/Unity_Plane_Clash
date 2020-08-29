using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MainMenu : MonoBehaviour
{
    public Button startGameButton;

    public TMP_InputField naemField;

    public GameObject optionsPanel;
    public GameObject startGamePanel;
    public GameObject mainMenuPanel;

    public string displayName { get; private set; }
    private string playerPrefsNameKey = "playerName";

    private void Start()
    {
        if (!PlayerPrefs.HasKey(playerPrefsNameKey))
        {
            PlayerPrefs.SetString(playerPrefsNameKey, "Player Name");
        }
    }

    public void defaultHome()
    {
        Debug.Log("home Called");
        gameObject.SetActive(true);
        optionsPanel.SetActive(false);
    }


    public void onStartGameButton() {
        gameObject.SetActive(false);
        startGamePanel.SetActive(true);
    }

    public void onOptionsButton()
    {
        startGameButton.interactable = false;
        if (!optionsPanel.activeSelf)
        {
            optionsPanel.SetActive(true);
            naemField.text = PlayerPrefs.GetString(playerPrefsNameKey);
        }
        else
        {
            optionsPanel.SetActive(false);
        }

    }

    public void onSaveButton()
    {
        if (!string.IsNullOrEmpty(naemField.text))
        {
            startGameButton.interactable = true;
            PlayerPrefs.SetString(playerPrefsNameKey, naemField.text);
            displayName = PlayerPrefs.GetString(playerPrefsNameKey);
            optionsPanel.SetActive(false);
        }
        
    }

    public void onQuitButtion() 
    {
        Application.Quit();
    }

}
