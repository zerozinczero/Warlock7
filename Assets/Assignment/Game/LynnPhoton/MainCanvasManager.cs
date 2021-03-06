﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasManager : MonoBehaviour
{

    public static MainCanvasManager instance;


    [SerializeField]
    private LobbyCanvas _lobbyCanvas;
    public LobbyCanvas LobbyCanvas
    {
        get { return _lobbyCanvas; }
    }

    [SerializeField]
    private CurrentRoomCanvasPho _currentRoomCanvas;
    public CurrentRoomCanvasPho CurrentRoomCanvas
    {
        get { return _currentRoomCanvas; }
    }


    private void Awake()
    {
        instance = this; ;
    }


}
