using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
   public  Rigidbody wood_rb;
   public int a = 10;
   public float ff = 100.0f;
   public float ffc;
	// Use this for initialization
	void Start () {

        ffc = a * ff*a;
        Debug.Log(ffc);
	}
	
	// Update is called once per frame
	void Update () {
        wood_rb.AddForce(transform.forward *61);
	}
}
