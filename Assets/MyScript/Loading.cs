using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {

    public string SceneName;
    AsyncOperation async;

	void Start () {
        StartCoroutine(LoadScene());
	}
	
	void Update () {
	
	}

    IEnumerator LoadScene()
    {
        async = Application.LoadLevelAsync(SceneName);
        yield return async;
    }
}
