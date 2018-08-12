using UnityEngine;
using System.Collections;

public class ReverseHand : MonoBehaviour {

    public bool getReverse;
	// Use this for initialization
	void Start () {
	
	}
    public float delay=2;
    IEnumerator coutDown()
    {
        trigger = true;
        yield return new WaitForSeconds(delay);
    }
	// Update is called once per frame
	void Update () {
	
	}
    bool trigger = false;
    void OnTriggerEnter(Collider other)//能闯过，加载在body里面
    {
        if (other.gameObject.name.CompareTo("BBB") == 0)
        {



            if (this.gameObject.transform.parent.GetComponent<RotateBottomHand>().reverseRotate == false && !trigger)
            {

                StartCoroutine(coutDown());
                this.gameObject.transform.parent.GetComponent<RotateBottomHand>().reverseRotate = true;
                trigger = false;
            }
            else if (this.gameObject.transform.parent.GetComponent<RotateBottomHand>().reverseRotate == true && !trigger)
            {
                StartCoroutine(coutDown());
                this.gameObject.transform.parent.GetComponent<RotateBottomHand>().reverseRotate = false;
                trigger = false;
            }



        }


    }


  
}
