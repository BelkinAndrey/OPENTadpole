using UnityEngine;
using System.Collections;

public class SelectOneMove : MonoBehaviour {

    public GameObject Manager;

    public void MoveSelect() 
    {
        if (Manager != null)
        {
            if (Manager.GetComponent<SelectionNeuron>().SelectorNeuronOne != null) 
                gameObject.transform.position = Manager.GetComponent<SelectionNeuron>().SelectorNeuronOne.transform.position;
        }
    }
}
