using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public GameObject HitEffect;
    public AudioClip HitClip;
    public float HandSpeed;
    public HitCombo ComboSystem;
    public GameObject ComboText;
    public float AttackCD = 0.2f;
    private AudioSource audio;
    private Rigidbody rigidbody;
    private float timer = 0.0f;
    private Vector3 lastPos;
    private float speed;
	void Start () 
    {
        audio = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
        lastPos = this.transform.position;
	}
	
	void Update () 
    {
        speed = Vector3.Distance(lastPos, this.transform.position) / Time.deltaTime;
        lastPos = this.transform.position;
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Enemy") == true && GameManager.GetGameStatus() == GameManager.GameStatus.Playing && speed > HandSpeed && timer <= 0)
        {
            other.transform.GetComponentInParent<EnemyHealth>().TakeDamage(10);
            audio.clip = HitClip;
            audio.Play();
            GameObject _effect = (GameObject)Instantiate(HitEffect, other.contacts[0].point, Quaternion.identity);
            ComboSystem.Combo();
            if(HitCombo.GetComboNum() > 1)
            {
                GameObject _combo = (GameObject)Instantiate(ComboText, other.contacts[0].point, Quaternion.identity);
            }
            timer = AttackCD;
        }
    }
}
