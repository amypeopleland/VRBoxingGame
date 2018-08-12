using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    private Animator ani;

    private Text tex;
	void Start () 
    {
        tex = GetComponent<Text>();
        ani = GetComponent<Animator>();
	}
	
	void Update () 
    {
        tex.text = score.ToString();
        if (GameManager.GetGameStatus() == GameManager.GameStatus.GameOver || GameManager.GetGameStatus() == GameManager.GameStatus.Win)
        {
            ani.SetBool("Over", true);
        }
        else
        {   
            ani.SetBool("Over", false);
        }
	}
}
