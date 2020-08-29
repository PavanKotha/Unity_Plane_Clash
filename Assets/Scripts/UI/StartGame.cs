using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class StartGame : MonoBehaviour
{
    public NetworkRoomManager manager;
    public TMP_InputField ipField;
    public GameObject joinPanel;
    public MainMenu mainMenu;

    public void onHostButton()
    {
        if (!NetworkClient.active)
        {
            manager.StartHost();
        }
    }

    public void onServerButton()
    {
        if (!NetworkClient.active)
        {
            manager.StartServer();
        }
    }

    public void onClientButton()
    {
        if (!joinPanel.activeSelf)
        {
            joinPanel.SetActive(true);
        }
        else
        {
            joinPanel.SetActive(false);
        }
    }

    public void onJoinButton()
    {
        manager.networkAddress = ipField.text;
        if (!NetworkClient.active)
        {
            manager.StartClient();
        }
    }

    public void onBackButton()
    {
        if (joinPanel.activeSelf)
        {
            joinPanel.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
            mainMenu.defaultHome();
        }
        
    }

    public void onHomeButton()
    {
        gameObject.SetActive(false);
        mainMenu.defaultHome();
    }

}
