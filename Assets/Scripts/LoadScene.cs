using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LoadScene : NetworkBehaviour {
	//private int Scene = 0;

	public void changeScene()
	{
        //SceneManager.LoadScene (scene);
        //NetworkLobbyManager.singleton.ServerChangeScene("Multiplayer");
        SceneManager.LoadSceneAsync(0);
        //NetworkLobbyManager.singleton.ServerChangeScene(NetworkLobbyManager.singleton.)
    }
}
