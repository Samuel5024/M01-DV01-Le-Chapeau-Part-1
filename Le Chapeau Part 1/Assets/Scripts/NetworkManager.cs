using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager instance;

    void Awake()
    {
         if (instance != null && instance != this) //if an instance already exists
                                                   //and it's not this one- destroy us
            gameObject.SetActive(false);
        else
        {
            instance = this; //set the instance
            DontDestroyOnLoad(gameObject);
        }
    }

    public override void OnConnectedToMaster()
    {
        CreateRoom("testroom");
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room: " + PhotonNetwork.CurrentRoom.Name);
    }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();        
    }

    public void CreateRoom (string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    [PunRPC] // changes scene using Photon's system
    public void ChangeScene (string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }

    void Update()
    {
        
    }
}
