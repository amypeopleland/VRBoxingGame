using UnityEngine;
using System.Collections;


public class ClientBodySource : MonoBehaviour {

    //public TextMesh KinectMark;
    private OVRCameraRig Cam = null;

    private Transform Player;
    private Vector3 PlayerRawPos;
    private Quaternion PlayerRawRot;
    private Vector3 PlayerRawForward;
    private Vector3 Kinect2Pos;

    private Vector3[][] RawJoint = null;
    private Vector3[] Joint = null;


    void Awake()
    {
        RawJoint = new Vector3[2][];
        Cam = GameObject.FindGameObjectWithTag("OVRCamera").GetComponent<OVRCameraRig>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerRawPos = Player.position;
        PlayerRawRot = Player.rotation;
        PlayerRawForward = Player.forward;
        Kinect2Pos = Vector3.zero;
    }

    void Update()
    {
        KinectSelect();
        //Debug.Log(PlayerRawPos.x.ToString());
    }

    public void SetRawJoint(int _i, Vector3[] _joint)
    {
        RawJoint[_i] = _joint;
    }


    public Vector3 GetRawJoint(int _i, int _name)
    {
        return RawJoint[_i][_name];
    }

    public Vector3[] GetAllRawJoint(int _i)
    {
        return RawJoint[_i];
    }

    public Vector3 GetJoint(int _name)
    {
        return Joint[_name];
    }

    public Vector3[] GetAllJoint()
    {
        return Joint;
    }

    int LastKinect = 0;
    int CurrentKinect = 0;

    private void KinectSelect()
    {
             
        if (RawJoint[1] == null || (RawJoint[1] != null && RawJoint[1][0].x == 0))
        {
            Joint = RawJoint[0];
            //KinectMark.text = "0";
        }
        else
        {
            Vector3 cameraForward = Cam.centerEyeAnchor.forward;   
            float _dot = Vector3.Dot(cameraForward, PlayerRawForward);

            LastKinect = CurrentKinect;
            if (_dot >= 0)
            {
                //Player.position = PlayerRawPos;
                //Player.rotation = PlayerRawRot;

                Joint = RawJoint[0];
                //KinectMark.text = "1";
                CurrentKinect = 0;
            }
            else
            {
                //Vector3 _kinect1HeadPos = new Vector3(RawJoint[0][0].x, 0.0f, -RawJoint[0][0].z);
                //Vector3 _kinect2HeadPos = new Vector3(RawJoint[1][0].x, 0.0f, -RawJoint[1][0].z);
                //Player.position = PlayerRawPos + _kinect1HeadPos + _kinect2HeadPos;

                //if (Player.rotation.y == PlayerRawRot.y)
                //{
                //    Player.Rotate(0.0f, 180.0f, 0.0f);
                //}
                if(LastKinect == 0)
                {
                    Kinect2Pos = new Vector3(RawJoint[0][3].x + RawJoint[1][3].x, RawJoint[0][3].y - RawJoint[1][3].y, RawJoint[0][3].z + RawJoint[1][3].z);
                }

                for (int i = 0; i < 20; i++)
                {
                    Joint[i] = new Vector3(Kinect2Pos.x - RawJoint[1][i].x, Kinect2Pos.y + RawJoint[1][i].y, Kinect2Pos.z - RawJoint[1][i].z);
                }

                //KinectMark.text = "2";
                CurrentKinect = 1;
            }
            
        }
    }

    public Vector3 GetKinect2Pos()
    {
        return Kinect2Pos;
    }

    public int GetCurrentKinect()
    {
        return CurrentKinect;
    }

    public bool IsTracking()
    {
        if (Joint == null)
        {
            return false;
        }
        return true;
    }
}
