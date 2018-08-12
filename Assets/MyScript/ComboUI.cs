using UnityEngine;
using System.Collections;

public class ComboUI : MonoBehaviour {

    private TextMesh tex;
    private static GameObject lastHit;
	void Start () 
    {
        if (lastHit != null)
        {
            GameObject.Destroy(lastHit);
        }
        tex = GetComponent<TextMesh>();

        int _comboNum = HitCombo.GetComboNum();
        tex.text = _comboNum.ToString();
        lastHit = this.gameObject;
	}
	
	void Update () 
    {

	}
}
