using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
       // Debug.Log("hhe");
        if (other.transform.tag.CompareTo("Body") == 0)
        {
            Debug.Log("aaa");


            Destroy(gameObject);
            Debug.Log("hhe");

            var hit = other.gameObject;
            var health = hit.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(10);
            }
        }
       
       
    }
    void OnCollisionEnter(Collision other)
    {

       // Debug.Log(other.transform.GetChild(4).transform.tag);
       
    }
}
