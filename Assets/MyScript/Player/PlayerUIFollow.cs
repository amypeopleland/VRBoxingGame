using UnityEngine;
using System.Collections;

public class PlayerUIFollow : MonoBehaviour
{

    public OVRCameraRig cameraController = null;
    public float crosshairDepth = 3.0f;
    // Use this for initialization
    void Start()
    {
        if (cameraController == null)
        {
            Debug.LogError("ERROR: Missing camera controller reference on " + name);
            enabled = false;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = cameraController.centerEyeAnchor.position;
        Vector3 cameraForward = cameraController.centerEyeAnchor.forward;

        transform.position = cameraPosition + (cameraForward * crosshairDepth);
        transform.forward = cameraForward;
    }
}
