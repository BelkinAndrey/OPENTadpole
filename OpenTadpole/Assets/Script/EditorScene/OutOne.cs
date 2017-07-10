using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OutOne : MonoBehaviour {

    private Neuron _N;
    public Neuron N
    {
        get { return _N; }
        set
        {
            if ((_N != null) && (value == null))
            {
                transform.GetChild(0).GetComponent<LineRenderer>().enabled = false;
            }

            _N = value;
        }
    }

    private GameObject Inspector;

    private byte BColor = 255;
    private byte Acolor = 130;


    IEnumerator ReColor() 
    {
        while (true)
        {
            if (BColor < 255) BColor += 5;
            if (Acolor > 130) Acolor -= 5;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void OnSelectTarget(GameObject value)
    {
        Inspector = value;
        N = value.GetComponent<InspectorNeuron>().isNeuron;
        N.deAction += Detect;
        N.deAction += transform.GetChild(2).GetComponent<IndicatorMuscle>().AddForce;
    }

    public void OffSelectTarget()
    {
        if (N != null)
        {
            N.deAction -= Detect;
            N.deAction -= transform.GetChild(2).GetComponent<IndicatorMuscle>().AddForce;
            N = null;
        }
    }

    public void Detect() 
    {
        BColor = 0;
        Acolor = 255;
    }

    void Start() 
    {
        StartCoroutine("ReColor");
    }

    void Update() 
    {
        Color32 color = new Color32(255, 255, BColor, Acolor);
        if (GetComponent<Image>().color != color) 
        {
            GetComponent<Image>().color = color;
            transform.GetChild(0).GetComponent<Image>().color = color;
            transform.GetChild(0).GetComponent<LineRenderer>().SetColors(color, color);
        }

        if ((Inspector == null) && (N != null)) N = null;
    }

}
