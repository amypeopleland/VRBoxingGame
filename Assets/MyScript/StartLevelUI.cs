using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartLevelUI : MonoBehaviour {

    public GameManager GM;
    private Animator ani;
    private Text tex;

	void Start () 
    {
        ani = GetComponent<Animator>();
        tex = GetComponent<Text>();
	}
	
	void Update () 
    {
        if (GameManager.GetGameStatus() == GameManager.GameStatus.LevelStart)
        {
            tex.text = ("Round" + GM.GetCurrentLevel());
            ani.SetBool("Start", true);
        }
        else
        {
            ani.SetBool("Start", false);       
        }
	}
}
