using UnityEngine;
using System.Collections;

public class MoveHand : MonoBehaviour
{

    public Vector3 TargetPos;
    public Vector3 StartPos;
    public Vector3 CurrentPos;
    public float Duration = 1;
    public int flag_push=0;
    public float minWait=5.0f, maxWait=6.0f;

    public bool waitFor;
    public int change = 0;
    // Use this for initialization
    void Start()
    {
        StartPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentPos = transform.localPosition;

        float r = Mathf.Sin(1.5f * Mathf.PI / Duration * Time.time);
        if (r < 0)
        {
            if (change == 0)
            {

                change = 1;
            }
           
            r = -r;
            flag_push++;
            
        }
        if (r > 0 && change == 1)
        {
            change = 2;
        }
        
       
        
        
    
        if (change!=2 && change==0)
        {

            transform.localPosition = Vector3.Lerp(StartPos, TargetPos, r);//how to detect 1 period 
        }

        if (!waitFor)
        {
            StartCoroutine(wait());
            waitFor = true;
            change = 0;
            
        }
    }
    IEnumerator wait()
    {

       // Debug.Log("33");
       
    //    Debug.Log(change);
        yield return new WaitForSeconds(Random.Range(minWait, maxWait));
        waitFor = false;
    }
}
