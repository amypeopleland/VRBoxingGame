using UnityEngine;
using System.Collections;

public class FaceToPlayer : MonoBehaviour {

    private Transform player;
    public float RotSpeed = 5.0f;
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update () 
    {
        Vector3 _target = player.position - this.transform.position;
        _target = new Vector3(_target.x, 0.0f, _target.z);
        //this.transform.forward = _target;
        //Debug.DrawRay(this.transform.position, this.transform.forward * 50, Color.red);
        //Debug.DrawRay(this.transform.position, _target * 50, Color.blue);
        if (Vector3.Angle(_target, this.transform.forward) != 180.0f)
        {
            Quaternion _quat = Quaternion.FromToRotation(this.transform.forward, _target);
            this.transform.rotation *= Quaternion.Lerp(Quaternion.identity, _quat, Time.deltaTime * RotSpeed);
        }
        
	}
}
