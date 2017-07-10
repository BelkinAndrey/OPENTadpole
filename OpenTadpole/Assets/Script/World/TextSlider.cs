using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextSlider : MonoBehaviour {

    public Slider s;

    public void changeValue() 
    {
        gameObject.GetComponent<Text>().text = "" + s.value;
    }

}
