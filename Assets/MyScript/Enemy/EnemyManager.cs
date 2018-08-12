using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public GameObject[] Enemy;
    public Transform SpawnPos;

    public static int EnemyNum = 0;

    GameObject sandbag = null;
	void Start () 
    {
	    
	}
	
	void Update () 
    {
	    
	}

    public void SpawnEnemy(int _n)
    {
        if (_n > Enemy.Length - 1)
        {
            return;
        }
        GameObject _sandbag = (GameObject)Instantiate(Enemy[_n], SpawnPos.position, Quaternion.identity);
        sandbag = _sandbag;
        EnemyNum++;
    }

    public void DestoryEnemy()
    {
        Destroy(sandbag);
        sandbag = null;
        EnemyNum--;
    }
}
