using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BloodUI : MonoBehaviour {

    public Image bloody1;
    public RectTransform cav1;
    public Image bloody2;
    public RectTransform cav2;
    public float flashSpeed = 1.0f;
    float value;

    void Start()
    {
        bloody1.color = Color.clear;
        bloody2.color = Color.clear;
    }

    void Update()
    {
        bloody1.color = Color.Lerp(bloody1.color, Color.clear, flashSpeed * Time.deltaTime);
        bloody2.color = Color.Lerp(bloody2.color, Color.clear, flashSpeed * Time.deltaTime);
    }

    public void BloodFlash()
    {
        value = Random.Range(0, 1000);
        print(value);
        if (value > 500)
        {
            bloody1.color = Color.red;
            cav1.anchorMax = new Vector2(0, 0);
            cav1.anchorMin = new Vector2(0, 0);
            bloody1.transform.localPosition = new Vector3(Random.Range(-500, 300), Random.Range(-400, 90), 0);
            
        }
        else
        {
            bloody2.color = Color.red;
            cav2.anchorMax = new Vector2(0, 0);
            cav2.anchorMin = new Vector2(0, 0);
            bloody2.transform.localPosition = new Vector3(Random.Range(-300, 300), Random.Range(-200, 20), 0);           
        }
    }
}
