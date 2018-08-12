using UnityEngine;
using System.Collections;
using System; 


public enum KeypadButton
{
    None = -1,
    Zero = 0,
    One = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Dot = 10,
    Delte = 11,
    Connect = 12
}

public class Keypad : MonoBehaviour {

    OVRCameraRig cameraController = null;
    public GameObject IpText = null;
    public LayerMask ButtonLayer;

    private Transform activeButton = null;
    private string severIpAddress = "";

	void Start () 
    {
        cameraController = GameObject.FindGameObjectWithTag("OVRCamera").GetComponent<OVRCameraRig>();
        if (cameraController == null || IpText == null)
        {
            Debug.LogError("ERROR: Missing camera controller reference on " + name);
            enabled = false;
            return;
        }
        IPStream _ipReader = new IPStream();
        severIpAddress = _ipReader.ReadIP();
        IpText.GetComponent<TextMesh>().text = severIpAddress;
	}

	void Update () 
    {
        Ray ray = new Ray(cameraController.centerEyeAnchor.position, cameraController.centerEyeAnchor.forward);
        RaycastHit hit = new RaycastHit();
        
        Transform lastActiveButton = activeButton;
        activeButton = null;
        if (lastActiveButton != null)
        {
            lastActiveButton.GetComponent<Renderer>().material.color = Color.white;
        }
        
        if(Physics.Raycast(ray, out hit, 100.0f, ButtonLayer))
        {
            activeButton = hit.transform;
            activeButton.GetComponent<Renderer>().material.color = new Color(0.0f, 0.378f, 1.0f);
            int _ID = (int)hit.transform.GetComponent<KeyType>().ButtonID;
            if (Input.GetButtonDown("Fire1"))
            {
                if (_ID < 10)
                {
                    severIpAddress += _ID.ToString();
                }
                else if (_ID == 10)
                {
                    severIpAddress += ".";
                }
                else if (_ID == 11)
                {
                    if (severIpAddress.Length > 0)
                    {
                        severIpAddress = severIpAddress.Substring(0, severIpAddress.Length - 1);
                    }    
                }
                else if (_ID == 12)
                {
                        
                    IPStream _ipWriter = new IPStream();
                    _ipWriter.WriteIP(severIpAddress);
                    ConnectServer.ConnectToServer(severIpAddress);
                }
                IpText.GetComponent<TextMesh>().text = severIpAddress;
            }          
        }        
	}
}
