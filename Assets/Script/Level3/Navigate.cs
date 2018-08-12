using UnityEngine;
using System.Collections;

public class Navigate : MonoBehaviour {

    public Transform target;
    NavMeshAgent agent;

    public bool waitToTheCenter = false;
    public float distance;
    public GameObject player;

    static bool playBeatingAnimation = false;

	// Use this for initialization
	void Start () {

        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 30)
        {
            playBeatingAnimation = true;
        }
        else 
        {
            playBeatingAnimation = false;
        }
        //Debug.Log(distance);
       // var flag=this.GetComponent<ManMoving>();
        if (ManMoving.collisionOnTheWall == true)
        {
            if (!waitToTheCenter)
            {
                StartCoroutine(waitForBack());
                waitToTheCenter = true;

            }
           

        }
        else 
        {
            agent.SetDestination(target.position);
           // Debug.Log("ggfffg");
        }
        
	}

    IEnumerator waitForBack()
    {

       
        yield return new WaitForSeconds(5);
        waitToTheCenter = false;
        ManMoving.collisionOnTheWall = false;
        
        

    }
}
