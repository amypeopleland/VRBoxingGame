using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float StartingHealth = 100;
    private float currentHealth;

    public RectTransform HealthBar;
    private Vector2 healthBarBaseSize;

    public BloodUI Blood;
    public float flashSpeed = 5;
    public AudioClip damageClip;
    public HitCombo ComboSystem;

    private AudioSource audio;
    private bool isDead = false;
    private bool damaged = false;

	void Start () 
    {
        currentHealth = StartingHealth;
        healthBarBaseSize = HealthBar.sizeDelta;
        audio = GetComponent<AudioSource>();
	}
	
	void Update () 
    {

	}

    public void TakeDamage(float amount)
    {
        if (isDead)
        {
            return;
        }

        Blood.BloodFlash();
        currentHealth -= amount;
        float _barLenth = currentHealth / StartingHealth * healthBarBaseSize.x;
        HealthBar.sizeDelta = new Vector2(_barLenth, HealthBar.sizeDelta.y);
        audio.clip = damageClip;
        audio.Play();
        ComboSystem.ComboCancle();

        if (currentHealth <= 0)
        {
            isDead = true;
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void RestoreHealth()
    {
        isDead = false;
        currentHealth = StartingHealth;
        HealthBar.sizeDelta = healthBarBaseSize;
    }
}
