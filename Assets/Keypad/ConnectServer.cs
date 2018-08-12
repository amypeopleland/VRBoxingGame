using UnityEngine;
using System.Collections;

public class ConnectServer : MonoBehaviour {

    public string LevelName;

	void Update () {
        if (Network.peerType == NetworkPeerType.Client && LevelName != null)
        {
            Application.LoadLevel(LevelName);
        }
	}

    public static void ConnectToServer(string _ip)
    {
        if (Network.peerType == NetworkPeerType.Disconnected)
        {
            Network.Connect(_ip, 2244);
        }
    }

}
