using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    private AudioSource hitAudio;
    public float AttackCD = 0.4f;
    private float timer = 0.0f;

	void Start () 
    {
        hitAudio = GetComponent<AudioSource>();
	}
	
	void Update () 
    {
        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") == true && GameManager.GetGameStatus() == GameManager.GameStatus.Playing && timer <= 0)
        {
            timer = AttackCD;
            other.transform.GetComponentInParent<PlayerHealth>().TakeDamage(30);
            //hitAudio.Play();
            //GameObject _effect = (GameObject)Instantiate(HitEffect, other.contacts[0].point, Quaternion.identity);
        }
    }
}
