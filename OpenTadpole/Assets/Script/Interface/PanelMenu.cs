using UnityEngine;
using System.Collections;

public class PanelMenu : MonoBehaviour {

    public void PanelMove() 
    {
        gameObject.transform.position = Input.mousePosition;
    }
}
