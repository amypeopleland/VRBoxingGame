using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

     public GameObject bulletPrefab;
    public Transform bulletSpawn;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 30.0f;
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
        
	}

    void CmdFire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 26;

        Destroy(bullet, 3f);
    }
}
