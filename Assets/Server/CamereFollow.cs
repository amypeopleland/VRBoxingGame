using UnityEngine;
using System.Collections;

public class CamereFollow : MonoBehaviour {

    public Transform HeadPos;
    public Transform BodyRotate;
	void Start () 
    {
        this.transform.rotation = BodyRotate.rotation;
	}
	
	void Update () 
    {
        this.transform.position = HeadPos.position;
	}
}
