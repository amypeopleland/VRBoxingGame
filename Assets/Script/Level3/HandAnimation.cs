using UnityEngine;
using System.Collections;

public class HandAnimation : MonoBehaviour {

    public float waiteNumber=5;
    public int animteNumber=3;
    public bool playAnimate=true;
    public float waitMin=2.0f, waitMax=4.0f;
    public bool left;
    public Animation anim;
    public int minAnimationRange, maxAnimationRange;
	// Use this for initialization
	void Start () {
        minAnimationRange = 1;
        maxAnimationRange = 4;
        anim = GetComponent<Animation>();

       
	}

    public bool playLeft=false;
    
	// Update is called once per frame
	void Update () {

        if (NavigateController.playBeatingAnimation == true)
        {
            if (playAnimate)
            {

                StartCoroutine(animateControl());

            }

            if (animteNumber == 1)
            {
                this.GetComponent<Animation>().Play("Arm_ani");

            }
            else if (animteNumber == 2)
            {
                this.GetComponent<Animation>().Play("Arm_ani_left");
                //anim.PlayQueued("shoot", QueueMode.PlayNow);

            }
            else if (animteNumber == 3)
            {

                if (!playLeft)
                {
                    //   Debug.Log("88");
                    // anim["Arm_ani_left"].wrapMode = WrapMode.Once;
                    anim.Play("Arm_ani_left");
                    playLeft = true;
                }

                if (anim["Arm_ani_left"].time * 2 > anim["Arm_ani_left"].length)
                {
                    //    Debug.Log("8");
                    anim.Stop("Arm_ani_left");
                    // anim["Arm_ani"].wrapMode = WrapMode.Once;
                    anim.Play("Arm_ani");

                }
                if (anim["Arm_ani"].time * 2 >= anim["Arm_ani"].length)
                {
                    anim.Stop("Arm_ani");
                    playLeft = false;

                }

            }

            else
            {
                // this.GetComponent<Animation>().Stop("Arm_ani_left");
                //this.GetComponent<Animation>().Stop("Arm_ani");
            }
            playAnimate = false;
 
        }

        


      
	}
   

    IEnumerator animateControl()
    {
        

        
        waiteNumber = Random.Range(waitMin, waitMax);
        //yield return new WaitForSeconds(waiteNumber);
        animteNumber = Random.Range(minAnimationRange, maxAnimationRange);
        if (animteNumber > 3)
        {
            yield return new WaitForSeconds(waiteNumber);
        }
        else 
        {
            yield return new WaitForSeconds(1);
        }
      
        playAnimate = true;
    }
}
