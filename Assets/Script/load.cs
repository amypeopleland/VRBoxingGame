using UnityEngine;
using System.Collections;

public class load : MonoBehaviour {
    public GameObject wood;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        Destroy(wood);
        float i = -3;
        Instantiate(wood, new Vector3(14, 8, i), Quaternion.identity);
        i--;
        print("Success Point!");
    }
}
