using UnityEngine;
using System.Collections;

public class playerHandController : MonoBehaviour {

    public Vector3 useAmount;
    public Quaternion originalLocalRotation;
    // Use this for initialization
    void Start()
    {
        originalLocalRotation = transform.localRotation;
        useAmount.y = 43.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("k"))
        {
            transform.localRotation = originalLocalRotation * Quaternion.Euler(useAmount);
            //  rigidbody.AddTorque(transform.left * turnspeed * Input.GetAxis("Horizontal"));


        }
        if (Input.GetKeyUp("k"))
        {
            transform.localRotation = originalLocalRotation;
        }
        else if (Input.GetKey("l"))
        {
            transform.localRotation = originalLocalRotation * Quaternion.Euler(-useAmount);
        }
        if (Input.GetKeyUp("l"))
        {
            transform.localRotation = originalLocalRotation;
        }
    }



    //public float torque;
    //public Rigidbody rb;
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}
    //void FixedUpdate()
    //{
    //    float turn = Input.GetAxis("Horizontal");
    //    Debug.Log(turn);
    //    rb.AddTorque(transform.up * torque * turn);
    //}
}
