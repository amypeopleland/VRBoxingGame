using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
    public float LifeTime = 1.0f;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, LifeTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
