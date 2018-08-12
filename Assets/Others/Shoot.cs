using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ff");
        Destroy(other.gameObject);
    }
}
