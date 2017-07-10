using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuldScript : MonoBehaviour {

    public Sprite BOff;
    public Sprite BOn;

    public SpriteRenderer bec;

    public bool OnOff = false;

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.F5)) 
        {
            if (gameObject.GetComponent<Image>()) 
            {
                OnOff = !OnOff;
                bec.enabled = OnOff;
                if (OnOff) gameObject.GetComponent<Image>().sprite = BOn;
                else gameObject.GetComponent<Image>().sprite = BOff;
            }
        }
    }
}
