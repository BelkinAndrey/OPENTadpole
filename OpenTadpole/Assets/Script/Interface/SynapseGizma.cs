using UnityEngine;
using System.Collections;

public class SynapseGizma : MonoBehaviour {

    public GameObject Manager;

    public void ActionGizma() 
    {
        if (Manager != null) 
        {
            gameObject.SetActive(true);
            Vector3 startPos = Manager.GetComponent<SelectionNeuron>().SelectorNeuronOne.transform.position;
            startPos.z = 1f;
            gameObject.GetComponent<LineRenderer>().SetPosition(0, startPos);
        }
    }

    void Update() 
    {
        Vector3 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        endPos.z = 1f;
        gameObject.GetComponent<LineRenderer>().SetPosition(1, endPos);
    }
}
