using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System;

public class Room : NetworkBehaviour
{
    public List<GameObject> roomSlotPanel;
    public Button readyButton;
    public Button cancelButton;
    public Button startGameButton;


    public void onReady()
    {
        // Change ready button to not ready
        readyButton.gameObject.SetActive(false);
        cancelButton.gameObject.SetActive(true);
    }
    public void onCancel()
    {
        // Change ready button to not ready
        readyButton.gameObject.SetActive(true);
        cancelButton.gameObject.SetActive(false);
    }

    public void readyStarteChanged()
    {
        NetworkRoomManager room = NetworkManager.singleton as NetworkRoomManager;
        for (int i = 0; i < room.numPlayers; i++)
        {
            if (room.roomSlots[i].isLocalPlayer)
            {

                room.roomSlots[i].CmdChangeReadyState(true);
                //roomSlotPanel[i].GetComponent<Image>().color = Color.green;
            }

        }
        readyButton.GetComponentInChildren<Text>().text = "Canel";
    }


    public void UpdateDisplay()
    {
        NetworkRoomManager room = NetworkManager.singleton as NetworkRoomManager;
        for (int i=0; i< roomSlotPanel.Count; i++)
        {
            if (i < room.roomSlots.Count)
            {
                if (room.roomSlots[i].readyToBegin)
                {
                    roomSlotPanel[i].GetComponent<Image>().color = Color.green;
                }
                else
                {
                    roomSlotPanel[i].GetComponent<Image>().color = Color.red;
                }

            }
            else
            { 
                roomSlotPanel[i].GetComponent<Image>().color = Color.red;
            }


        }
    }
    public void ShowStartButton(bool state)
    {
        startGameButton.gameObject.SetActive(state);
    }
}
