using UnityEngine;
using System.Collections;

public class WoodenMove : MonoBehaviour {

    public float MinForce=20.0f;
    public float MaxForce=40.0f;

    public bool isAtWall=false;
    public float oppositeSpeed = 2;
    public float rotateSpeed=15;
    public float moveSpeed = 10;

    public Rigidbody wood_rb;
    Vector3 currentHandPosistion;


    public float moveRandomNumber;
    public float _delay = 10;
    bool isMovingLastSpeed = false;
    

    public GameObject Body;
	// Use this for initialization
	void Start () {

        moveRandomNumber = Random.Range(0, 5);
	}
	
	// Update is called once per frame
	void Update () {

        moveWoodBody(); 
        
	}
   
    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(_delay);
        moveRandomNumber = Random.Range(0, 5);
        isMovingLastSpeed = false;
    }
    void  moveWoodBody()
    {
        float force = Random.Range(MinForce, MaxForce);
       
     
        if (!isMovingLastSpeed)
        {
            isMovingLastSpeed = true;
            StartCoroutine(CountDown());
        }

        if (moveRandomNumber == 1)
        {
            wood_rb.AddForce(transform.forward * force);
            
        }

        if (moveRandomNumber == 2)
        {
            wood_rb.AddForce(transform.right * force);
        }

        if (moveRandomNumber == 3)
        {
            wood_rb.AddForce(-transform.forward * force);
        }

        if (moveRandomNumber == 4)
        {
            wood_rb.AddForce(-transform.right * force);
        }


        if (moveRandomNumber == 11)
        {
            //isMovingLastSpeed = true;
            wood_rb.AddForce(transform.forward * force * oppositeSpeed);

        }

        if (moveRandomNumber == 12)
        {
           // isMovingLastSpeed = true;
            wood_rb.AddForce(transform.right * force * oppositeSpeed);
        }

        if (moveRandomNumber == 13)
        {
            //isMovingLastSpeed = true;
            wood_rb.AddForce(-transform.forward * force * oppositeSpeed);
        }

        if (moveRandomNumber == 14)
        {
            //isMovingLastSpeed = true;
            wood_rb.AddForce(-transform.right * force * oppositeSpeed);
           // transform.Rotate(new Vector3(0, 180, 0));
        }

        if (moveRandomNumber%3==0)
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * rotateSpeed, 0));
        }
        else if (moveRandomNumber % 3 == 1)
        {
            transform.Rotate(new Vector3(0, -Time.deltaTime * rotateSpeed, 0));
        }
        else

        {
 
        }
       
 
    }

   
}
