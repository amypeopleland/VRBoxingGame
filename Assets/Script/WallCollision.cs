using UnityEngine;
using System.Collections;

public class WallCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    public bool isAtWall = false;
    public Rigidbody wood_rb;
    public float daaa;
    public float flag=0;

    public bool MovingLastSpeed=false;
    public float _WaitAtWall = 5.0f;
    
	// Update is called once per frame
	void Update () {
       
        
        if (isAtWall == true)
        {
            wood_rb.drag =20;
           
            if (!MovingLastSpeed)
            {
                Debug.Log("prepare to wait");
                
                StartCoroutine(WaitAtWall());
                MovingLastSpeed = true;
            }


            
            
        }
        if (wood_rb.drag == 20 && isAtWall == false)
        {
            wood_rb.drag = 10.0f;

        }

        daaa = wood_rb.drag;
	}

   
    IEnumerator WaitAtWall()
    {
        yield return new WaitForSeconds(_WaitAtWall);
        isAtWall = false;
        MovingLastSpeed = false;


    }
    
    void OnTriggerEnter(Collider other)
    {
        WoodenMove wd = transform.GetComponent<WoodenMove>();
  
        if (other.transform.tag.CompareTo("FrontWall") == 0)
        {
            Debug.Log(other.transform.tag);
            wd.moveRandomNumber = 11;
            isAtWall = true;
            flag = 1;
        }
        if (other.transform.tag.CompareTo("LeftWall") == 0)
        {
            Debug.Log(other.transform.tag);
            wd.moveRandomNumber = 12;
            isAtWall = true;
            flag = 1;
        }
        if (other.transform.tag.CompareTo("RightWall") == 0)
        {
            Debug.Log(other.transform.tag);
            wd.moveRandomNumber = 14;
            isAtWall = true;
            flag = 1;
        }
        if (other.transform.tag.CompareTo("frontInWall") == 0)
        {
            Debug.Log(other.transform.tag);
            wd.moveRandomNumber = 13;
            isAtWall = true;
            flag = 1;
        }
    }


    
}
