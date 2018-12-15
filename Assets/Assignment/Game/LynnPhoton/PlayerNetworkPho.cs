using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNetworkPho : MonoBehaviour {

    public static PlayerNetworkPho instance;
    public string PlayerName { get; private set; }
    private PhotonView photonView;
    private int playersInGame = 0;

    private void Awake()
    {
        instance = this;
        name = "PlayerNum#" + Random.Range(1000, 9999);

        photonView = GetComponent<PhotonView>();

        PhotonNetwork.sendRate = 60;
        PhotonNetwork.sendRateOnSerialize = 30;
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Game")
        {
            if (PhotonNetwork.isMasterClient)
                MasterLoadedGame();
            else
                NonMasterLoadedGame();
        }
    }

    private void MasterLoadedGame()
    {
        photonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient, PhotonNetwork.player);
        photonView.RPC("RPC_LoadGameOthers", PhotonTargets.Others);
    }

    private void NonMasterLoadedGame()
    {
        photonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient, PhotonNetwork.player);
    }

    [PunRPC]
    private void RPC_LoadGameOthers()
    {
        PhotonNetwork.LoadLevel(1);
    }

    [PunRPC]
    private void RPC_LoadedGameScene(PhotonPlayer photonPlayer)
    {
        //PlayerManagement.Instance.AddPlayerStats(photonPlayer);

        playersInGame++;
        if (playersInGame == PhotonNetwork.playerList.Length)
        {
            print("All players are in the game.");
            photonView.RPC("RPC_CreatePlayer", PhotonTargets.All);
        }
    }
}
