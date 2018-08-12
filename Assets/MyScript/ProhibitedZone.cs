using UnityEngine;
using System.Collections;

public class ProhibitedZone : MonoBehaviour
{
    public static bool inZone = true;

    public Transform LeftFist;
    public Transform RightFist;
    public Transform EnemyPos;
    public float ZoneRadius;
    private MeshRenderer render;
    private Animator ani;
    private Collider collider;
    

	void Start () 
    {
        this.transform.position = EnemyPos.position;
        render = GetComponentInChildren<MeshRenderer>();
        ani = GetComponentInChildren<Animator>();
	}
	
	void Update () 
    {
        if (GameManager.GetGameStatus() == GameManager.GameStatus.EnemyDead)
        {
            Debug.DrawRay(EnemyPos.position, EnemyPos.forward * ZoneRadius, Color.red);

            Vector3 _EnemyPos = new Vector3(EnemyPos.position.x, 0.0f, EnemyPos.position.z);

            Vector3 _leftPos = new Vector3(LeftFist.position.x, 0.0f, LeftFist.position.z);
            float _leftDis = Vector3.Distance(_EnemyPos, _leftPos);
            Vector3 _rightPos = new Vector3(RightFist.position.x, 0.0f, RightFist.position.z);
            float _rightDis = Vector3.Distance(_EnemyPos, _rightPos);

            inZone = true;
            if (_leftDis > ZoneRadius && _rightDis > ZoneRadius)
            {
                inZone = false;
            }
            render.enabled = true;
            ani.enabled = true;
        }
        else
        {
            render.enabled = false;
            ani.enabled = false;
        }
	}
}
