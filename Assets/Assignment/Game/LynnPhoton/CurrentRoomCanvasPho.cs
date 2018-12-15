using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomCanvasPho : MonoBehaviour {

    public void OnClickStartSync()
    {
        if (!PhotonNetwork.isMasterClient)
            return;

        PhotonNetwork.LoadLevel(1);
    }
}
