using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour 
{

    public float StartingHealth = 100;
    private float currentHealth;
    public RectTransform HealthBar;
    private Vector2 healthBarBaseSize;
    private bool isDead = false;
    //private Animator ani;
    //private RotateBottomHand rotBody;

	void Start () 
    {
        currentHealth = StartingHealth;
        healthBarBaseSize = HealthBar.sizeDelta;
        //ani = GetComponent<Animator>();
        //rotBody = GetComponentInChildren<RotateBottomHand>();
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

        currentHealth -= amount;
        float _barLenth = currentHealth / StartingHealth * healthBarBaseSize.x;
        HealthBar.sizeDelta = new Vector2(_barLenth, HealthBar.sizeDelta.y);

        if (currentHealth <= 0 )
        {
            isDead = true;
            EnemyManager.EnemyNum--;
            //ani.SetTrigger("Dead");
            //rotBody.enabled = false;
            Destroy(this.gameObject);
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
