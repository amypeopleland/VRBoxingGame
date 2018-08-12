using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

    static int CurrentScene = -1;
    public GameObject[] Scene;
    public GameObject[] Skybox;
    public AudioClip[] BGM;
    private AudioSource audio;

    void Start() 
    {
        audio = GetComponent<AudioSource>();
	}
	
	void Update () 
    {
	    
	}

    public void Load(int _n)
    {
        if (CurrentScene != _n && _n < Scene.Length && _n >= 0)
        {
            if (CurrentScene != -1)
            {
                Scene[CurrentScene].SetActive(false);
                Skybox[CurrentScene].SetActive(false);
            }
            Scene[_n].SetActive(true);
            Skybox[_n].SetActive(true);
            audio.clip = BGM[_n];
            audio.Play();
            CurrentScene = _n;
        }
        
    }
}
