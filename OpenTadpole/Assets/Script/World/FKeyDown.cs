using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FKeyDown : MonoBehaviour {

    public KeyCode code;
	void Update () {

        if (Input.GetKey(code)) 
        {
            GetComponent<Text>().color = new Color32(255, 255, 0, 255);
        }
        else GetComponent<Text>().color = new Color32(255, 255, 255, 255);
	}
}
