using UnityEngine;
using System.Collections;

public class RotateBottomHand : MonoBehaviour {
    public float rotationAmount = 100;

    public bool reverseRotate=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per framek
	void Update () {
        if (reverseRotate == false)
        {
           
            transform.Rotate(0, rotationAmount * Time.deltaTime, 0);
            
        }
        else if (reverseRotate==true)
        {
           
            transform.Rotate(0, -rotationAmount*10 * Time.deltaTime, 0);
        }

	}
   

   
}
