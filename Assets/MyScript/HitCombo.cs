using UnityEngine;
using System.Collections;

public class HitCombo : MonoBehaviour {

    public float ComboTime = 0.5f;

    static private int comboNum = 0;
    private float timer = 0.0f;
    private int comboScoreRate = 1;
	void Start () 
    {
	
	}
	
	void Update () 
    {
        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            ComboCancle();
        }
	}

    public void Combo()
    {
        comboNum++;
        timer = ComboTime;
        ScoreRate();
        ScoreManager.score += 10 * comboScoreRate;
    }

    public void ComboCancle()
    {
        comboNum = 0;
        comboScoreRate = 1;
    }

    public static int GetComboNum()
    {
        return comboNum;
    }

    private void ScoreRate()
    {
        switch (comboNum)
        {
            case 3:
                comboScoreRate = 2;
                break;
            case 7:
                comboScoreRate = 3;
                break;
            case 12:
                comboScoreRate = 4;
                break;
            case 18:
                comboScoreRate = 5;
                break;
            default:
                break;
        }
    }

    public int GetScoreRate()
    {
        return comboScoreRate;
    }
}
