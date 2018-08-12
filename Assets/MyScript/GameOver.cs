using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    private Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.GetGameStatus() == GameManager.GameStatus.GameOver)
        {
            ani.SetBool("Over", true);
        }
        else
        {
            ani.SetBool("Over", false);
        }
    }
}
