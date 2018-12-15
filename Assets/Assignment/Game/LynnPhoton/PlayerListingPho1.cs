using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListingPho1 : MonoBehaviour {

	public PhotonPlayer PhotonPlayer { get; private set; }

    [SerializeField]
    private Text _playerName;
    private Text PlayerName
    {
        get { return _playerName; }
    }

    public void ApplyPhotonPlayer(PhotonPlayer photonPlayer)
    {
        PhotonPlayer = photonPlayer;
        photonPlayer.NickName = name = "PlayerNum#" + Random.Range(1000, 9999);

        PlayerName.text = photonPlayer.NickName;
    }

}
