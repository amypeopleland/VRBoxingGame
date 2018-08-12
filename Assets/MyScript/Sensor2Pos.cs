using UnityEngine;
using System.Collections;

public class Sensor2Pos : MonoBehaviour {

    public ClientBodySource BS;
    public ModelControllerV2 MC;
    private TextMesh tex;
	// Use this for initialization
	void Start () {
        tex = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        if (BS.GetCurrentKinect() == 1)
        {
            this.transform.position = BS.GetKinect2Pos() * MC.MoveSpeed;
            tex.text = "Sensor2";
        }
        else
        {
            tex.text = "";
        }
	}
}
