using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

    private Transform cam;
	void Start () 
    {
        cam = GameObject.FindGameObjectWithTag("OVRCamera").transform;
	}
	
	void Update () 
    {
        if (cam)
        {
            transform.LookAt(cam);
            transform.forward = -transform.forward;
        }       
	}
}
