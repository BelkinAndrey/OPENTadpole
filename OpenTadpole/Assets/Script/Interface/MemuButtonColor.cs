using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class MemuButtonColor : MonoBehaviour {

    public UnityEvent ButtonEnable = new UnityEvent();

    private bool EnableButton = false;

    void OnEnable() 
    {
        OffSelectColor();
    }

    void OnDisable() 
    {
       if (EnableButton) ButtonEnable.Invoke();
    }

    public void SelectColor() 
    {
        gameObject.GetComponent<Image>().color = new Color32(225, 225, 195, 150);
        EnableButton = true;
    }

    public void OffSelectColor() 
    {
        gameObject.GetComponent<Image>().color = new Color32(255, 255, 195, 60);
        EnableButton = false;
    }
}
