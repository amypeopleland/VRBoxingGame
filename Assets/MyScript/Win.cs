using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

    public GameManager GM;
    private Animator ani;

	void Start () 
    {
        ani = GetComponent<Animator>();
	}
	
	void Update () 
    {
        if (GameManager.GetGameStatus() == GameManager.GameStatus.Win)
        {
            ani.SetBool("Over", true);
        }
        else
        {
            ani.SetBool("Over", false);
        }
	}
}
