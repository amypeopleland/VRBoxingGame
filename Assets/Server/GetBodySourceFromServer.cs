using UnityEngine;
using System.Collections;

public class GetBodySourceFromServer : MonoBehaviour {

    public ClientBodySource BS;
    public OVRCameraRig cameraController = null;

    string connectToIP = "10.5.94.106";
    int connectPort = 2244;
    string Message = "";
    float _time = 0.0f;


	void Start () {
	    
	}

    [RPC]
    void GetAllJoint(Vector3[] _joint, NetworkMessageInfo info)
    {
        BS.SetRawJoint(0, _joint);
    }

    [RPC]
    void GetAllJoint2(Vector3[] _joint, NetworkMessageInfo info)
    {
        BS.SetRawJoint(1, _joint);
    }

    [RPC]
    void SetCam(Vector3 _forward)
    {
       // cameraController.transform.forward = _forward;
    }

    [RPC]
    void SetGameStatus(int _gameStatus)
    {
       // GameManagerPC.SetGameStatus((GameManager.GameStatus)_gameStatus);
    }

    public void SetPCStatus(int _status)
    {
        if (Network.peerType == NetworkPeerType.Client)
        {
            GetComponent<NetworkView>().RPC("SetGameStatus", RPCMode.All, _status);
        }
        
    }

	void Update () 
    {
        if (Network.peerType == NetworkPeerType.Client)
        {
            GetComponent<NetworkView>().RPC("SetCam", RPCMode.All, cameraController.centerEyeAnchor.forward);
        }
	}
}
