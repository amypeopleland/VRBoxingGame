using UnityEngine;
using System.Collections;

public class LevelChange : MonoBehaviour {

    public GameObject[] level1;
    public Transform[] sandbag;
   

    private int LevelCount = 1;
    public bool LevelLoaded = false;
    public int currentSceneNumber = 1;
    public Transform SpawnPos;
	// Use this for initialization
	void Start () {
        currentSceneNumber = LevelCount;
	}
	
	// Update is called once per frame
	void Update () {
        if (LevelCount == currentSceneNumber && !LevelLoaded)
        {
           
            Vector3 FirstInstantiatePosition = sandbag[LevelCount - 1].transform.position;
            
            var SandBagRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            GameObject normalStages = (GameObject)Instantiate(level1[LevelCount - 1], SpawnPos.position, SandBagRotation);
            normalStages.name = "SandBagleve";
            LevelLoaded = true;
            normalStages.SetActive(true);

           
 
        }
        if (LevelLoaded == true)
        {
            GameObject player = GameObject.Find("/OVRCameraRig/BBB");
          
            GameObject sandBox = GameObject.Find("SandBagleve");
            GameObject sandBoxMain = GameObject.Find("/SandBagleve");
            if (player.transform.GetComponent<Health>().stateControl == 1)
            {
                 Debug.Log("youdead");                              
            }
            if (sandBox.transform.GetComponent<Health>().stateControl == 3)
            {

                Debug.Log("boxdead");
                if (currentSceneNumber < 3 || LevelCount < 3)
                {
                    LevelCount++;
                    currentSceneNumber++;
                }
                else if (LevelCount ==3)
                {
                    LevelCount++;
                    Debug.Log("gameover");
                }
               
                Destroy(sandBoxMain);
                LevelLoaded = false;
                
            }
 
        }

      
	
	}

  
}
