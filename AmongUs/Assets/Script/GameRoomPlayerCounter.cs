using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class GameRoomPlayerCounter : NetworkBehaviour
{
    [SyncVar]
    private int minPlayer;
    [SyncVar]
    private int maxPlayer;

    [SerializeField]
    private Text playerCountText;

    public void UpdatePlayerCount()
    {

        var players = FindObjectsOfType<AmongUsRoomPlayer>();
        bool isStartable = players.Length >= minPlayer;
        var manager = NetworkManager.singleton as AmongUsRoomManager;
        playerCountText.text = string.Format("{0}/{1}", players.Length, maxPlayer);
        LobbyUIManager.Instance.SetInteractableStartButton(isStartable);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isServer)
        {
            var manager = NetworkManager.singleton as AmongUsRoomManager;
            minPlayer = manager.minPlayerCount;
            maxPlayer = manager.maxConnections;
        }
    }
}


