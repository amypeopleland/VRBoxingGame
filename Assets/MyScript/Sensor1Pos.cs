using UnityEngine;
using System.Collections;

public class Sensor1Pos : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
