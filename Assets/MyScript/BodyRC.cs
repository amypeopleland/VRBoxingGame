using UnityEngine;
using System.Collections;

public class BodyRC : MonoBehaviour {

    private ClientBodySource BS;
	void Start () 
    {
        BS = GetComponent<ClientBodySource>();
	}
	

	void Update () 
    {
	
	}

    public bool RaiseHand()
    {
        if (BS.IsTracking() && (BS.GetJoint(7).y > BS.GetJoint(3).y || BS.GetJoint(11).y > BS.GetJoint(3).y))
        {
            return true;
        }
        return false;
    }
}
