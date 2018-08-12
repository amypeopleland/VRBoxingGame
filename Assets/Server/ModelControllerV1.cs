using UnityEngine;
using System.Collections;
using KinectServer;

public class ModelControllerV1 : MonoBehaviour {

    public ClientBodySource BS;
    public GameObject SpineBase;
    public GameObject SpineMid;
    public GameObject Neck;
    public GameObject Head;
    public GameObject ShoulderLeft;
    public GameObject ElbowLeft;
    public GameObject WristLeft;
    public GameObject HandLeft;
    public GameObject ShoulderRight;
    public GameObject ElbowRight;
    public GameObject WristRight;
    public GameObject HandRight;
    public GameObject HipLeft;
    public GameObject KneeLeft;
    public GameObject AnkleLeft;
    public GameObject FootLeft;
    public GameObject HipRight;
    public GameObject KneeRight;
    public GameObject AnkleRight;
    public GameObject FootRight;
    public GameObject SpineShoulder;
    public float MoveSpeed = 3.0f;

    private Vector3[] Player = null;
    private GameObject[] Bones;
    private Quaternion[] BaseRotation;
    private Vector3[] BoneDir;
    private Vector3 ChestRight;
    private Quaternion BodyBaseRotation;
    private Vector3 BodyBaseForward;
    private Vector3 BodyBasePos;

	void Start () 
    {
        Bones = new GameObject[21] {SpineBase, SpineMid, Neck, Head,
            ShoulderLeft, ElbowLeft, WristLeft, HandLeft,
            ShoulderRight, ElbowRight, WristRight, HandRight,
            HipLeft, KneeLeft, AnkleLeft, FootLeft,
            HipRight, KneeRight, AnkleRight, FootRight,
            SpineShoulder//, HandTipLeft, ThumbLeft, HandTipRight, ThumbRight
        };

        

        BaseRotation = new Quaternion[21];
        BoneDir = new Vector3[21];

        BodyBaseRotation = this.transform.rotation;
        BodyBaseForward = new Vector3(this.transform.forward.x, 0.0f, this.transform.forward.z);
        BodyBasePos = this.transform.position;

        BoneDir[0] = Vector3.zero;
        for (int i = 1; i < 21; i++)
        {
            BaseRotation[i] = Bones[i].transform.localRotation;

            if (i % 4 == 0)
            {
                BoneDir[i] = Vector3.zero;
            }
            else if (i == (int)JointType.Neck)
            {
                BoneDir[i] = Bones[i].transform.position - Bones[(int)JointType.SpineShoulder].transform.position;
            }
            else if (i == (int)JointType.SpineShoulder)
            {
                BoneDir[i] = Bones[i].transform.position - Bones[(int)JointType.SpineMid].transform.position;
            }
            else
            {
                BoneDir[i] = Bones[i].transform.position - Bones[i - 1].transform.position;
            }
            BoneDir[i] = Bones[i - 1].transform.InverseTransformDirection(BoneDir[i]);
        }

        ChestRight = ShoulderRight.transform.position - ShoulderLeft.transform.position;
	}
	
	
	void Update () 
    {
	    if (BS == null)
	    {
            Debug.Log("NO BodySource");
            return;
	    }

        Player = BS.GetAllJoint();
        if (Player != null)
        {
            BodyRotate();
            BodyMove();
            for (int i = 0; i < 21; i++)
            {
                RotateJoint(i);
            }           
        }             
	}

    void RotateJoint(int _bone)
    {
        Bones[_bone].transform.localRotation = BaseRotation[_bone];
        Vector3 _dir = BoneDir[_bone];
        Vector3 _target = Vector3.zero;
        

        if (_bone % 4 == 0)
        {
            if (_bone == (int)JointType.SpineShoulder)
            {
                _target = GetBone((JointType)_bone) - GetBone(JointType.SpineMid);
            }
        }

        else
        {
            _target = GetBone((JointType)_bone) - GetBone((JointType)_bone - 1);
        }
        _target = transform.TransformDirection(_target);

        if (_bone % 4 != 0)
        {
            _target = Bones[_bone - 1].transform.InverseTransformDirection(_target);
            
            if (_bone > 1)
            {
                Vector3 _bodyForward = new Vector3(this.transform.forward.x, 0.0f, this.transform.forward.z);
                _bodyForward = Bones[_bone - 1].transform.InverseTransformDirection(_bodyForward);

                Vector3 _baseForward = Bones[_bone - 1].transform.InverseTransformDirection(BodyBaseForward);

                Quaternion _offset = Quaternion.FromToRotation(_bodyForward, _baseForward);
                _target = _offset * _target;
            }
            Quaternion _quat = Quaternion.FromToRotation(_dir, _target);
           
            Bones[_bone - 1].transform.localRotation = Bones[_bone - 1].transform.localRotation * _quat;

        }            
    }

    void BodyRotate()
    {
        this.transform.rotation = BodyBaseRotation;

        Vector3 _rotateTarget;
        _rotateTarget = GetBone(JointType.HipRight) - GetBone(JointType.HipLeft);
        Quaternion _rightQuat = Quaternion.FromToRotation(Vector3.right, new Vector3(_rotateTarget.x, 0.0f, _rotateTarget.z));
        _rightQuat = Quaternion.Lerp(Quaternion.identity, _rightQuat, 1);
        this.transform.rotation *= _rightQuat;
    }

    void BodyMove()
    {
        Vector3 _move = BodyBaseRotation * GetBone(JointType.SpineBase);
        this.transform.position = BodyBasePos + new Vector3(_move.x, 0.0f, _move.z) * MoveSpeed;
    }

    private Vector3 GetBone(JointType _name)
    {
        Vector3 _pos = new Vector3((float)(Player[(int)_name].x),
                                   (float)(Player[(int)_name].y),
                                   (float)(Player[(int)_name].z * -1));
        return _pos;
    }
}
