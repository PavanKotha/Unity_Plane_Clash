using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Mirror;

[AddComponentMenu("")]
public class NetworkRoomPlayerExt : NetworkRoomPlayer
{
    public Room UI;
    public GameObject Canvas;
    private string playerPrefsNameKey = "playerName";
    public string displayName { get; private set; }


    static readonly ILogger logger = LogFactory.GetLogger(typeof(NetworkRoomPlayerExt));
    public event Action onReadyStateChanged;

    public void Awake()
    {
        UI = gameObject.GetComponent<Room>();
    }

    public override void OnStartClient()
    {

        if (logger.LogEnabled()) logger.LogFormat(LogType.Log, "OnStartClient {0}", SceneManager.GetActiveScene().path);

        base.OnStartClient();
        displayName = PlayerPrefs.GetString(playerPrefsNameKey);
    }

    public override void OnClientEnterRoom()
    {
        if (logger.LogEnabled()) logger.LogFormat(LogType.Log, "OnClientEnterRoom {0}", SceneManager.GetActiveScene().path);
        if (NetworkClient.active && hasAuthority)
        {
            Canvas.gameObject.SetActive(true);
        }
        UpdateDisplayAllPlayers();

    }

    public override void OnClientExitRoom()
    {
        if (logger.LogEnabled()) logger.LogFormat(LogType.Log, "OnClientExitRoom {0}", SceneManager.GetActiveScene().path);
        if (NetworkClient.active && hasAuthority)
        {
            Canvas.gameObject.SetActive(false);  
        }
        UpdateDisplayAllPlayers();
    }

    public override void ReadyStateChanged(bool _, bool newReadyState)
    {
        onReadyStateChanged?.Invoke();

        UpdateDisplayAllPlayers();

        //UI.UpdateDisplay();
        if (logger.LogEnabled()) logger.LogFormat(LogType.Log, "ReadyStateChanged {0}", newReadyState);
    }

    public void onReadyButton()
    {
        if (!readyToBegin)
        {        
            CmdChangeReadyState(true);
            UI.onReady();         
        }
        else
        {
            UI.onCancel();
        }
    }
    public void onCancelButton()
    {
        if (readyToBegin)
        {
            CmdChangeReadyState(false);
            UI.onCancel();
        }
        else
        {
            UI.onReady();
        }
    }

    public void onStartGamelButton()
    {
        NetworkRoomManager room = NetworkManager.singleton as NetworkRoomManager;
        Room ui = room.roomSlots[0].gameObject.GetComponent<Room>();
        ui.ShowStartButton(false);
        room.ServerChangeScene(room.GameplayScene);
    }

    private void UpdateDisplayAllPlayers()
    {
        bool allplayersReady = true;
        NetworkRoomManager room = NetworkManager.singleton as NetworkRoomManager;
        for (int i = 0; i < room.roomSlots.Count; i++)
        {
            Room ui = room.roomSlots[i].gameObject.GetComponent<Room>();
            ui.UpdateDisplay();

            if (!room.roomSlots[i].readyToBegin) allplayersReady = false;
        }

        Debug.Log("All players ready : " + allplayersReady);
        Debug.Log("Index : " + index);
        if (allplayersReady)
        {
            Room ui = room.roomSlots[0].gameObject.GetComponent<Room>();
            ui.ShowStartButton(true);
        }
        else
        {
            Room ui = room.roomSlots[0].gameObject.GetComponent<Room>();
            ui.ShowStartButton(false);
        }
    }

    

}

