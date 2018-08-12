using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SandboxBeating : MonoBehaviour {
    GameObject Body;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        
	}

    //void OnTriggerEnter(Collider other)//能闯过，加载在body里面
    //{
    //    // Debug.Log("hhe");
    //    if (other.transform.tag.CompareTo("Gun") == 0)
    //    {


    //        //  Debug.Log("hhevb");

    //        var hit = other.gameObject;
    //        var health = hit.GetComponent<Health>();
    //        if (health != null)
    //        {
    //            health.TakeDamage(10);
    //        }
    //    }







    //if (other.transform.tag.CompareTo("Bullet") == 0)
    //{

    //    Destroy(other.gameObject);

    //    Debug.Log(this.gameObject.transform.GetChild(0).tag);
    //    var hit = other.gameObject;
    //    var health = hit.GetComponent<Health>();
    //    if (health != null)
    //    {
    //        health.TakeDamage(10);
    //    }


    //}

    //if (other.transform.tag.CompareTo("Gun") == 0)
    //{
    //    // Debug.Log("Gun");

    //    // Destroy(other.gameObject);

    //    Debug.Log(this.gameObject.transform.GetChild(0).tag);
    //    var hit = other.gameObject;
    //    var health = hit.GetComponent<Health>();
    //    if (health != null)
    //    {
    //        health.TakeDamage(10);
    //    }


    //}

    //}
    string _collisitonInfor = "";
    public Text _text;
    public int ii = 0;
    void OnTriggerEnter(Collider other)//能闯过，加载在body里面
    {
        if (other.gameObject.name.CompareTo("BBB")==0)
        {

           
            var hit = other.transform;
            var health = hit.GetComponent<Health>();
            if (health != null)
            {

                health.TakeDamage(10);
            }
        }

        if (other.gameObject.name.CompareTo("Assets_M_body") == 0)
        {

            var hit = other.transform;
            var health = hit.GetComponent<Health>();
            if (health != null)
            {

                health.TakeDamage(10);
            }
        }
      
        
        
        //if (other.transform.Find("Assets_M_body").gameObject!= null)
        //{
        //    Body = other.transform.Find("Assets_M_body").gameObject;
        //    var hit = Body; 
           
        //    var health = hit.GetComponent<Health>();
        //    if (health != null)
        //    {
        //        ii++;
        //        if (ii >= 2)
        //        { health.TakeDamage(10); }

        //    }
 
        //}
        //if (other.gameObject.transform.GetChild(4) != null)
        //{

        //    if (other.gameObject.transform.GetChild(4).tag.CompareTo("Body") == 0)
        //    {

        //        var hit = other.gameObject.transform.GetChild(4);
        //        var health = hit.GetComponent<Health>();
        //        if (health != null)
        //        {
        //            ii++;
        //            if (ii >= 2)
        //            { health.TakeDamage(10); }
                    
        //        }
        //    }
        //}
      
        
       

    }
    //void OnCollisionEnter(Collision other)//不能穿过,加载在玩家的手上
    //{
    //    //Destroy(other.gameObject);





    //    if (other.transform.GetChild(4).tag.CompareTo("Body") == 0)
    //    {
    //        // Debug.Log("Gun");

    //        // Destroy(other.gameObject);

    //        Debug.Log(this.gameObject.transform.GetChild(0).tag);
    //        var hit = other.transform.GetChild(4);
    //        var health = hit.GetComponent<Health>();
    //        if (health != null)
    //        {
    //            health.TakeDamage(10);
    //        }


    //    }
       
    //}
}
