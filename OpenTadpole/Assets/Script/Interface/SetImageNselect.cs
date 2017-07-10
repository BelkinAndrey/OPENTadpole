using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetImageNselect : MonoBehaviour {

    public Sprite s0;
    public Sprite s1;
    public Sprite s2;

    public void SetImage(int index) 
    {
        switch (index) 
        {
            case 0: GetComponent<Image>().sprite = s0; break;
            case 1: GetComponent<Image>().sprite = s1; break;
            case 2: GetComponent<Image>().sprite = s2; break;
            default: GetComponent<Image>().sprite = s0; break;
        }
    }
}
