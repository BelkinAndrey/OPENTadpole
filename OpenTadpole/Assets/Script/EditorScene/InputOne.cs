using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputOne : MonoBehaviour {

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

    public KeyCode Code;
    private bool action = false;

    public void OnSelectTarget(GameObject value) 
    {
        Inspector = value;
        N = value.GetComponent<InspectorNeuron>().isNeuron;
    }

    public void OffSelectTarget() 
    {
        Inspector = null;
        N = null;
    }

    void Update()
    {
        if (Input.GetKey(Code))
        {
            action = true;
            OnDownKey();
        }
        else 
        {
            if (action) 
            {
                action = false;
                OnUpKey();
            }
        }

        if ((Inspector == null) && (N != null)) N = null;
    }

    private void OnDownKey() 
    {
        if (N != null) N.Signal(2, 0, 0);
        GetComponent<Image>().color = new Color32(255, 255, 0, 130);
        transform.GetChild(0).GetComponent<Image>().color = GetComponent<Image>().color;
        transform.GetChild(0).GetComponent<LineRenderer>().SetColors(new Color32(255, 255, 0, 130), new Color32(255, 255, 0, 130));

    }

    private void OnUpKey() 
    {
        GetComponent<Image>().color = new Color32(255, 255, 255, 130);
        transform.GetChild(0).GetComponent<Image>().color = GetComponent<Image>().color;
        transform.GetChild(0).GetComponent<LineRenderer>().SetColors(new Color32(255, 255, 255, 130), new Color32(255, 255, 255, 130));
    }
}
