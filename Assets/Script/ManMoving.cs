using UnityEngine;
using System.Collections;

public class ManMoving : MonoBehaviour
{


    public float MinForce = 20.0f;
    public float MaxForce = 40.0f;

    public bool isAtWall = false;
    public float oppositeSpeed = 2.0f;
    public float rotateSpeed = 15;
    public float moveSpeed = 10;

    public Rigidbody wood_rb;
    Vector3 currentHandPosistion;


    public float moveRandomNumber;
    public float _delay = 5;
    bool isMovingLastSpeed = false;

    public float force;
    public float forceChange;

    public Vector3 currentPos;
    public Vector3 CentralPos;

    public GameObject Body;

    public static bool collisionOnTheWall=false;
    // Use this for initialization
    void Start()
    {
         
         
    }

    // Update is called once per frame
    void Update()
    {

        moveWoodBody();
      //  StartCoroutine(waitFor());
       // wood_rb.AddForce(transform.forward * forceChange);
    }

    IEnumerator changeMovingNumber()
    {
      
       
        yield return new WaitForSeconds(Random.Range(0, 5));
        moveRandomNumber = Random.Range(0, 8);
        force = Random.Range(MinForce, MaxForce);


        
        
       
        isMovingLastSpeed = false;
    }

    void moveWoodBody()
    {
        float force = Random.Range(MinForce, MaxForce);

        if (moveRandomNumber <= 10)
        {
            wood_rb.drag = 10;
        }
        if (!isMovingLastSpeed)
        {
            isMovingLastSpeed = true;

            StartCoroutine(changeMovingNumber());
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

        if (moveRandomNumber >= 10)
        {
            currentPos = transform.position;
            transform.position = Vector3.Lerp(currentPos, CentralPos, Time.deltaTime/10);
        }

        //if (moveRandomNumber == 11)
        //{
           
        //    float forceChange = force * oppositeSpeed;
        //    wood_rb.AddForce(transform.forward * forceChange);

        //}

        //if (moveRandomNumber == 12)
        //{
           
        //    wood_rb.AddForce(transform.right * force * oppositeSpeed);
        //}

        //if (moveRandomNumber == 13)
        //{
            
        //    wood_rb.AddForce(-transform.forward * force * oppositeSpeed);
        //}

        //if (moveRandomNumber == 14)
        //{
           
        //    wood_rb.AddForce(-transform.right * force * oppositeSpeed);
        //    // transform.Rotate(new Vector3(0, 180, 0));
        //}

        if (moveRandomNumber % 3 == 0)
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

    void OnTriggerEnter(Collider other)
    {
        wood_rb.drag = 20;
       // collisionOnTheWall = true;

        if (other.transform.name.CompareTo("FrontWall") == 0)
        {
            Debug.Log(other.transform.tag);
            moveRandomNumber = 11;
            isAtWall = true;


        }
        if (other.transform.name.CompareTo("LeftWall") == 0)
        {
            Debug.Log(other.transform.tag);
            moveRandomNumber = 12;
            isAtWall = true;


        }
        if (other.transform.name.CompareTo("RightWall") == 0)
        {
            Debug.Log(other.transform.tag);
            moveRandomNumber = 14;
            isAtWall = true;

        }
        if (other.transform.name.CompareTo("frontInWall") == 0)
        {
            Debug.Log(other.transform.tag);
            moveRandomNumber = 13;
            isAtWall = true;

        }
        
    }
  


}
