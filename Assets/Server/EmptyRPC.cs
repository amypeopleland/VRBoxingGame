using UnityEngine;
using System.Collections;

public class EmptyRPC : MonoBehaviour {

    [RPC]
    void GetAllJoint(Vector3[] _joint, NetworkMessageInfo info)
    {
        
    }

    [RPC]
    void GetAllJoint2(Vector3[] _joint, NetworkMessageInfo info)
    {
        
    }

    [RPC]
    void SetCam(Vector3 _forward)
    {
        
    }
}
