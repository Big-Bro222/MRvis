﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
namespace WallRemote
{
    public class Launcher : MonoBehaviourPunCallbacks
    {

        public GameObject connectedScreen;
        public GameObject disconnectedScreen;
        public GameObject HomePage;

        public void OnClick_ConnectBtn()
        {
            HomePage.SetActive(false);
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {

            PhotonNetwork.JoinLobby(TypedLobby.Default);
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            disconnectedScreen.SetActive(true);
        }

        public override void OnJoinedLobby()
        {
            if (disconnectedScreen.activeSelf)
            {
                disconnectedScreen.SetActive(false);
            }
            connectedScreen.SetActive(true);
        }


    }

}
