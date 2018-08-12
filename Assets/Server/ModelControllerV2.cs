using UnityEngine;
using System.Collections;
using KinectServer;

public class ModelControllerV2 : MonoBehaviour
{

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
    //public GameObject SpineShoulder;
    public float MoveSpeed = 3.0f;

    private Vector3[] Player = null;
    private GameObject[] Bones;
    private Quaternion[] BaseRotation;
    private Vector3[] BoneDir;
    private Vector3 ChestRight;
    private Quaternion BodyBaseRotation;
    private Vector3 BodyBaseForward;
    private Vector3 BodyBasePos;

    private ArrayList BodyMask;
    void Start()
    {
        Bones = new GameObject[20] {SpineBase, SpineMid, Neck, Head,
            ShoulderLeft, ElbowLeft, WristLeft, HandLeft,
            ShoulderRight, ElbowRight, WristRight, HandRight,
            HipLeft, KneeLeft, AnkleLeft, FootLeft,
            HipRight, KneeRight, AnkleRight, FootRight,
            //SpineShoulder//, HandTipLeft, ThumbLeft, HandTipRight, ThumbRight
        };

        

        BodyBaseRotation = this.transform.rotation;
        BodyBaseForward = new Vector3(this.transform.forward.x, 0.0f, this.transform.forward.z);
        BodyBasePos = this.transform.position;

        BodyMask = new ArrayList();
        for (int i = 0; i < 20; i++ )
        {
            if (Bones[i] != null)
            {
                if (i % 4 == 0)
                {
                    BodyMask.Add(i); 
                }
                else if (Bones[i - 1] != null)
                {
                    BodyMask.Add(i);
                }
            }
        }
        

        BaseRotation = new Quaternion[BodyMask.Count];
        BoneDir = new Vector3[BodyMask.Count];


        for (int i = 0; i < BodyMask.Count; i++)
        {
            int _boneNum = (int)BodyMask[i];

            BaseRotation[i] = Bones[_boneNum].transform.localRotation;

            if (_boneNum % 4 == 0)
            {
                BoneDir[i] = Vector3.zero;
            }
            else
            {
                BoneDir[i] = Bones[_boneNum].transform.position - Bones[_boneNum - 1].transform.position;
                BoneDir[i] = Bones[_boneNum - 1].transform.InverseTransformDirection(BoneDir[i]);
            }
            
        }

        //ChestRight = ShoulderRight.transform.position - ShoulderLeft.transform.position;
    }


    void Update()
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
            for (int i = 0; i < BodyMask.Count; i++)
            {
                RotateJoint(i);
            }
        }
    }

    void RotateJoint(int _bone)
    {
        int _boneNum = (int)BodyMask[_bone];

        Bones[_boneNum].transform.localRotation = BaseRotation[_bone];
        Vector3 _dir = BoneDir[_bone];
        Vector3 _target = Vector3.zero;

        if (_boneNum % 4 == 0)
        { 

        }

        else
        {
            _target = GetBone((JointType)_boneNum) - GetBone((JointType)_boneNum - 1);
        }

        _target = transform.TransformDirection(_target);

        if (_boneNum % 4 != 0)
        {
            _target = Bones[_boneNum - 1].transform.InverseTransformDirection(_target);

            if (_boneNum > 1)
            {
                Vector3 _bodyForward = new Vector3(this.transform.forward.x, 0.0f, this.transform.forward.z);
                _bodyForward = Bones[_boneNum - 1].transform.InverseTransformDirection(_bodyForward);

                Vector3 _baseForward = Bones[_boneNum - 1].transform.InverseTransformDirection(BodyBaseForward);

                Quaternion _offset = Quaternion.FromToRotation(_bodyForward, _baseForward);
                _target = _offset * _target;
            }
            Quaternion _quat = Quaternion.FromToRotation(_dir, _target);

            Bones[_boneNum - 1].transform.localRotation *= _quat;

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
