using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyNetworkPho : MonoBehaviour {

    private void Start()
    {
        if (!PhotonNetwork.connected)
        {
            print("Connecting to server..");
            PhotonNetwork.ConnectUsingSettings("0.0.0");
        }
    }

    private void OnConnectedToMaster()
    {
        print("Connected to master.");
        PhotonNetwork.automaticallySyncScene = true;
        PhotonNetwork.playerName = PlayerNetworkPho.instance.PlayerName;
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    private void OnJoinedLobby()
    {
        print("Joined lobby.");

        if (!PhotonNetwork.inRoom)
        {
            MainCanvasManager.instance.LobbyCanvas.transform.SetAsLastSibling();

        }
    }


}
