using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputLassoColor : MonoBehaviour {

    void OnMouseEnter()
    {
        GetComponent<Image>().color = new Color32(255, 0, 0, 130);
    }

    void OnMouseExit()
    {
        GetComponent<Image>().color = new Color32(255, 255, 255, 130);
    }
}
