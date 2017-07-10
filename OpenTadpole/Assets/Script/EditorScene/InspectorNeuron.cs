using UnityEngine;
using System.Collections;

public class InspectorNeuron : MonoBehaviour {

    public Neuron isNeuron;

    private Color32 color = new Color32();
    public void reColor() 
    {
        if (isNeuron != null) 
        {
            switch (isNeuron.Type)
            {
                case 0: color = new Color32(241, 255, 0, 150); break;
                case 1: color = new Color32(0, 255, 0, 150); break;
                case 2: color = new Color32(250, 0, 255, 150); break;
            }
        }
    }

    void OnMouseEnter()
    {
        if (transform.localScale.x != 2) transform.localScale = new Vector3(1.5f, 1.5f, 1f);
    }

    void OnMouseExit()
    {
        if (transform.localScale.x != 2) transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void OnActionNeuron() 
    {
       if (isNeuron.Type < 3) color = new Color32(255, 0, 0, 255); 
    }

    public void DeReActionNeuron() 
    {
        if (isNeuron.Type < 3) color = new Color32(0, 0, 255, 255);
    }

    public void deActionNeuron() 
    {
        reColor();
    }

    void Update() 
    {
        if (GetComponent<SpriteRenderer>().color != color) GetComponent<SpriteRenderer>().color = color;
    }
}
