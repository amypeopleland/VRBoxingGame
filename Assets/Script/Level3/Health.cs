using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public RectTransform healthBar;

    public  int stateControl=0;

    public bool dead = false;

   //0-boxfull,1-boxdie,2-playerfull,3-playerdie

    public void TakeDamage(int amount)
    {
        if (dead == false)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                
                if (this.gameObject.name.CompareTo("BBB") == 0)
                {
                   
                    stateControl = 1;
                 //   Debug.Log(stateControl);
                    dead = true;
                }
                else
                {

                    stateControl = 3;
                   // Debug.Log(stateControl);
                    dead = true;
                }
            }

            healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
 
        }
       
    }
}
