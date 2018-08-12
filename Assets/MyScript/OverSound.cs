using UnityEngine;
using System.Collections;

public class OverSound : MonoBehaviour {

    public AudioClip Win;
    public AudioClip Lose;
    private AudioSource audio;
    private bool isPlaying = false;
	void Start () 
    {
        audio = GetComponent<AudioSource>();
	}
	
	void Update () 
    {
	    if (GameManager.GetGameStatus() == GameManager.GameStatus.Win)
	    {
            if (!isPlaying)
            {
                audio.clip = Win;
                audio.Play();
                isPlaying = true;
            }
            
	    }
        else if (GameManager.GetGameStatus() == GameManager.GameStatus.GameOver)
        {
            if (!isPlaying)
            {
                audio.clip = Lose;
                audio.Play();
                isPlaying = true;
            }           
        }
        else
        {
            isPlaying = false;
        }
	}
}
